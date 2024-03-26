namespace jlmoll.HexaTemplate.Infrastructure.ExternalWeatherService.Dto;
public record ExternalWeatherServiceRequest
{
    public DateTime FromDate { get; init; }
    public DateTime UntilDate { get; init; }
    public string Lat { get; init; }
    public string Lng { get; init; }
}