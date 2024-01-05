namespace WeatherService.Conversions

open WeatherService.Types

module TemperatureConversions =
    let FahrenheitToCelsius (temp: double) =
        (temp - 32.0) * (5.0 / 9.0)
    
    let CelsiusToFahrenheit (temp: double) =
        (temp * (9.0 / 5.0)) + 32.0

    let CelsiusToKelvin (temp: double) =
        temp + 273.15
    
    let KelvinToCelsius (temp: double) =
        temp - 273.15
    
    let FahrenheitToKelvin (temp: double) =
        CelsiusToKelvin(FahrenheitToCelsius(temp))
        
    let KelvinToFahrenheit (temp: double) =
        CelsiusToFahrenheit(KelvinToCelsius(temp))
    
    let CovertTemperature (temp: double, fromUnit: TemperatureUnit, toUnit: TemperatureUnit) =
        match (fromUnit, toUnit) with
            | TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit -> CelsiusToFahrenheit(temp)
            | TemperatureUnit.Celsius, TemperatureUnit.Kelvin -> CelsiusToKelvin(temp)
            | TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius -> FahrenheitToCelsius(temp)
            | TemperatureUnit.Fahrenheit, TemperatureUnit.Kelvin -> FahrenheitToKelvin(temp)
            | TemperatureUnit.Kelvin, TemperatureUnit.Celsius -> KelvinToCelsius(temp)
            | TemperatureUnit.Kelvin, TemperatureUnit.Fahrenheit -> KelvinToFahrenheit(temp)
            | TemperatureUnit.Celsius, TemperatureUnit.Celsius -> temp
            | TemperatureUnit.Fahrenheit, TemperatureUnit.Fahrenheit -> temp
            | TemperatureUnit.Kelvin, TemperatureUnit.Kelvin -> temp
            | _ -> 0.0 
