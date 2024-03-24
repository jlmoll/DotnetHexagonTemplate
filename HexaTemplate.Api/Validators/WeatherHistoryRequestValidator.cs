using FluentValidation;
using jlmoll.HexaTemplate.Dto.Weather.Common;
using jlmoll.HexaTemplate.Dto.Weather.History;

namespace jlmoll.HexaTemplate.Api.Validators;

public class WeatherHistoryRequestValidator : AbstractValidator<WeatherHistoryRequest>
{
    public WeatherHistoryRequestValidator()
    {
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.Date).LessThan(DateTime.Now);
        RuleFor(x => x.Latitude).NotEmpty();
        RuleFor(x => x.Longitude).NotEmpty();
        RuleFor(x => x.TemperatureUnit).Must(x => x == TemperatureUnitConstants.Celsius || x == TemperatureUnitConstants.Fahrenheit);
        RuleFor(x => x.SpeedUnit).Must(x => x == SpeedUnitConstants.MilesPerHour || x == SpeedUnitConstants.KilometersPerHour || x == SpeedUnitConstants.MetersPerSecond);
    }
}