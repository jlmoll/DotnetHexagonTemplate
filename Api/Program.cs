using AutoMapper;
using FluentValidation;
using jlmoll.HexaTemplate.Application.Weather.Forecast;
using jlmoll.HexaTemplate.Api.Validators;
using jlmoll.HexaTemplate.Dto.Weather.Common;
using jlmoll.HexaTemplate.Dto.Weather.Forecast;
using jlmoll.HexaTemplate.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<IValidator<WeatherForecastRequest>, WeatherForecastRequestValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapPost("/weatherforecast", async (WeatherForecastRequest rq, IMapper mapper, IWeatherForecastRequestHandler handler, IValidator<WeatherForecastRequest> validator) =>
{
    await validator.ValidateAndThrowAsync(rq);
    return new WeatherForecastResponse { DailySummaries = (await handler.Handle(mapper.Map<WeatherForecastQuery>(rq), new CancellationToken())).Select(x => mapper.Map<DailySummaryDto>(x)).ToList() };
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();