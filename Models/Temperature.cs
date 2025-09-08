using System.ComponentModel.DataAnnotations;

namespace MetricSystem.Models
{
    public class Temperature
    {
        [Display(Name = "Fahrenheit Value")]
        [Required(ErrorMessage = "Fahrenheit value is required .")]
        [Range(-1000, 10000, ErrorMessage = "Enter a value between -1000 and 10000.")]
        public double? Fahrenheit { get; set; }   // nullable per spec

        [Display(Name = "Celsius Value")]
        public double? Celsius { get; set; }      // keep nullable; shown in the form

        // Calculation lives in the model (per spec)
        public double ConvertToCelsius()
        {
            // Robust guard: controller calls this only when Fahrenheit has a value
            return ((Fahrenheit ?? 32.0) - 32.0) * 5.0 / 9.0;
        }
    }
}
