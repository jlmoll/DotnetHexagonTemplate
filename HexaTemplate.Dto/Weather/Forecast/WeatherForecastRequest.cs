namespace jlmoll.HexaTemplate.Dto.Weather.Forecast;

public record WeatherForecastRequest
{
    public DateTime DateFrom { get; init; }
    public DateTime DateTo { get; init; }
    public string Latitude { get; init; }
    public string Longitude { get; init; }
    public string TemperatureUnit { get; init; }
    public string SpeedUnit { get; init; }
}