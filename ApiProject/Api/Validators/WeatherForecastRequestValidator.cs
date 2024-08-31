using FluentValidation;
using jlmoll.HexaTemplate.Dto.Weather.Common;
using jlmoll.HexaTemplate.Dto.Weather.Forecast;

namespace jlmoll.HexaTemplate.Api.Validators;

public class WeatherForecastRequestValidator : AbstractValidator<WeatherForecastRequest>
{
    public WeatherForecastRequestValidator()
    {
        RuleFor(x => x.DateFrom).NotEmpty();
        RuleFor(x => x.DateTo).NotEmpty();
        RuleFor(x => x.Latitude).NotEmpty();
        RuleFor(x => x.Longitude).NotEmpty();
        RuleFor(x => x.DateFrom).LessThanOrEqualTo(x => x.DateTo);
        RuleFor(x => x.TemperatureUnit).Must(x => x == TemperatureUnitConstants.Celsius || x == TemperatureUnitConstants.Fahrenheit);
        RuleFor(x => x.SpeedUnit).Must(x => x == SpeedUnitConstants.MilesPerHour || x == SpeedUnitConstants.KilometersPerHour || x == SpeedUnitConstants.MetersPerSecond);
    }
}