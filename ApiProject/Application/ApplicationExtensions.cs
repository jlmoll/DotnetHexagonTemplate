using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace jlmoll.HexaTemplate.Application;

public static class ApplicationExtensions
{
    public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}
