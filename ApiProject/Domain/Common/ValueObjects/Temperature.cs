namespace jlmoll.HexaTemplate.Domain.Common.ValueObjects;
public record Temperature
{
    public double Value { get; init; }
    public TemperatureUnit Unit { get; init; }

    public Temperature(double value, TemperatureUnit unit)
    {
        Value = value;
        Unit = unit;
    }

    public Temperature ConvertTo(TemperatureUnit unit)
    {
        if (Unit == unit)
        {
            return this;
        }

        var value = unit switch
        {
            TemperatureUnit.Celsius => ConvertToCelsius(),
            TemperatureUnit.Fahrenheit => ConvertToFahrenheit(),
            _ => throw new ArgumentOutOfRangeException(nameof(unit))
        };

        return new Temperature(value, unit);
    }

    private double ConvertToCelsius() => Unit switch
    {
        TemperatureUnit.Celsius => Value,
        TemperatureUnit.Fahrenheit => (Value - 32) * 5 / 9,
        _ => throw new ArgumentOutOfRangeException(nameof(Unit))
    };

    private double ConvertToFahrenheit() => Unit switch
    {
        TemperatureUnit.Celsius => Value * 9 / 5 + 32,
        TemperatureUnit.Fahrenheit => Value,
        _ => throw new ArgumentOutOfRangeException(nameof(Unit))
    };
}