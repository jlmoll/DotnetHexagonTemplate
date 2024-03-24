using jlmoll.HexaTemplate.Application.Common;
using jlmoll.HexaTemplate.Domain.Weather;

namespace jlmoll.HexaTemplate.Application.Weather.Forecast;

public interface IWeatherForecastRequestHandler : IRequestHandler<WeatherForecastQuery, IEnumerable<DailySummary>>
{
}