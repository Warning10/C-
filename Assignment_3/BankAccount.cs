using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class BankAccount
    {
        private decimal balance;

        public BankAccount()
        {
            balance = 10000; // Initial balance
        }

        public void WithdrawAmount()
        {
            try
            {
                Console.Write("Enter amount to withdraw: ");
                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                    Console.Write("Enter amount to withdraw: ");
                }

                if (amount > balance)
                {
                    throw new InvalidAmountException("Invalid amount: exceeds current balance.");
                }

                // If the balance becomes zero after withdrawal, no exception should be thrown
                balance -= amount;

                if (balance < 0)
                {
                    throw new NegativeBalanceException("Balance has gone negative.");
                }

                Console.WriteLine($"Remaining balance: {balance:C}");
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (NegativeBalanceException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }

    // Custom Exception for invalid amount
    public class InvalidAmountException : Exception
    {
        public InvalidAmountException(string message) : base(message) { }
    }

    // Custom Exception for negative balance
    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException(string message) : base(message) { }
    }
}
