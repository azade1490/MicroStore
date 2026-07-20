using RabbitMQ.Client;

namespace MicroStore.InventoryService.Infrastracture.Messaging;

public sealed class RabbitMqInitializer
{
    public RabbitMqInitializer(RabbitMqConnection connection)
    {
        Initialize(connection).GetAwaiter().GetResult();
    }

    private async Task Initialize(RabbitMqConnection connection)
    {
        var channel = await connection.Connection.CreateChannelAsync();

        await channel.ExchangeDeclareAsync(
            "orders",
            ExchangeType.Direct,
            durable: true);

        await channel.QueueDeclareAsync(
            "order-created",
            durable: true,
            exclusive: false,
            autoDelete: false);

        await channel.QueueBindAsync(
            "order-created",
            "orders",
            "order.created");

        await channel.DisposeAsync();
    }
}
