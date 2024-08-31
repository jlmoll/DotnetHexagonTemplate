using jlmoll.HexaTemplate.Dto.Weather.Common;

namespace jlmoll.HexaTemplate.Dto.Weather.Forecast;

public record WeatherForecastResponse
{
    public List<DailySummaryDto> DailySummaries { get; init; }
}