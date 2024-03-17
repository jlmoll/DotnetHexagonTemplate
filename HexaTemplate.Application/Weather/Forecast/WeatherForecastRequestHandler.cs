using HexaTemplate.Application.Weather.Forecast;
using jlmoll.HexaTemplate.Application.Common;
using jlmoll.HexaTemplate.Domain.Common.ValueObjects;
using jlmoll.HexaTemplate.Domain.Weather;
using jlmoll.HexaTemplate.Dto.Weather.Common;
using jlmoll.HexaTemplate.Dto.Weather.Forecast;

namespace jlmoll.HexaTemplate.Application.Weather.Forecast;

public class WeatherForecastRequestHandler : IWeatherForecastRequestHandler
{
    private readonly IWeatherService _weatherService;

    public WeatherForecastRequestHandler(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<WeatherForecastResponse> Handle(WeatherForecastRequest request, CancellationToken cancellationToken)
    {
        var query = new WeatherForecastQuery
        {
            DateFrom = request.DateFrom,
            DateTo = request.DateTo,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            TemperatureUnit = MapTemperatureUnit(request.TemperatureUnit),
            SpeedUnit = MapSpeedUnit(request.SpeedUnit)
        };
        var forecast = await _weatherService.GetWeatherForecastAsync(query);
        return new WeatherForecastResponse
        {
            DailySummaries = forecast.Select(x => Convert(x)).ToList()
        };
    }

    private TemperatureUnit MapTemperatureUnit(string unit) => unit switch
    {
        TemperatureUnitConstants.Celsius => TemperatureUnit.Celsius,
        TemperatureUnitConstants.Fahrenheit => TemperatureUnit.Fahrenheit,
        _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, "Invalid temperature unit")
    };

    private SpeedUnit MapSpeedUnit(string unit) => unit switch
    {
        SpeedUnitConstants.KilometersPerHour => SpeedUnit.KilometersPerHour,
        SpeedUnitConstants.MilesPerHour => SpeedUnit.MilesPerHour,
        SpeedUnitConstants.MetersPerSecond => SpeedUnit.MetersPerSecond,
        _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, "Invalid speed unit")
    };

    private DailySummaryDto Convert(DailySummary summary) => new DailySummaryDto
    {
        Date = summary.Date,
        TemperatureHigh = summary.Temperature.Max.Value,
        TemperatureLow = summary.Temperature.Min.Value,
        TemperatureMean = summary.Temperature.Max.Value,
        WindSpeed = summary.Wind.Speed.Value,
        WindDirection = summary.Wind.Direction.ToString(),
    };
}