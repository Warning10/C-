using System;
using System.Text.RegularExpressions;

namespace Assignment_4
{
    public static class InputValidation
    {
        public static int GetValidInput(string prompt)
        {
            int value;
            Console.Write(prompt);
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid input. Please enter a valid integer.");
                Console.ResetColor();
                Console.Write(prompt);
            }
            return value;
        }

        public static bool IsValidName(string name)
        {
            Regex regex = new Regex(@"^[a-zA-Z\s]+$");
            return regex.IsMatch(name);
        }

        public static void PauseAndWaitForUser()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Operation completed. Press any key to continue...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
