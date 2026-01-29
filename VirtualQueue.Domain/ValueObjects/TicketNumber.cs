namespace VirtualQueue.Domain.ValueObjects;

public readonly record struct TicketNumber(int Value)
{
    public override string ToString() => Value.ToString("D3");
}