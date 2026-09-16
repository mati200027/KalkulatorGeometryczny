using Microsoft.AspNetCore.Mvc;
using KalkulatorBackend.Models;

namespace KalkulatorBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KalkulatorController : ControllerBase
    {
        [HttpPost("oblicz")]
        public IActionResult Oblicz([FromBody] KalkulatorRequest model)
        {
            double pole;
            double obwod;

            switch (model.Figura)
            {
                case "Kwadrat":
                    pole = model.A * model.A;
                    obwod = 4 * model.A;
                    break;

                case "Prostokąt":
                    pole = model.A * model.B;
                    obwod = 2 * model.A + 2 * model.B;
                    break;

                case "Trójkąt":
                    pole = (model.A * model.H) / 2;
                    obwod = model.A + model.B + model.C;
                    break;

                case "Koło":
                    pole = Math.PI * model.R * model.R;
                    obwod = 2 * Math.PI * model.R;
                    break;

                default:
                    return BadRequest(new
                    {
                        komunikat = "Nieprawidłowa figura."
                    });
            }

            return Ok(new
            {
                figura = model.Figura,
                pole = Math.Round(pole, 2),
                obwod = Math.Round(obwod, 2)
            });
        }
    }
}