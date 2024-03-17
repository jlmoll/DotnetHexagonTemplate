namespace jlmoll.HexaTemplate.Dto.Weather.Common;
public record DailySummaryDto
{
    public DateTime Date { get; set; }
    public double TemperatureHigh { get; set; }
    public double TemperatureLow { get; set; }
    public double TemperatureMean { get; set; }
    public double WindSpeed { get; set; }
    public string WindDirection { get; set; }
}