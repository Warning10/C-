using System;

namespace Assignment_2
{
    internal class JaggedArray
    {
        public void AcceptAndDisplayDetails()
        {
            // Jagged array to store person names and phone numbers
            string[][] persons = new string[5][];

            // Accept names and phone numbers from the console
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter name of person {i + 1}: ");
                string name = Console.ReadLine();

                int phoneCount;
                while (true)
                {
                    Console.Write($"Enter the number of phone numbers for {name}: ");
                    string phoneCountInput = Console.ReadLine();

                    if (int.TryParse(phoneCountInput, out phoneCount) && phoneCount > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a positive integer for the number of phone numbers.");
                    }
                }

                // Create an array to store the name and phone numbers
                persons[i] = new string[phoneCount + 1];
                persons[i][0] = name;

                for (int j = 1; j <= phoneCount; j++)
                {
                    Console.Write($"Enter phone number {j} for {name}: ");
                    persons[i][j] = Console.ReadLine();
                }
            }

            // Display the details in a presentable format
            Console.WriteLine("\nDetails of persons and their phone numbers:");
            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine($"Name: {persons[i][0]}");
                for (int j = 1; j < persons[i].Length; j++)
                {
                    Console.WriteLine($"Phone {j}: {persons[i][j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
