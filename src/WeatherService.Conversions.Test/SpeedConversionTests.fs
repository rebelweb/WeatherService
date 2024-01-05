namespace WeatherService.Conversions.Test

open System
open WeatherService.Conversions
open WeatherService.Types
open Xunit

module rec SpeedConversionTests =
    [<Fact>]
    let ``MPH to KPH`` () =
        Assert.Equal(3.21868, SpeedConversions.MphToKph(2.0))

    [<Fact>]
    let ``MPH to Knot`` () =
        Assert.Equal(0.868810, Math.Round(SpeedConversions.MphToKnot(1), 6))
    
    [<Fact>]
    let ``KPH to MPH`` () =
        Assert.Equal(2.0, SpeedConversions.KphToMph(3.21868))

    [<Fact>]
    let ``KPH to Knot`` () =
        Assert.Equal(1.07991, Math.Round(SpeedConversions.KphToKnot(2), 5))
    
    [<Fact>]
    let ``Knot to MPH`` () =
        Assert.Equal(2.3020, SpeedConversions.KnotToMph(2))
    
    [<Fact>]
    let ``Knot to KPH`` () =
        Assert.Equal(3.704, SpeedConversions.KnotToKph(2.0))
    
    
    [<Theory>]
    [<InlineData(1.0, SpeedUnit.MilesPerHour, SpeedUnit.KilometersPerHour, 1.60934)>]
    [<InlineData(1.151, SpeedUnit.MilesPerHour, SpeedUnit.Knot, 1.0)>]
    [<InlineData(1.0, SpeedUnit.KilometersPerHour, SpeedUnit.MilesPerHour, 0.62137273664980675)>]
    [<InlineData(3.704, SpeedUnit.KilometersPerHour, SpeedUnit.Knot, 2.0)>]
    [<InlineData(2.0, SpeedUnit.Knot, SpeedUnit.MilesPerHour, 2.302)>]
    [<InlineData(2.0, SpeedUnit.Knot, SpeedUnit.KilometersPerHour, 3.704)>]
    [<InlineData(1.0, SpeedUnit.MilesPerHour, SpeedUnit.MilesPerHour, 1.0)>]
    [<InlineData(1.0, SpeedUnit.KilometersPerHour, SpeedUnit.KilometersPerHour, 1.0)>]
    [<InlineData(1.0, SpeedUnit.Knot, SpeedUnit.Knot, 1.0)>]
    let ``Convert Speeds`` (input: double, fromUnit: SpeedUnit, toUnit: SpeedUnit, output: double) =
        Assert.Equal(output, SpeedConversions.ConvertSpeed(input, fromUnit, toUnit))
