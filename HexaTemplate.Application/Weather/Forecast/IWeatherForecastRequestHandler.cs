using jlmoll.HexaTemplate.Application.Common;
using jlmoll.HexaTemplate.Dto.Weather.Forecast;

namespace jlmoll.HexaTemplate.Application.Weather.Forecast;

public interface IWeatherForecastRequestHandler : IRequestHandler<WeatherForecastRequest, WeatherForecastResponse>
{
}