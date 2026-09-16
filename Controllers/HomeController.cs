using Microsoft.AspNetCore.Mvc;
using KalkulatorGeometryczny.Models;
using System.Text;
using System.Text.Json;

namespace KalkulatorGeometryczny.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new KalkulatorModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(KalkulatorModel model)
        {
            var json = JsonSerializer.Serialize(model);

            var content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(
                "https://kalkulator-backend-mateusz-bgezhca7apfcb6gy.polandcentral-01.azurewebsites.net/api/Kalkulator/oblicz",
                content
            );

            if (response.IsSuccessStatusCode)
            {
                var odpowiedz = await response.Content.ReadAsStringAsync();

                var wynik = JsonSerializer.Deserialize<WynikModel>(
                    odpowiedz,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                if (wynik != null)
                {
                    model.Pole = wynik.Pole;
                    model.Obwod = wynik.Obwod;
                }
            }

            return View(model);
        }
    }

    public class WynikModel
    {
        public string Figura { get; set; } = "";
        public double Pole { get; set; }
        public double Obwod { get; set; }
    }
}