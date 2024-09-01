using jlmoll.HexaTemplate.Application.Weather;
using Microsoft.AspNetCore.Mvc;

namespace Adapptables.AdapptableBackend.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _service;

    public WeatherController(IWeatherService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public Task<int> Get(Guid id)
    {
        return Task.FromResult(1);
    }
}
