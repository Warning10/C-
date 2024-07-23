using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class VoterManager
    {
        private string[] voters = new string[5];

        public void InputVoterDetails()
        {
            try
            {
                Console.WriteLine("Enter details for 5 voters:");

                for (int i = 0; i < 5; i++)
                {
                    int age;
                    Console.Write($"Enter age for voter {i + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out age) || age <= 0)
                    {
                        Console.WriteLine("Invalid input. Please enter a positive number.");
                        Console.Write($"Enter age for voter {i + 1}: ");
                    }

                    if (age < 18)
                    {
                        throw new UnderageException("Voter is underage. Minimum age is 18.");
                    }

                    Console.Write($"Enter name for voter {i + 1}: ");
                    string name = Console.ReadLine();

                    if (!IsValidName(name))
                    {
                        Console.WriteLine("Invalid name. Please enter a name with only alphabets and spaces.");
                        i--; // Retry for this iteration
                        continue;
                    }

                    voters[i] = $"{name} (Age: {age})";
                }

                DisplayVoterDetails();
            }
            catch (UnderageException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        private void DisplayVoterDetails()
        {
            Console.WriteLine("\nVoter Details:");
            foreach (string voter in voters)
            {
                Console.WriteLine(voter);
            }
        }
    }

    // Custom Exception for underage voters
    public class UnderageException : Exception
    {
        public UnderageException(string message) : base(message) { }
    }
}
