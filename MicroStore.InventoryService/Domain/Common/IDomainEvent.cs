namespace MicroStore.InventoryService.Domain.Common;
public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}
