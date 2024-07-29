using EventManagementSystem.Exceptions;
using EventManagementSystem.Models;
using EventManagementSystem.Validations;
using System;
using System.Collections.Generic;

namespace EventManagementSystem.Services
{
    public class EventManagementSystem
    {
        public List<Event> Events { get; private set; } = new List<Event>();
        public List<Attendee> Attendees { get; private set; } = new List<Attendee>();
        public List<TicketSale> Sales { get; private set; } = new List<TicketSale>();

        public void CreateEvent(Event newEvent)
        {
            if (newEvent.Date < DateTime.Now)
                throw new InvalidDateException("Event date cannot be in the past.");

            Events.Add(newEvent);
        }

        public void RegisterAttendee(Attendee attendee)
        {
            if (!Validator.IsValidEmail(attendee.Email))
                throw new InvalidEmailException("Invalid email format.");

            Attendees.Add(attendee);
        }

        public void RecordTicketSale(TicketSale sale)
        {
            if (sale.Quantity > sale.Event.TicketsAvailable)
                throw new InvalidTicketQuantityException("Not enough tickets available.");

            sale.CompleteSale();
            Sales.Add(sale);
        }

        public string GenerateEventReport()
        {
            if (Events.Count == 0)
            {
                return "No events scheduled.";
            }

            var report = "Event Report:\n";

            foreach (var ev in Events)
            {
                report += $"\nEvent ID: {ev.EventID}, Title: {ev.Title}, Date: {ev.Date.ToShortDateString()}, Tickets Available: {ev.TicketsAvailable}\n";

                int totalSales = 0;
                int ticketsSold = 0;

                foreach (var sale in Sales)
                {
                    if (sale.Event.EventID == ev.EventID)
                    {
                        totalSales++;
                        ticketsSold += sale.Quantity;
                    }
                }

                report += $"Total Sales: {totalSales}, Tickets Sold: {ticketsSold}\n";
            }

            return report;
        }

        public Event GetEventById(string eventId)
        {
            foreach (var ev in Events)
            {
                if (ev.EventID == eventId)
                {
                    return ev;
                }
            }
            return null;
        }

        public Attendee GetAttendeeById(string attendeeId)
        {
            foreach (var attendee in Attendees)
            {
                if (attendee.AttendeeID == attendeeId)
                {
                    return attendee;
                }
            }
            return null;
        }
    }
}
