using System;

namespace Assignment_4
{
    public class WeatherDisplay
    {
        public void Subscribe(WeatherMonitor monitor)
        {
            monitor.WeatherChanged += OnWeatherChanged;
        }

        private void OnWeatherChanged(object sender, WeatherEventArgs e)
        {
            string description = GetTemperatureDescription(e.Temperature);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Temperature has changed to: {e.Temperature}°C - {description}");
            Console.ResetColor();
        }

        private string GetTemperatureDescription(int temperature)
        {
            if (temperature <= 0) return "Freezing";
            else if (temperature <= 10) return "Cold";
            else if (temperature <= 20) return "Cool";
            else if (temperature <= 30) return "Warm";
            else return "Hot";
        }
    }
}
