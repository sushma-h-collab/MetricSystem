using Microsoft.AspNetCore.Mvc;
using MetricSystem.Models;

namespace MetricSystem.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Temperature());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Temperature model)
        {
            if (!ModelState.IsValid) return View(model);

            model.Celsius = model.ConvertToCelsius();

            // so the textbox shows the computed value instead of the empty posted value
            ModelState.Remove(nameof(model.Celsius));

            // requirement: carry via ViewBag (do not render it in the view)
            ViewBag.Celsius = model.Celsius;

            return View(model);
        }

        public IActionResult Privacy() => View();
    }
}
