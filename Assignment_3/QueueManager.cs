using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    public class QueueManager
    {
        private Queue queue;

        public QueueManager()
        {
            queue = new Queue();
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

                    if (!QueueContains(number))
                    {
                        queue.Enqueue(number);
                    }
                    else
                    {
                        Console.WriteLine("Number already exists in the queue. Please enter a different number.");
                        i--; // Retry for this iteration
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while inputting numbers: {ex.Message}");
            }
        }

        public void CalculateAndDisplaySumAndAverage()
        {
            try
            {
                int sum = 0;
                int count = queue.Count;

                foreach (var item in queue)
                {
                    if (item is int number)
                    {
                        sum += number;
                    }
                }

                double average = count > 0 ? (double)sum / count : 0;

                Console.WriteLine($"Sum: {sum}");
                Console.WriteLine($"Average: {average}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while calculating sum and average: {ex.Message}");
            }
        }

        public void RemoveElementAtPosition()
        {
            try
            {
                Console.Write("Enter the position (1-5) of the element to remove: ");
                int position;
                while (!int.TryParse(Console.ReadLine(), out position) || position < 1 || position > queue.Count)
                {
                    Console.WriteLine("Invalid position. Please enter a number between 1 and the current queue size.");
                    Console.Write("Enter the position (1-5) of the element to remove: ");
                }

                Queue tempQueue = new Queue();
                int index = 1;

                while (queue.Count > 0)
                {
                    var item = queue.Dequeue();
                    if (index != position)
                    {
                        tempQueue.Enqueue(item);
                    }
                    index++;
                }

                queue = tempQueue;

                Console.WriteLine("Remaining queue:");
                DisplayQueue();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while removing the element: {ex.Message}");
            }
        }

        private bool QueueContains(int number)
        {
            foreach (var item in queue)
            {
                if (item is int existingNumber && existingNumber == number)
                {
                    return true;
                }
            }
            return false;
        }

        private void DisplayQueue()
        {
            if (queue.Count == 0)
            {
                Console.WriteLine("The queue is empty.");
            }
            else
            {
                foreach (var item in queue)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
