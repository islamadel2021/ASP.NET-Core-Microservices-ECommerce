using Matgr.MessageBus;
using Matgr.PaymentsAPI.Extensions;
using Matgr.PaymentsAPI.RabbitMQSender;
using Matgr.PaymentsAPI.Repository;
using Matgr.PaymentsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IPaymentProcessor, PaymentProcessor>();
builder.Services.AddSingleton<IAzureServiceBusConsumer, AzureServiceBusConsumer>();
builder.Services.AddSingleton<IMessageBus, AzureServiceBus>();
builder.Services.AddSingleton<IRabbitMQPaymentResultMessageSender, RabbitMqPaymentResultMessageSender>();
builder.Services.AddHostedService<RabbitMQPaymentConsumer>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseAzureServiceBusConsumer();

app.Run();
