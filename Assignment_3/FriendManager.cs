using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class FriendManager
    {
        private Stack stack;

        public FriendManager()
        {
            stack = new Stack();
        }

        public void InputFriends()
        {
            try
            {
                Console.WriteLine("Enter names of 5 friends:");
                for (int i = 0; i < 5; i++)
                {
                    string name;

                    Console.Write($"Enter name {i + 1}: ");
                    name = Console.ReadLine();

                    while (!IsValidName(name))
                    {
                        Console.WriteLine("Invalid input. Please enter a name with only alphabets and spaces.");
                        Console.Write($"Enter name {i + 1}: ");
                        name = Console.ReadLine();
                    }

                    stack.Push(name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inputting friends: {ex.Message}");
            }
        }

        public void ReverseAndDisplayStack()
        {
            try
            {
                Stack reversedStack = new Stack();
                foreach (var item in stack)
                {
                    reversedStack.Push(item);
                }

                Console.WriteLine("Names in reversed order:");
                foreach (var item in reversedStack)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reversing and displaying the stack: {ex.Message}");
            }
        }

        public void RemoveFriendAndDisplay()
        {
            try
            {
                Console.Write("Enter the name of the friend to remove: ");
                string nameToRemove = Console.ReadLine();

                if (IsValidName(nameToRemove))
                {
                    Stack tempStack = new Stack();
                    bool found = false;

                    foreach (string name in stack)
                    {
                        if (name.Equals(nameToRemove, StringComparison.OrdinalIgnoreCase))
                        {
                            found = true;
                            continue; // Skip the name to remove it
                        }
                        tempStack.Push(name);
                    }

                    stack.Clear(); // Clear the original stack
                    foreach (var item in tempStack) // Restore the stack
                    {
                        stack.Push(item);
                    }

                    if (found)
                    {
                        Console.WriteLine("Friend removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Friend not found.");
                    }

                    DisplayStack();
                }
                else
                {
                    Console.WriteLine("Invalid name input.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing the friend: {ex.Message}");
            }
        }


        public void InputNumbers()
        {
            try
            {
                Console.WriteLine("Enter 5 numbers:");
                for (int i = 0; i < 5; i++)
                {
                    int number;
                    Console.Write($"Enter number {i + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out number))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.Write($"Enter number {i + 1}: ");
                    }

                    stack.Push(number);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inputting numbers: {ex.Message}");
            }
        }

        public void FindAndDisplayNumberOccurrences()
        {
            try
            {
                Console.Write("Enter a number to find: ");
                int numberToFind;
                while (!int.TryParse(Console.ReadLine(), out numberToFind))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Console.Write("Enter a number to find: ");
                }

                int count = 0;
                Stack tempStack = new Stack();
                foreach (var obj in stack)
                {
                    if (obj is int number && number == numberToFind)
                    {
                        count++;
                    }
                    tempStack.Push(obj);
                }

                // Restore original stack
                stack.Clear();
                foreach (var item in tempStack)
                {
                    stack.Push(item);
                }

                Console.WriteLine($"The number {numberToFind} occurs {count} times.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while finding the number occurrences: {ex.Message}");
            }
        }


        public void SortAndDisplayStack()
        {
            try
            {
                ArrayList list = new ArrayList();
                foreach (var obj in stack)
                {
                    if (obj is int number)
                    {
                        list.Add(number);
                    }
                }

                list.Sort();
                list.Reverse(); // Sorting in descending order

                Console.WriteLine("Stack sorted in descending order:");
                foreach (int number in list)
                {
                    Console.WriteLine(number);
                }

                // Restore stack
                stack.Clear();
                foreach (int number in list)
                {
                    stack.Push(number);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while sorting the stack: {ex.Message}");
            }
        }


        public void FindAndDisplayNumberAtPosition()
        {
            try
            {
                Console.Write("Enter the position (1-5): ");
                int position;
                while (!int.TryParse(Console.ReadLine(), out position) || position < 1 || position > stack.Count)
                {
                    Console.WriteLine("Invalid position. Please enter a number between 1 and the current stack size.");
                    Console.Write("Enter the position (1-5): ");
                }

                Stack tempStack = new Stack();
                int index = 1;
                int numberAtPosition = -1;

                foreach (var obj in stack)
                {
                    if (obj is int number && index == position)
                    {
                        numberAtPosition = number;
                    }
                    tempStack.Push(obj);
                    index++;
                }

                // Restore original stack
                stack.Clear();
                foreach (var item in tempStack)
                {
                    stack.Push(item);
                }

                if (numberAtPosition != -1)
                {
                    Console.WriteLine($"The number at position {position} is {numberAtPosition}.");
                }
                else
                {
                    Console.WriteLine("No number found at the given position.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while finding the number at position: {ex.Message}");
            }
        }


        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        private void DisplayStack()
        {
            Console.WriteLine("Current names in the stack:");
            if (stack.Count == 0)
            {
                Console.WriteLine("The stack is empty.");
            }
            else
            {
                foreach (var item in stack)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
