using SatelliteTelemetryAnalyzerApi.Repositories;
using SatelliteTelemetryAnalyzerApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISatelliteRepository, SatelliteRepository>();
builder.Services.AddSingleton<ITelemetryRepository, TelemetryRepository>();
builder.Services.AddScoped<ITelemetryService, TelemetryService>();

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

app.Run();
