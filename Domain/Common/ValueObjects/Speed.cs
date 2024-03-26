namespace jlmoll.HexaTemplate.Domain.Common.ValueObjects;

public record Speed
{
    public double Value { get; init; }
    public SpeedUnit Unit { get; init; }

    public Speed(double value, SpeedUnit unit)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);

        Value = value;
        Unit = unit;
    }

    public Speed ConvertTo(SpeedUnit unit)
    {
        if (Unit == unit)
        {
            return this;
        }

        var value = unit switch
        {
            SpeedUnit.MetersPerSecond => ConvertToMetersPerSecond(),
            SpeedUnit.KilometersPerHour => ConvertToKilometersPerHour(),
            SpeedUnit.MilesPerHour => ConvertToMilesPerHour(),
            _ => throw new ArgumentOutOfRangeException(nameof(unit))
        };

        return new Speed(value, unit);
    }

    private double ConvertToMetersPerSecond() => Unit switch
    {
        SpeedUnit.MetersPerSecond => Value,
        SpeedUnit.KilometersPerHour => Value / 3.6,
        SpeedUnit.MilesPerHour => Value / 2.237,
        _ => throw new ArgumentOutOfRangeException(nameof(Unit))
    };

    private double ConvertToKilometersPerHour() => Unit switch
    {
        SpeedUnit.MetersPerSecond => Value * 3.6,
        SpeedUnit.KilometersPerHour => Value,
        SpeedUnit.MilesPerHour => Value * 1.609,
        _ => throw new ArgumentOutOfRangeException(nameof(Unit))
    };

    private double ConvertToMilesPerHour() => Unit switch
    {
        SpeedUnit.MetersPerSecond => Value * 2.237,
        SpeedUnit.KilometersPerHour => Value / 1.609,
        SpeedUnit.MilesPerHour => Value,
        _ => throw new ArgumentOutOfRangeException(nameof(Unit))
    };
}