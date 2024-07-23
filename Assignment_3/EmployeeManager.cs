using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Assignment_3
{
    public class EmployeeManager
    {
        private Hashtable employees = new Hashtable();


        public void AddEmployee(int empNumber, string empName)
        {
            try
            {
                if (!employees.ContainsKey(empNumber))
                {
                    employees.Add(empNumber, empName);
                }
                else
                {
                    Console.WriteLine("Employee number already exists. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding employee: {ex.Message}");
            }
        }

        public void UpdateEmployee(int empNumber, string newEmpName)
        {
            try
            {
                if (employees.ContainsKey(empNumber))
                {
                    employees[empNumber] = newEmpName;
                }
                else
                {
                    Console.WriteLine("Employee number does not exist. Please try again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating employee: {ex.Message}");
            }
        }

        public void DisplayEmployees()
        {
            try
            {
                foreach (DictionaryEntry entry in employees)
                {
                    Console.WriteLine($"Employee Number: {entry.Key}, Employee Name: {entry.Value}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while displaying employees: {ex.Message}");
            }
        }

        public bool IsEmployeeExists(int empNumber)
        {
            return employees.ContainsKey(empNumber);
        }

        private bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) && Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        public void InputEmployees(int numberOfEmployees)
        {
            for (int i = 0; i < numberOfEmployees; i++)
            {
                int empNumber;
                string empName;

                try
                {
                    Console.Write($"Enter employee number for employee {i + 1}: ");
                    while (!int.TryParse(Console.ReadLine(), out empNumber) || empNumber <= 0 || IsEmployeeExists(empNumber))
                    {
                        if (IsEmployeeExists(empNumber))
                        {
                            Console.WriteLine("Employee number already exists. Please enter a unique number.");
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a valid positive integer.");
                        }
                        Console.Write($"Enter employee number for employee {i + 1}: ");
                    }

                    Console.Write($"Enter employee name for employee {i + 1}: ");
                    empName = Console.ReadLine();
                    while (!IsValidName(empName))
                    {
                        Console.WriteLine("Invalid input. Please enter a name with only alphabets and spaces.");
                        Console.Write($"Enter employee name for employee {i + 1}: ");
                        empName = Console.ReadLine();
                    }

                    AddEmployee(empNumber, empName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while inputting employee details: {ex.Message}");
                }
            }
        }

        public void UpdateEmployeeDetails()
        {
            int updateEmpNumber;
            string newEmpName;

            try
            {
                Console.Write("Enter employee number to update: ");
                while (!int.TryParse(Console.ReadLine(), out updateEmpNumber) || updateEmpNumber <= 0 || !IsEmployeeExists(updateEmpNumber))
                {
                    if (!IsEmployeeExists(updateEmpNumber))
                    {
                        Console.WriteLine("Employee number does not exist. Please enter an existing number.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid positive integer.");
                    }
                    Console.Write("Enter employee number to update: ");
                }

                Console.Write("Enter new employee name: ");
                newEmpName = Console.ReadLine();
                while (!IsValidName(newEmpName))
                {
                    Console.WriteLine("Invalid input. Please enter a name with only alphabets and spaces.");
                    Console.Write("Enter new employee name: ");
                    newEmpName = Console.ReadLine();
                }

                UpdateEmployee(updateEmpNumber, newEmpName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating employee details: {ex.Message}");
            }
        }
    }
}
