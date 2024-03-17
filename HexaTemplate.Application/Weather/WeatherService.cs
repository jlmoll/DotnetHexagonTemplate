using HexaTemplate.Application.Weather.Forecast;
using jlmoll.HexaTemplate.Domain.Weather;

namespace jlmoll.HexaTemplate.Application.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IWeatherAdapter _weatherAdapter;
        public WeatherService(IWeatherAdapter weatherAdapter)
        {
            _weatherAdapter = weatherAdapter;
        }

        public async Task<IEnumerable<DailySummary>> GetWeatherForecastAsync(WeatherForecastQuery query)
        {
            return await _weatherAdapter.GetWeatherForecastAsync(query);
        }

        public async Task<DailySummary> GetWeatherHistoryAsync(WeatherHistoryQuery query)
        {
            return await _weatherAdapter.GetWeatherHistoryAsync(query);
        }
    }
}