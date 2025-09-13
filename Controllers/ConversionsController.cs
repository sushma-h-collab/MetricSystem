using Microsoft.AspNetCore.Mvc;
using MetricSystem.Models;

namespace MetricSystem.Controllers
{
    public class ConversionsController : Controller
    {
        // GET: /Conversions
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Temperature());
        }

        // POST: /Conversions
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Temperature model)
        {
            if (!ModelState.IsValid)
            {
                // Show validation errors in the same view
                return View(model);
            }

            // Compute Celsius from Fahrenheit (calculation lives in the model)
            model.Celsius = model.ConvertToCelsius();

            // No ModelState.Remove(...) needed because the Celsius input is disabled in the view
            return View(model);
        }
    }
}
