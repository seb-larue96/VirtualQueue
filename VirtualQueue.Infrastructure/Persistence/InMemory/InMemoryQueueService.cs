using System.Collections.Concurrent;
using VirtualQueue.Application.DTOs;
using VirtualQueue.Application.Interfaces;
using VirtualQueue.Domain.Entities;
using VirtualQueue.Domain.ValueObjects;

namespace VirtualQueue.Infrastructure.Persistence.InMemory;

public sealed class InMemoryQueueService : IQueueService
{
    private readonly ConcurrentQueue<QueueTicket> _queue = new();
    private int _lastTicketNumber = 0;

    public QueueTicketDto Enqueue(string customerName)
    {
        var ticketNumber = new TicketNumber(Interlocked.Increment(ref _lastTicketNumber));

        var ticket = new QueueTicket(ticketNumber, customerName);
        _queue.Enqueue(ticket);

        return Map(ticket);
    }

    public QueueTicketDto? CallNext()
    {
        if (!_queue.TryDequeue(out var ticket))
            return null;

        ticket.Call();
        return Map(ticket);
    }

    public IReadOnlyList<QueueTicketDto> GetQueue()
    {
        return _queue
            .Select(Map)
            .OrderBy(x => x.Number)
            .ToList();
    }

    public int GetPosition(Guid ticketId)
    {
        var index = _queue
            .Select((ticket, i) => new { ticket.Id, Index = i })
            .FirstOrDefault(x => x.Id == ticketId);

        return index is null ? -1 : index.Index + 1;
    }

    private static QueueTicketDto Map(QueueTicket ticket) =>
        new(
            ticket.Id,
            ticket.Number.Value,
            ticket.CustomerName,
            ticket.JoinedAt,
            ticket.Status
        );
}
