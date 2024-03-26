using System.ComponentModel.DataAnnotations;
using jlmoll.HexaTemplate.Domain.Common.ValueObjects;

namespace jlmoll.HexaTemplate.Domain.Weather;

public record TemperatureStats
{
    public Temperature Min { get; init; }
    public Temperature Max { get; init; }
    public Temperature Average { get; init; }

    public TemperatureStats(Temperature min, Temperature max, Temperature average)
    {
        if (min.ConvertTo(TemperatureUnit.Celsius).Value > max.ConvertTo(TemperatureUnit.Celsius).Value)
        {
            throw new ValidationException("Min temperature cannot be greater than max temperature");
        }
        if (min.ConvertTo(TemperatureUnit.Celsius).Value > average.ConvertTo(TemperatureUnit.Celsius).Value)
        {
            throw new ValidationException("Min temperature cannot be greater than average temperature");
        }
        if (max.ConvertTo(TemperatureUnit.Celsius).Value < average.ConvertTo(TemperatureUnit.Celsius).Value)
        {
            throw new ValidationException("Max temperature cannot be less than average temperature");
        }

        Min = min;
        Max = max;
        Average = average;
    }

    public TemperatureStats ConvertTo(TemperatureUnit unit) =>
        new(Min.ConvertTo(unit), Max.ConvertTo(unit), Average.ConvertTo(unit));

}