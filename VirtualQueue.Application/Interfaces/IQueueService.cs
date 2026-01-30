using VirtualQueue.Application.DTOs;

namespace VirtualQueue.Application.Interfaces;

public interface IQueueService
{
    QueueTicketDto Enqueue(string customerName);
    QueueTicketDto? CallNext();
    IReadOnlyList<QueueTicketDto> GetQueue();
    int GetPosition(Guid ticketId);
}
