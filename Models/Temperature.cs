using System.ComponentModel.DataAnnotations;

namespace MetricSystem.Models
{
    public class Temperature
    {
        [Required(ErrorMessage = "Fahrenheit value is required.")]
        [Range(-1000, 10000, ErrorMessage = "Enter a value between -1000 and 10000.")]
        public double? Fahrenheit { get; set; }   // nullable per spec

        public double? Celsius { get; set; }      // keep nullable; shown in the form

        // Calculation lives in the model (per spec)
        public double? ConvertToCelsius()
        {
            if (Fahrenheit == null)
                return null;  // return null if no input

            return (Fahrenheit.Value - 32.0) * 5.0 / 9.0;
        }
    }
}
