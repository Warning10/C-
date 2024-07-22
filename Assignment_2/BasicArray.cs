using System;

namespace Assignment_2
{
    internal class BasicArray
    {

        public void CountDuplicates(int[] numbers)
        {
            int n = numbers.Length;

            for (int i = 0; i < n; i++)
            {
                int count = 1;

                if (numbers[i] != -1)
                {
                    for (int j = i + 1; j < n; j++)
                    {
                        if (numbers[i] == numbers[j])
                        {
                            count++;
                            numbers[j] = -1;
                        }
                    }
                    Console.WriteLine($"{numbers[i]} occurs {count} times");
                }
            }
        }

        public void RemoveDuplicates(int[] numbers)
        {
            int n = numbers.Length;
            int[] uniqueNumbers = new int[n];
            int uniqueCount = 0;

            for (int i = 0; i < n; i++)
            {
                bool isDuplicate = false;

                for (int j = 0; j < uniqueCount; j++)
                {
                    if (numbers[i] == uniqueNumbers[j])
                    {
                        isDuplicate = true;
                        break;
                    }
                }
                if (!isDuplicate)
                {
                    uniqueNumbers[uniqueCount] = numbers[i];
                    uniqueCount++;
                }
            }

            Console.WriteLine("Array after removing Duplicate elements: ");
            for (int i = 0; i < uniqueCount; i++)
            {
                Console.WriteLine(uniqueNumbers[i] + " ");
            }
            Console.WriteLine();
        }

        public void InsertAndSort(int[] numbers, int newNumber, int position)
        {
            int n = numbers.Length;
            int[] extendedArray = new int[n + 1];

            for (int i = 0; i < position - 1; i++)
            {
                extendedArray[i] = numbers[i];
            }

            extendedArray[position - 1] = newNumber;

            for (int i = position; i < n + 1; i++)
            {
                extendedArray[i] = numbers[i - 1];
            }
            
            Console.WriteLine("Array after insertion and sorting:");
            for (int i = 0; i< extendedArray.Length; i++)
            {
                Console.WriteLine(extendedArray[i] + " ");
            }

            for (int i = 0; i <= n; i++) 
            {
                for (int j = i+1; j<=n; j++)
                {
                    if (extendedArray[i] > extendedArray[j])
                    {
                        int temp = extendedArray[i];
                        extendedArray[i] = extendedArray[j];
                        extendedArray[j] = temp;
                    }
                }
            }

            Console.WriteLine("Array afte sorting:");
            for (int i = 0; i <= n; i++)
            {
                Console.Write(extendedArray[i] + " ");
            }
            Console.WriteLine();

        }

    }
}