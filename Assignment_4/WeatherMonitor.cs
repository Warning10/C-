using System;

namespace Assignment_4
{
    public delegate void WeatherChangedEventHandler(object sender, WeatherEventArgs e);

    public class WeatherEventArgs : EventArgs
    {
        public string Weather { get; }

        public WeatherEventArgs(string weather)
        {
            Weather = weather;
        }
    }

    public class WeatherMonitor
    {
        public event WeatherChangedEventHandler WeatherChanged;

        private string currentWeather;

        public void ChangeWeather(string newWeather)
        {
            if (newWeather != currentWeather)
            {
                currentWeather = newWeather;
                OnWeatherChanged(new WeatherEventArgs(currentWeather));
            }
        }

        protected virtual void OnWeatherChanged(WeatherEventArgs e)
        {
            if (WeatherChanged != null)
            {
                WeatherChanged(this, e);
            }
        }

        public void SetWeather()
        {
            Console.Write("Enter current weather (e.g., Sunny, Rainy, Cloudy): ");
            string weather = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(weather) || !IsValidWeather(weather))
            {
                Console.WriteLine("Invalid input. Please enter a valid weather condition using only letters and spaces.");
                Console.Write("Enter current weather (e.g., Sunny, Rainy, Cloudy): ");
                weather = Console.ReadLine();
            }

            ChangeWeather(weather);
        }

        private bool IsValidWeather(string weather)
        {
            foreach (char c in weather)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    return false;
                }
            }
            return true;
        }
    }

    public class WeatherDisplay
    {
        public void Subscribe(WeatherMonitor monitor)
        {
            monitor.WeatherChanged += OnWeatherChanged;
        }

        private void OnWeatherChanged(object sender, WeatherEventArgs e)
        {
            Console.WriteLine($"Weather has changed to: {e.Weather}");
        }
    }
}
