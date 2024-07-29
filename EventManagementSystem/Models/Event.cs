using System;

namespace EventManagementSystem.Models
{
    public class Event
    {
        public string EventID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public int TicketsAvailable { get; set; }

        public void UpdateTickets(int quantity)
        {
            TicketsAvailable -= quantity;
        }
    }
}
