namespace jlmoll.HexaTemplate.Dto.Weather.History;

public record WeatherHistoryRequest
{
    public DateTime Date { get; init; }
    public string Latitude { get; init; }
    public string Longitude { get; init; }
    public string TemperatureUnit { get; init; }
    public string SpeedUnit { get; init; }
}