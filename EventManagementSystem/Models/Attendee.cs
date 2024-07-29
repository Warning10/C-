namespace EventManagementSystem.Models
{
    public class Attendee
    {
        public string AttendeeID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public string GetAttendeeDetails()
        {
            return $"ID: {AttendeeID}, Name: {Name}, Email: {Email}";
        }
    }
}
