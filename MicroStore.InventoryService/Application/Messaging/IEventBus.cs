namespace MicroStore.InventoryService.Application.Messaging;
public interface IEventBus
{
    Task PublishAsync<T>(T @event);
}
