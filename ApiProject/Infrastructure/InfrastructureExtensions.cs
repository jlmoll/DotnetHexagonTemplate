using jlmoll.HexaTemplate.Application.Weather;
using jlmoll.HexaTemplate.Infrastructure.ExternalWeatherService;
using jlmoll.HexaTemplate.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jlmoll.HexaTemplate.Infrastructure;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureApplication(configuration);
        services.AddScoped<IWeatherAdapter, ExternalWeatherConnectorMock>();
    }
}