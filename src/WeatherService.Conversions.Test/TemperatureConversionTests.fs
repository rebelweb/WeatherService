module TempatureConversions.TemperatureConversionTests

open WeatherService.Types
open Xunit
open WeatherService.Conversions

[<Fact>]
let ``Convert Fahrenheit to Celsius`` () =
    Assert.Equal(0.0, TemperatureConversions.FahrenheitToCelsius(32.0))

[<Fact>]
let ``Convert Celsius to Fahrenheit`` () =
    Assert.Equal(32.0, TemperatureConversions.CelsiusToFahrenheit(0.0))

[<Fact>]
let ``Convert Celsius to Kelvin`` () =
    Assert.Equal(273.15, TemperatureConversions.CelsiusToKelvin(0))

[<Fact>]
let ``Convert Kelvin to Celsius`` () =
    Assert.Equal(0.0, TemperatureConversions.KelvinToCelsius(273.15))

[<Fact>]
let ``Convert Fahrenheit to Kelvin`` () =
    Assert.Equal(273.15, TemperatureConversions.FahrenheitToKelvin(32.0))

[<Fact>]
let ``Convert Kelvin to Fahrenheit`` () =
    Assert.Equal(32.0, TemperatureConversions.KelvinToFahrenheit(273.15))

[<Theory>]
[<InlineData(0.0, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 32.0)>]
[<InlineData(20.0, TemperatureUnit.Celsius, TemperatureUnit.Fahrenheit, 68.0)>]
[<InlineData(0.0, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 273.15)>]
[<InlineData(20.0, TemperatureUnit.Celsius, TemperatureUnit.Kelvin, 293.15)>]
[<InlineData(32.0, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 0.0)>]
[<InlineData(68.0, TemperatureUnit.Fahrenheit, TemperatureUnit.Celsius, 20.0)>]
[<InlineData(32.0, TemperatureUnit.Fahrenheit, TemperatureUnit.Kelvin, 273.15)>]
[<InlineData(68.0, TemperatureUnit.Fahrenheit, TemperatureUnit.Kelvin, 293.15)>]
[<InlineData(273.15, TemperatureUnit.Kelvin, TemperatureUnit.Celsius, 0.0)>]
[<InlineData(293.15, TemperatureUnit.Kelvin, TemperatureUnit.Celsius, 20.0)>]
[<InlineData(273.15, TemperatureUnit.Kelvin, TemperatureUnit.Fahrenheit, 32.0)>]
[<InlineData(293.15, TemperatureUnit.Kelvin, TemperatureUnit.Fahrenheit, 68.0)>]
[<InlineData(293.15, TemperatureUnit.Kelvin, TemperatureUnit.Kelvin, 293.15)>]
[<InlineData(20.0, TemperatureUnit.Celsius, TemperatureUnit.Celsius, 20.0)>]
[<InlineData(32.0, TemperatureUnit.Fahrenheit, TemperatureUnit.Fahrenheit, 32.0)>]
let ``Convert Temperatures`` (input: double, fromUnit: TemperatureUnit, toUnit: TemperatureUnit, output: double) =
    Assert.Equal(output, TemperatureConversions.CovertTemperature(input, fromUnit, toUnit))
