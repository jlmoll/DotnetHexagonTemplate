using AutoMapper;
using jlmoll.HexaTemplate.Application.Weather.Forecast;
using jlmoll.HexaTemplate.Domain.Common.ValueObjects;
using jlmoll.HexaTemplate.Domain.Weather;
using jlmoll.HexaTemplate.Dto.Weather.Common;
using jlmoll.HexaTemplate.Dto.Weather.Forecast;

namespace HexaTemplate.Api.Profiles;
public class WeatherControllerProfile : Profile
{
    public WeatherControllerProfile()
    {
        CreateMap<WeatherForecastRequest, WeatherForecastQuery>()
            .ForMember(dest => dest.TemperatureUnit, opt => opt.MapFrom(src => MapTemperatureUnit(src.TemperatureUnit)))
            .ForMember(dest => dest.SpeedUnit, opt => opt.MapFrom(src => MapSpeedUnit(src.SpeedUnit)));

        CreateMap<DailySummary, DailySummaryDto>()
            .ForMember(dest => dest.TemperatureHigh, opt => opt.MapFrom(src => src.Temperature.Max.Value))
            .ForMember(dest => dest.TemperatureLow, opt => opt.MapFrom(src => src.Temperature.Min.Value))
            .ForMember(dest => dest.TemperatureMean, opt => opt.MapFrom(src => src.Temperature.Max.Value))
            .ForMember(dest => dest.WindSpeed, opt => opt.MapFrom(src => src.Wind.Speed.Value))
            .ForMember(dest => dest.WindDirection, opt => opt.MapFrom(src => src.Wind.Direction.ToString()));
    }

    private static TemperatureUnit MapTemperatureUnit(string unit) => unit switch
    {
        TemperatureUnitConstants.Celsius => TemperatureUnit.Celsius,
        TemperatureUnitConstants.Fahrenheit => TemperatureUnit.Fahrenheit,
        _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, "Invalid temperature unit")
    };

    private static SpeedUnit MapSpeedUnit(string unit) => unit switch
    {
        SpeedUnitConstants.KilometersPerHour => SpeedUnit.KilometersPerHour,
        SpeedUnitConstants.MilesPerHour => SpeedUnit.MilesPerHour,
        SpeedUnitConstants.MetersPerSecond => SpeedUnit.MetersPerSecond,
        _ => throw new ArgumentOutOfRangeException(nameof(unit), unit, "Invalid speed unit")
    };
}