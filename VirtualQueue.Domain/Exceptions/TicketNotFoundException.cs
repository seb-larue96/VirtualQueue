namespace VirtualQueue.Domain.Exceptions;

public sealed class TicketNotFoundException : Exception
{
    public TicketNotFoundException(Guid ticketId) : base($"Ticket with id '{ticketId}' was not found")
    {

    }
}
