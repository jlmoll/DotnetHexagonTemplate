namespace jlmoll.HexaTemplate.Domain.Weather;
public class DailySummary
{
    public DateTime Date { get; init; }
    public TemperatureStats Temperature { get; init; }
    public Wind Wind { get; init; }
}