using jlmoll.HexaTemplate.Application.Common;
using jlmoll.HexaTemplate.Application.Weather;
using jlmoll.HexaTemplate.Application.Weather.Forecast;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jlmoll.HexaTemplate.Application;

public static class ApplicationExtensions
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IWeatherService, WeatherService>();
        services.AddScoped<IWeatherForecastRequestHandler, WeatherForecastRequestHandler>();
    }
}
