using System;

namespace Assignment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*            var basicArray = new BasicArray();

                        Console.Write("Enter number of Elements in an array: ");
                        Console.WriteLine();
                        int n = int.Parse(Console.ReadLine());
                        int[] numbers = new int[n];

                        Console.Write("Enter the elements of Array: ");
                        Console.WriteLine();
                        for (int i = 0; i < n; i++)
                        {
                            numbers[i] = int.Parse(Console.ReadLine());
                        }*/

            /*basicArray.CountDuplicates(numbers);*/

            /*basicArray.RemoveDuplicates(numbers);*/

            /*            Console.WriteLine("Enter the number you want to insert: ");
                        int newNumber = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the position to insert the number: ");
                        int position = int.Parse(Console.ReadLine());

                        basicArray.InsertAndSort(numbers, newNumber, position);*/

            /*            MultidimensionalArray multidimensionalArray = new MultidimensionalArray();
                        multidimensionalArray.TransformArray();*/

            /*            JaggedArray jaggedArray = new JaggedArray();
                        jaggedArray.AcceptAndDisplayDetails();*/

            EmployeeManagement employeeManagement = new EmployeeManagement();
            employeeManagement.AcceptAndDisplayDetails();

        }
    }
}