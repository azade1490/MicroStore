namespace MicroStore.InventoryService.Application.Events;
public sealed record OrderCreatedEvent(
    Guid OrderId,
    Guid CustomerId,
    decimal TotalPrice);
