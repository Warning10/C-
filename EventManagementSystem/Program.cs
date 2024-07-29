using System;
using EventManagementSystem.Services;
using EventManagementSystem.Exceptions;
using EventManagementSystem.UI;

namespace EventManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = new EventManagementSystem.Services.EventManagementSystem();
            bool running = true;

            while (running)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Event Management System");
                Console.WriteLine("1. Create Event");
                Console.WriteLine("2. Register Attendee");
                Console.WriteLine("3. Record Ticket Sale");
                Console.WriteLine("4. Generate Event Report");
                Console.WriteLine("5. Exit");
                Console.ResetColor();
                Console.Write("Select an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                    Console.ResetColor();
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            var newEvent = ConsoleUI.CreateEventUI();
                            system.CreateEvent(newEvent);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Event created successfully.");
                            Console.ResetColor();
                            break;
                        case 2:
                            var attendee = ConsoleUI.RegisterAttendeeUI();
                            system.RegisterAttendee(attendee);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Attendee registered successfully.");
                            Console.ResetColor();
                            break;
                        case 3:
                            var sale = ConsoleUI.RecordTicketSaleUI(system);
                            system.RecordTicketSale(sale);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Ticket sale recorded successfully.");
                            Console.ResetColor();
                            break;
                        case 4:
                            var report = system.GenerateEventReport();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(report);
                            Console.ResetColor();
                            break;
                        case 5:
                            running = false;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid choice. Please select a number between 1 and 5.");
                            Console.ResetColor();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }
    }
}
