using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.ReceiveEndpoint("emailQueue", e =>
    {
        e.Consumer<EmailConsumer>();
    });
});

await busControl.StartAsync();

app.Run();