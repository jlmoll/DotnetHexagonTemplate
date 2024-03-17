using jlmoll.HexaTemplate.Domain.Common.ValueObjects;

namespace HexaTemplate.Application.Weather.Forecast;

public class WeatherForecastQuery
{
    public DateTime DateFrom { get; init; }
    public DateTime DateTo { get; init; }
    public string Latitude { get; init; }
    public string Longitude { get; init; }
    public TemperatureUnit TemperatureUnit { get; init; }
    public SpeedUnit SpeedUnit { get; init; }
}