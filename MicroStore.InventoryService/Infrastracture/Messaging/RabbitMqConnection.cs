using RabbitMQ.Client;

namespace MicroStore.InventoryService.Infrastracture.Messaging;

public sealed class RabbitMqConnection : IAsyncDisposable
{
    public IConnection Connection { get; }

    public RabbitMqConnection(IConfiguration configuration)
    {
        var rabbit = configuration.GetSection("RabbitMQ");

        var factory = new ConnectionFactory
        {
            HostName = rabbit["HostName"],
            UserName = rabbit["Username"],
            Password = rabbit["Password"],
            VirtualHost = rabbit["VirtualHost"]
        };

        Connection = factory.CreateConnectionAsync().Result;
    }

    public async ValueTask DisposeAsync()
    {
        await Connection.DisposeAsync();
    }
}
