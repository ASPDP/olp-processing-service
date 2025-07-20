using Asp.Versioning;
using Olp.ProcessingService.Infrastructure.EntityFramework.Extensions;
using Olp.ProcessingService.Services.Abstractions.Clients;
using Olp.ProcessingService.Services.Implementation.Clients;
using Olp.ProcessingService.WebApi.EventBus;
using Olp.ProcessingService.WebApi.Extensions;
using Olp.RabbitMqTools.Infrastructure.EventBus.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add logging
builder.Logging.AddSimpleConsole(c => c.SingleLine = true);

// Add settings
var appSettings = builder.Configuration.GetAppSettings();
builder.Services
    .AddSingleton(appSettings);

builder.Services
    .AddPostgresContext(appSettings.DbSettings)
    .AddEventBus(appSettings.RabbitMqOptions, KnownEventHandlers.Types)
    .AddRepositories()
    .AddServices();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApiVersioning(config =>
{
    config.ApiVersionReader = new HeaderApiVersionReader("api-version");
    config.DefaultApiVersion = new ApiVersion(1, 0);
    config.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddHttpClient<IProposalServiceClient, ProposalServiceClient>(client =>
{
    client.BaseAddress = appSettings.ProposalServiceSettings.BaseAddress();
});

var app = builder.Build();

// Initialize database
await app.InitDatabaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseEventBus();

app.Run();
