namespace MicroStore.InventoryService.Domain.Common;
public abstract class DomainEvent : IDomainEvent
{
    protected DomainEvent()
    {
        OccurredOnUtc = DateTime.UtcNow;
    }

    public DateTime OccurredOnUtc { get; }
}
