using VirtualQueue.Domain.Enums;
using VirtualQueue.Domain.ValueObjects;

namespace VirtualQueue.Domain.Entities;

public class QueueTicket
{
    public Guid Id { get; }
    public TicketNumber Number { get; }
    public string CustomerName { get; }
    public DateTime JoinedAt { get; }
    public TicketStatus Status { get; private set; }

    public QueueTicket(TicketNumber number, string customerName)
    {
        Id = Guid.NewGuid();
        Number = number;
        CustomerName = customerName;
        JoinedAt = DateTime.Now;
        Status = TicketStatus.Waiting;
    }

    public void Call() => Status = TicketStatus.Called;
    public void Serve() => Status = TicketStatus.Served;
    public void Skip() => Status = TicketStatus.Skipped;
}
