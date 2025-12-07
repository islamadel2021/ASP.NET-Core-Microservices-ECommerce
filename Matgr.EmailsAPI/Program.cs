using Matgr.EmailsAPI.EmailsAPIData;
using Matgr.EmailsAPI.Extensions;
using Matgr.EmailsAPI.Repository;
using Matgr.EmailsAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Get The Connection String Value
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add services to the container.
builder.Services.AddDbContext<EmailsDbContext>(options => options.UseSqlServer(connectionString));
var OptionBuilder = new DbContextOptionsBuilder<EmailsDbContext>();
OptionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddSingleton(new EmailRepository(OptionBuilder.Options));
builder.Services.AddSingleton<Matgr.EmailsAPI.Services.IAzureServiceBusConsumer, AzureServiceBusConsumer>();
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
