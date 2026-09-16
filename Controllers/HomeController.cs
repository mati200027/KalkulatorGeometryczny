using Microsoft.AspNetCore.Mvc;
using KalkulatorGeometryczny.Models;

namespace KalkulatorGeometryczny.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new KalkulatorModel());
        }

        [HttpPost]
        public IActionResult Index(KalkulatorModel model)
        {
            switch (model.Figura)
            {
                case "Kwadrat":
                    model.Pole = model.A * model.A;
                    model.Obwod = 4 * model.A;
                    break;

                case "Prostok¹t":
                    model.Pole = model.A * model.B;
                    model.Obwod = 2 * model.A + 2 * model.B;
                    break;

                case "Trójk¹t":
                    model.Pole = (model.A * model.H) / 2;
                    model.Obwod = model.A + model.B + model.C;
                    break;

                case "Ko³o":
                    model.Pole = Math.PI * model.R * model.R;
                    model.Obwod = 2 * Math.PI * model.R;
                    break;
            }

            return View(model);
        }
    }
}