using MassTransit;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

bool isContainer;
string rabbiMqConnectionString;

bool.TryParse(Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER"), out isContainer);

rabbiMqConnectionString = isContainer ? builder.Configuration.GetConnectionString("RabbitMqDocker") 
    : builder.Configuration.GetConnectionString("RabbitMqLocal");

var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
{
    cfg.Host(rabbiMqConnectionString);
    cfg.ReceiveEndpoint("emailQueue", e =>
    {
        e.Consumer(() => new EmailConsumer(builder.Configuration));
    });
});

await busControl.StartAsync();

app.Run();