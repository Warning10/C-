using System;

namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CalculatorOperations operations = new CalculatorOperations();

            try
            {
                int a = operations.GetValidInput("Enter the first number: ");
                int b = operations.GetValidInput("Enter the second number: ");

                operations.PerformOperations(a, b);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }

            try
            {
                WeatherMonitor monitor = new WeatherMonitor();
                WeatherDisplay display = new WeatherDisplay();

                display.Subscribe(monitor);

                for (int i = 0; i < 5; i++)
                {
                    monitor.SetWeather();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
