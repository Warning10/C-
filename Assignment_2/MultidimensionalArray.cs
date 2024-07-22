using System;

namespace Assignment_2
{
    internal class MultidimensionalArray
    {
        public void TransformArray()
        {
            int[,] originalArray = new int[3, 3];
            int[,] transformedArray = new int[3, 3];

            Console.WriteLine("Enter Element for a 3*3 matrix:");

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Elements [{i}, {j}]: ");
                    originalArray[i, j] = int.Parse(Console.ReadLine()); 
                }
            }

            for (int i=0; i<3;i++)
            {
                for(int j = 0;j < 3;j++)
                {
                    transformedArray[j,i] = originalArray[i,j];
                }
            }

            Console.WriteLine("\nOriginal Array: ");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(originalArray[i, j] + "\t");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nTransformed Array: ");
            for(int i=0; i<3; i++)
            {
                for (int j=0; j<3;j++)
                {
                    Console.Write(transformedArray[i,j] + "\t");
                }
                Console.WriteLine();
            }

        }
    }
}
