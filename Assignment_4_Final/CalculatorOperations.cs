/*using System;

namespace Assignment_4
{
    public delegate int Calculator(int a, int b);

    public class CalculatorOperations
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }

        public void PerformOperations(int a, int b)
        {
            Calculator add = new Calculator(Add);
            Calculator subtract = new Calculator(Subtract);
            Calculator multiply = new Calculator(Multiply);
            Calculator divide = new Calculator(Divide);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nAddition: {a} + {b} = {add(a, b)}");
            Console.WriteLine($"Subtraction: {a} - {b} = {subtract(a, b)}");
            Console.WriteLine($"Multiplication: {a} * {b} = {multiply(a, b)}");

            try
            {
                Console.WriteLine($"Division: {a} / {b} = {divide(a, b)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
            Console.ResetColor();
        }
    }
}
*/

/*using System;

namespace Assignment_4
{
    public delegate int Calculator(int a, int b);

    public class CalculatorOperations
    {
        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public int Multiply(int a, int b)
        {
            return a * b;
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }

        public int GetValidInput(string prompt)
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

        public void PerformOperations(int a, int b)
        {
            Calculator add = new Calculator(Add);
            Calculator subtract = new Calculator(Subtract);
            Calculator multiply = new Calculator(Multiply);
            Calculator divide = new Calculator(Divide);

            Console.WriteLine("\nPerforming Calculator Operations...");
            Console.WriteLine(new string('-', 40));

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Addition:       {a} + {b} = {add(a, b)}");
            Console.WriteLine($"Subtraction:    {a} - {b} = {subtract(a, b)}");
            Console.WriteLine($"Multiplication: {a} * {b} = {multiply(a, b)}");

            try
            {
                Console.WriteLine($"Division:       {a} / {b} = {divide(a, b)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }

            Console.WriteLine(new string('-', 40));
            Console.ResetColor();
        }
    }
}
*/


using System;

namespace Assignment_4
{
    public delegate int Calculator(int a, int b);

    public class CalculatorOperations
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Multiply(int a, int b) => a * b;
        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }
            return a / b;
        }

        public void PerformOperations()
        {
            bool continueCalculations = true;

            while (continueCalculations)
            {
                Console.Clear();
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Performing Calculator Operations...");
                Console.WriteLine(new string('-', 40));

                int a = GetValidInput("Enter the first number: ");
                int b = GetValidInput("Enter the second number: ");

                Calculator add = new Calculator(Add);
                Calculator subtract = new Calculator(Subtract);
                Calculator multiply = new Calculator(Multiply);
                Calculator divide = new Calculator(Divide);

                Console.Clear();
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Performing Calculator Operations...");
                Console.WriteLine(new string('-', 40));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Addition:       {a} + {b} = {add(a, b)}");
                Console.WriteLine($"Subtraction:    {a} - {b} = {subtract(a, b)}");
                Console.WriteLine($"Multiplication: {a} * {b} = {multiply(a, b)}");

                try
                {
                    Console.WriteLine($"Division:       {a} / {b} = {divide(a, b)}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }

                Console.WriteLine(new string('-', 40));
                Console.ResetColor();

                Console.Write("Do you want to perform another calculation? (yes/no): ");
                string response = Console.ReadLine().Trim().ToLower();
                continueCalculations = response == "yes";
            }
        }

        private int GetValidInput(string prompt)
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
    }
}
