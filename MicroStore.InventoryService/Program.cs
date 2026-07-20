using MicroStore.InventoryService.Application.Messaging;
using MicroStore.InventoryService.Infrastracture.Messaging;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("ConnectionStringRedis")));

//var serverConnection = configuration.GetSection("RabbitMQ");

//// Connect to a RabbitMQ node using a hostname configured
//var factory = new ConnectionFactory
//{
//    // "guest"/"guest" by default, limited to localhost connections
//    HostName = serverConnection.GetValue<string>("HostName"),
//    UserName = serverConnection.GetValue<string>("Username"),
//    Password = serverConnection.GetValue<string>("Password"),
//    VirtualHost= serverConnection.GetValue<string>("VirtualHost")
//};

////// If set, controls the client-provided connection name for all new connections opened by this factory.
////// This name will be shared by all connections instantiated by
////// this factory
////factory.ClientProvidedName = "app:audit component:event-consumer";

//// Establishes a connection to the message broker using the provided factory.
//IConnection conn = await factory.CreateConnectionAsync();

////// Connect to a RabbitMQ node using the hostName property
////ConnectionFactory factory = new ConnectionFactory();

////// 5672 for regular ("plain TCP") connections, 5671 for connections with TLS enabled
////factory.Uri = new Uri("amqp://user:pass@hostName:port/vhost");

////IConnection conn = await factory.CreateConnectionAsync();

////// Connect to a RabbitMQ node Using Lists of Endpoints
////ConnectionFactory factory = new ConnectionFactory();
////factory.UserName = "username";
////factory.Password = "s3Kre7";

////var endpoints = new System.Collections.Generic.List<AmqpTcpEndpoint> {
////  new AmqpTcpEndpoint("hostname"),
////  new AmqpTcpEndpoint("localhost")
////};
////IConnection conn = await factory.CreateConnectionAsync(endpoints);

////// To disconnect, simply close the channel and the connection:
////await channel.CloseAsync();
////await conn.CloseAsync();
////await channel.DisposeAsync();

////await conn.DisposeAsync();

//// Creates a channel within the established connection for communication.
//IChannel channel = await conn.CreateChannelAsync();

//await channel.ExchangeDeclareAsync("exchangeName", ExchangeType.Direct);
//await channel.QueueDeclareAsync(
//        queue: "basic",        // Specifies the name of the queue being declared.
//        durable: true,        // Indicates whether the queue should survive a broker restart; false means it won't.
//        exclusive: false,      // Indicates whether the queue can be accessed by other connections; false means it can.
//        autoDelete: false,     // Indicates whether the queue will be deleted when the last consumer unsubscribes; false means it won't.
//        arguments: null       // Additional arguments for the queue declaration; in this case, no additional arguments are provided.
//    );
//await channel.QueueBindAsync("basic", "exchangeName", "routingKey", null);

////// Publishing Messages
////byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes("Hello, world!");
////var props = new BasicProperties();
////props.Expiration = "36000000";
////await channel.BasicPublishAsync("exchangeName", routingKey, false, props, messageBodyBytes);

////// Publishing Messages for fine control, you can use overloaded variants to specify the mandatory flag, or specify messages properties
////byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes("Hello, world!");
////var props = new BasicProperties();
////props.ContentType = "text/plain";
////props.DeliveryMode = 2;
////await channel.BasicPublishAsync("exchangeName", routingKey,
////    mandatory: true, basicProperties: props, body: messageBodyBytes);

////// Publish messages with custom headers
////byte[] messageBodyBytes = System.Text.Encoding.UTF8.GetBytes("Hello, world!");

////var props = new BasicProperties();
////props.ContentType = "text/plain";
////props.DeliveryMode = 2;
////props.Headers = new Dictionary<string, object>();
////props.Headers.Add("latitude", 51.5252949);
////props.Headers.Add("longitude", -0.0905493);

////await channel.BasicPublishAsync("exchangeName", routingKey, true, props, messageBodyBytes);

////// Retrieving Messages By Subscription ("push API")
//var consumer = new AsyncEventingBasicConsumer(channel);
//consumer.ReceivedAsync += async (ch, ea) =>
//{
//    var body = ea.Body.ToArray();
//    // copy or deserialise the payload
//    // and process the message
//    // ...
//    await channel.BasicAckAsync(ea.DeliveryTag, false);
//};

//// this consumer tag identifies the subscription
//// when it has to be cancelled
//string consumerTag = await channel.BasicConsumeAsync(
//    queue: "basic",
//    autoAck: false,     // Indicates whether automatic acknowledgment should be enabled; true means messages are automatically acknowledged upon delivery.
//    consumer: consumer      // Specifies the object responsible for handling incoming messages; typically an instance of a class implementing the IBasicConsumer interface.
//    );
////// Cancel an active consumer
////await channel.BasicCancelAsync(consumerTag);

builder.Services.AddSingleton<RabbitMqConnection>();

builder.Services.AddSingleton<RabbitMqInitializer>();

builder.Services.AddSingleton<IEventBus, RabbitMqEventBus>();

builder.Services.AddHostedService<OrderCreatedConsumer>();

var app = builder.Build();

app.Services.GetRequiredService<RabbitMqInitializer>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/", () => "Hello world!");

app.UseAuthorization();

app.MapControllers();

app.Run();
