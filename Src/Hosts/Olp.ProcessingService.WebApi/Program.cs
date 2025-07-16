using Microsoft.Extensions.Configuration;
using Olp.ProcessingService.WebApi.Settings;

using Olp.ProcessingService.Infrastructure.EntityFramework.Extensions;
using Olp.ProcessingService.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add logging
builder.Logging.AddSimpleConsole(c => c.SingleLine = true);

// Add settings
var appSettings = builder.Configuration.GetAppSettings();
builder.Services
    .AddSingleton(appSettings);

builder.Services
    .AddPostgresContext(appSettings.DbSettings)
    .AddRepositories()
    .AddServices();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
