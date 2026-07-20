using MicroStore.InventoryService.Application.Messaging;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MicroStore.InventoryService.Infrastracture.Messaging;

public sealed class RabbitMqEventBus : IEventBus
{
    private readonly RabbitMqConnection _connection;

    public RabbitMqEventBus(RabbitMqConnection connection)
    {
        _connection = connection;
    }

    public async Task PublishAsync<T>(T @event)
    {
        var channel = await _connection.Connection.CreateChannelAsync();

        var body = Encoding.UTF8.GetBytes(
            JsonSerializer.Serialize(@event));

        var properties = new BasicProperties
        {
            DeliveryMode = DeliveryModes.Persistent
        };

        await channel.BasicPublishAsync(
            exchange: "orders",
            routingKey: "order.created",
            mandatory: false,
            basicProperties: properties,
            body: body);

        await channel.DisposeAsync();
    }
}