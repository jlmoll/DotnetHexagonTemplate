namespace jlmoll.HexaTemplate.Infrastructure.ExternalWeatherService.Dto;

public record ExternalWeatherServiceResponse
{
    public List<ExternalWeatherServiceDailySummary> DayToDay { get; init; }
}

public record ExternalWeatherServiceDailySummary
{
    public DateTime Date { get; init; }
    public string MaxTempCelsius { get; init; }
    public string MinTempCelsius { get; init; }
    public string MaxWindKph { get; init; }
    public string TotalPrecipMm { get; init; }
    public string AvgVisKm { get; init; }
    public string WindDir { get; init; }

}