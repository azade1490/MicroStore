using System.Text;
using System.Text.Json;

using MicroStore.InventoryService.Application.Events;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MicroStore.InventoryService.Infrastracture.Messaging;
public sealed class OrderCreatedConsumer : BackgroundService
{
    private readonly RabbitMqConnection _connection;

    public OrderCreatedConsumer(RabbitMqConnection connection)
    {
        _connection = connection;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var channel = await _connection.Connection.CreateChannelAsync();

        await channel.BasicQosAsync(0, 1, false);

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.ReceivedAsync += async (_, ea) =>
        {
            try
            {
                var json = Encoding.UTF8.GetString(ea.Body.ToArray());

                var message =
                    JsonSerializer.Deserialize<OrderCreatedEvent>(json);

                Console.WriteLine(message!.OrderId);

                await channel.BasicAckAsync(
                    ea.DeliveryTag,
                    false);
            }
            catch
            {
                await channel.BasicNackAsync(
                    ea.DeliveryTag,
                    false,
                    true);
            }
        };

        await channel.BasicConsumeAsync(
            "order-created",
            false,
            consumer);

        await Task.Delay(Timeout.Infinite, stoppingToken);
    }
}
