using jlmoll.HexaTemplate.Domain.Common.ValueObjects;

namespace jlmoll.HexaTemplate.Domain.Weather;

public record Wind(Speed Speed, CardinalPoint Direction);