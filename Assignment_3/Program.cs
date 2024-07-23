using System;

namespace Assignment_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                EmployeeManager manager = new EmployeeManager();
                Console.WriteLine("Enter details for 5 employees:");
                manager.InputEmployees(5);

                Console.WriteLine("\nEmployee details:");
                manager.DisplayEmployees();

                Console.WriteLine("\nUpdate employee details:");
                manager.UpdateEmployeeDetails();

                Console.WriteLine("\nUpdated employee details:");
                manager.DisplayEmployees();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            try
            {
                FriendManager manager = new FriendManager();

                // Input friends
                manager.InputFriends();

                // Reverse and display friends
                manager.ReverseAndDisplayStack();

                // Remove a friend and display
                manager.RemoveFriendAndDisplay();

                // Input numbers
                manager.InputNumbers();

                // Find and display number occurrences
                manager.FindAndDisplayNumberOccurrences();

                // Sort and display numbers
                manager.SortAndDisplayStack();

                // Find and display number at a position
                manager.FindAndDisplayNumberAtPosition();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            try
            {
                QueueManager manager = new QueueManager();

                manager.InputNumbers();
                manager.CalculateAndDisplaySumAndAverage();
                manager.RemoveElementAtPosition();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            try
            {
                // Bank Account Operations
                BankAccount bankAccount = new BankAccount();
                bankAccount.WithdrawAmount();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during bank operations: {ex.Message}");
            }

            try
            {
                // Voter Management
                VoterManager voterManager = new VoterManager();
                voterManager.InputVoterDetails();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred during voter management: {ex.Message}");
            }
        }
    }
}
