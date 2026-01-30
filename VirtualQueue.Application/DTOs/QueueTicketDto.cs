using VirtualQueue.Domain.Enums;

namespace VirtualQueue.Application.DTOs;

public record QueueTicketDto(
    Guid Id,
    int Number,
    string CustomerName,
    DateTime JoinedAt,
    TicketStatus Status
);
