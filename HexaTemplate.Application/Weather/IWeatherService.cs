using HexaTemplate.Application.Weather.Forecast;
using jlmoll.HexaTemplate.Domain.Weather;

namespace jlmoll.HexaTemplate.Application.Weather;
public interface IWeatherService
{
    Task<IEnumerable<DailySummary>> GetWeatherForecastAsync(WeatherForecastQuery query);
    Task<DailySummary> GetWeatherHistoryAsync(WeatherHistoryQuery query);
}