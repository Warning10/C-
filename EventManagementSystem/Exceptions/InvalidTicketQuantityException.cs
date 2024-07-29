using System;

namespace EventManagementSystem.Exceptions
{
    public class InvalidTicketQuantityException : Exception
    {
        public InvalidTicketQuantityException(string message) : base(message) { }
    }
}
