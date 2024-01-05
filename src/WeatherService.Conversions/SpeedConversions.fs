namespace WeatherService.Conversions

open WeatherService.Types

module SpeedConversions =
    let MphToKph (speed: double) =
        speed * 1.60934

    let MphToKnot (speed: double) =
        speed / 1.151
    
    let KphToMph (speed: double) =
        speed / 1.60934

    let KphToKnot (speed: double) =
        speed / 1.852
    
    let KnotToMph (speed: double) =
        speed * 1.151
    
    let KnotToKph (speed: double) =
        speed * 1.852
    
    let ConvertSpeed (speed: double, fromUnit: SpeedUnit, toUnit: SpeedUnit) =
        match (fromUnit, toUnit) with
            | SpeedUnit.MilesPerHour, SpeedUnit.KilometersPerHour -> MphToKph(speed)
            | SpeedUnit.MilesPerHour, SpeedUnit.Knot -> MphToKnot(speed)
            | SpeedUnit.KilometersPerHour, SpeedUnit.MilesPerHour -> KphToMph(speed)
            | SpeedUnit.KilometersPerHour, SpeedUnit.Knot -> KphToKnot(speed)
            | SpeedUnit.Knot, SpeedUnit.MilesPerHour -> KnotToMph(speed)
            | SpeedUnit.Knot, SpeedUnit.KilometersPerHour -> KnotToKph(speed)
            | SpeedUnit.KilometersPerHour, SpeedUnit.KilometersPerHour -> speed
            | SpeedUnit.MilesPerHour, SpeedUnit.MilesPerHour -> speed
            | SpeedUnit.Knot, SpeedUnit.Knot -> speed 
            | _ -> 0.0
