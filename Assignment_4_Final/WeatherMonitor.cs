using System;

namespace Assignment_4
{
    public delegate void WeatherChangedEventHandler(object sender, WeatherEventArgs e);

    public class WeatherMonitor
    {
        public event WeatherChangedEventHandler WeatherChanged;

        private int currentTemperature;

        public void ChangeTemperature(int newTemperature)
        {
            if (newTemperature != currentTemperature)
            {
                currentTemperature = newTemperature;
                OnWeatherChanged(new WeatherEventArgs(currentTemperature));
            }
        }

        protected virtual void OnWeatherChanged(WeatherEventArgs e) =>
            WeatherChanged?.Invoke(this, e);

        public void SetTemperature()
        {
            Console.WriteLine("\nMonitoring weather...");

            while (true)
            {
                Console.Write("Enter current temperature (-50 to 50): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int temperature) && temperature >= -50 && temperature <= 50)
                {
                    ChangeTemperature(temperature);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a valid temperature within the range -50 to 50.");
                    Console.ResetColor();
                    continue;
                }

                Console.Write("Do you want to enter another temperature? (yes/no): ");
                if (Console.ReadLine().ToLower() != "yes")
                {
                    break;
                }
            }
        }
    }
}
