using System.Security.Cryptography;
using HexaTemplate.Application.Weather.Forecast;
using jlmoll.HexaTemplate.Application.Weather;
using jlmoll.HexaTemplate.Domain.Common.ValueObjects;
using jlmoll.HexaTemplate.Domain.Weather;
using jlmoll.HexaTemplate.Infrastructure.ExternalWeatherService.Dto;

namespace jlmoll.HexaTemplate.Infrastructure.ExternalWeatherService;
public class ExternalWeatherConnectorMock : IWeatherAdapter
{
    public async Task<IEnumerable<DailySummary>> GetWeatherForecastAsync(WeatherForecastQuery query)
    {
        var rq = new ExternalWeatherServiceRequest
        {
            FromDate = query.DateFrom,
            UntilDate = query.DateTo,
            Lat = query.Latitude,
            Lng = query.Longitude
        };

        var rs = await MockRequest(rq);

        return rs.DayToDay.Select(x => AggregateOne(x));
    }

    public async Task<DailySummary> GetWeatherHistoryAsync(WeatherHistoryQuery query)
    {
        var rq = new ExternalWeatherServiceRequest
        {
            FromDate = query.Date,
            UntilDate = query.Date,
            Lat = query.Latitude,
            Lng = query.Longitude
        };

        var rs = await MockRequest(rq);

        return AggregateOne(rs.DayToDay.First());
    }

    private DailySummary AggregateOne(ExternalWeatherServiceDailySummary x) => new DailySummary
    {
        Date = x.Date,
        Temperature = new TemperatureStats(
                new Temperature(double.Parse(x.MinTempCelsius), TemperatureUnit.Celsius),
                new Temperature(double.Parse(x.MaxTempCelsius), TemperatureUnit.Celsius),
                new Temperature((double.Parse(x.MinTempCelsius) + double.Parse(x.MaxTempCelsius)) / 2, TemperatureUnit.Celsius)
                ),
        Wind = new Wind(new Speed(double.Parse(x.MaxWindKph), SpeedUnit.KilometersPerHour), CardinalPoint.North)
    };

    private async Task<ExternalWeatherServiceResponse> MockRequest(ExternalWeatherServiceRequest rq)
    {
        var response = new ExternalWeatherServiceResponse
        {
            DayToDay = Enumerable
                .Range(0, 1 + rq.UntilDate.Subtract(rq.FromDate).Days)
                .Select(offset => rq.FromDate.AddDays(offset))
                .Select(x => MockOne(x)).ToList()
        };

        return await Task.FromResult(response);
    }

    private ExternalWeatherServiceDailySummary MockOne(DateTime date)
    {
        var rng = new Random();
        return new ExternalWeatherServiceDailySummary
        {
            Date = date,
            MaxTempCelsius = rng.Next(20, 40).ToString(),
            MinTempCelsius = rng.Next(-10, 20).ToString(),
            MaxWindKph = rng.Next(0, 120).ToString(),
            WindDir = "N"
        };
    }

}