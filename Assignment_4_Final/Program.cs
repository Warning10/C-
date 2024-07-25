using System;

namespace Assignment_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool continueOperations = true;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("============== Menu ==============");
                Console.WriteLine("1. Perform Calculator Operations");
                Console.WriteLine("2. Monitor Weather");
                Console.WriteLine("3. Manage Files");
                Console.WriteLine("4. Exit");
                Console.WriteLine("==================================");
                Console.ResetColor();
                Console.Write("Select an option (1-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        PerformCalculatorOperations();
                        break;

                    case "2":
                        MonitorWeather();
                        break;

                    case "3":
                        ManageFiles();
                        break;

                    case "4":
                        continueOperations = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        Console.ResetColor();
                        break;
                }

                if (continueOperations)
                {
                    Console.Write("Do you want to perform another operation? (Y/N): ");
                    string response = Console.ReadLine().ToUpper();
                    continueOperations = response == "Y";
                }
            } while (continueOperations);
        }

        static void PerformCalculatorOperations()
        {
            CalculatorOperations operations = new CalculatorOperations();

            try
            {
                /*int a = InputValidation.GetValidInput("Enter the first number: ");
                int b = InputValidation.GetValidInput("Enter the second number: ");*/
                operations.PerformOperations();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }
            InputValidation.PauseAndWaitForUser();
        }

        static void MonitorWeather()
        {
            try
            {
                WeatherMonitor monitor = new WeatherMonitor();
                WeatherDisplay display = new WeatherDisplay();
                display.Subscribe(monitor);
                monitor.SetTemperature();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }
            InputValidation.PauseAndWaitForUser();
        }

        static void ManageFiles()
        {
            FileManager fileManager = new FileManager();

            try
            {
                fileManager.CreateListFile();
                InputValidation.PauseAndWaitForUser();

                fileManager.CopyAndDeleteListFile();
                InputValidation.PauseAndWaitForUser();

                fileManager.ReadAndDisplayFriendsFile();
                InputValidation.PauseAndWaitForUser();

                fileManager.MoveFriendsFileToSchoolDirectory();
                InputValidation.PauseAndWaitForUser();

                fileManager.DisplayAndDeleteSchoolDirectory();
                InputValidation.PauseAndWaitForUser();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
