using System;

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
                Console.WriteLine("Invalid input. Please enter a valid integer.");
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

            Console.WriteLine($"\nAddition: {a} + {b} = {add(a, b)}");
            Console.WriteLine($"Subtraction: {a} - {b} = {subtract(a, b)}");
            Console.WriteLine($"Multiplication: {a} * {b} = {multiply(a, b)}");

            try
            {
                Console.WriteLine($"Division: {a} / {b} = {divide(a, b)}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
