using jlmoll.HexaTemplate.Domain.Weather;

namespace jlmoll.HexaTemplate.Application.Weather.Forecast;

public class WeatherForecastRequestHandler : IWeatherForecastRequestHandler
{
    private readonly IWeatherService _weatherService;

    public WeatherForecastRequestHandler(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IEnumerable<DailySummary>> Handle(WeatherForecastQuery query, CancellationToken cancellationToken)
    {
        return await _weatherService.GetWeatherForecastAsync(query);
    }
}