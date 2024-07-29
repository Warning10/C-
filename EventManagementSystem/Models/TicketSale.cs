namespace EventManagementSystem.Models
{
    public class TicketSale
    {
        public string SaleID { get; set; }
        public Event Event { get; set; }
        public Attendee Attendee { get; set; }
        public int Quantity { get; set; }

        public void CompleteSale()
        {
            Event.UpdateTickets(Quantity);
        }
    }
}
