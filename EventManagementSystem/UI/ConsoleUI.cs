using System;
using EventManagementSystem.Models;
using EventManagementSystem.Services;
using EventManagementSystem.Validations;
using EventManagementSystem.Exceptions;

namespace EventManagementSystem.UI
{
    public static class ConsoleUI
    {
        public static Event CreateEventUI()
        {
            Console.Write("Enter Event ID: ");
            var eventID = Console.ReadLine();

            string title;
            do
            {
                Console.Write("Enter Title: ");
                title = Console.ReadLine();
                if (!Validator.IsValidTitle(title))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid title. Title cannot be null or empty and must have only one space between words.");
                    Console.ResetColor();
                }
                else
                {
                    title = Validator.NormalizeTitle(title);
                }
            } while (!Validator.IsValidTitle(title));

            DateTime date;
            do
            {
                Console.Write("Enter Date (yyyy-mm-dd): ");
            } while (!Validator.TryParseDate(Console.ReadLine(), out date));

            int ticketsAvailable;
            do
            {
                Console.Write("Enter Tickets Available: ");
            } while (!Validator.TryParseInt(Console.ReadLine(), out ticketsAvailable));

            return new Event { EventID = eventID, Title = title, Date = date, TicketsAvailable = ticketsAvailable };
        }

        public static Attendee RegisterAttendeeUI()
        {
            Console.Write("Enter Attendee ID: ");
            var attendeeID = Console.ReadLine();
            Console.Write("Enter Name: ");
            var name = Console.ReadLine();

            string email;
            do
            {
                Console.Write("Enter Email: ");
                email = Console.ReadLine();
            } while (!Validator.IsValidEmail(email));

            return new Attendee { AttendeeID = attendeeID, Name = name, Email = email };
        }

        public static TicketSale RecordTicketSaleUI(EventManagementSystem.Services.EventManagementSystem system)
        {
            Console.Write("Enter Sale ID: ");
            var saleID = Console.ReadLine();

            Event eventObj = null;
            while (eventObj == null)
            {
                Console.Write("Enter Event ID: ");
                var eventID = Console.ReadLine();
                eventObj = system.GetEventById(eventID);
                if (eventObj == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Event not found. Try again.");
                    Console.ResetColor();
                }
            }

            Attendee attendee = null;
            while (attendee == null)
            {
                Console.Write("Enter Attendee ID: ");
                var attendeeID = Console.ReadLine();
                attendee = system.GetAttendeeById(attendeeID);
                if (attendee == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Attendee not found. Try again.");
                    Console.ResetColor();
                }
            }

            int quantity;
            do
            {
                Console.Write("Enter Quantity: ");
            } while (!Validator.TryParseInt(Console.ReadLine(), out quantity));

            return new TicketSale { SaleID = saleID, Event = eventObj, Attendee = attendee, Quantity = quantity };
        }
    }
}
