using TemperatureConverter;

namespace TemperatureConverterTests;

public class TemperatureConverterShould
{
    [Theory]
    [InlineData(0, "32°F")]
    public void ConvertCelsiusToFahrenheit(double celsius, string expectedFahrenheit)
    {
        var temperature = new Temperature(celsius, TemperatureUnit.Celsius);

        var result = temperature.ConvertTo(TemperatureUnit.Fahrenheit);

        Assert.Equal(expectedFahrenheit, result);
    }
    
    [Theory]
    [InlineData(212, "100°C")]
    public void ConvertFahrenheitToCelsius(double fahrenheit, string expectedCelsius)
    {
        var temperature = new Temperature(fahrenheit, TemperatureUnit.Fahrenheit);

        var result = temperature.ConvertTo(TemperatureUnit.Celsius);

        Assert.Equal(expectedCelsius, result);
    }
    
    [Theory]
    [InlineData(100, "373,15 K")]
    public void ConvertCelsiusToKelvin(double celsius, string expectedKelvin)
    {
        var temperature = new Temperature(celsius, TemperatureUnit.Celsius);

        var result = temperature.ConvertTo(TemperatureUnit.Kelvin);

        Assert.Equal(expectedKelvin, result);
    }
    
    [Theory]
    [InlineData(0, "-459,67°F")]
    public void ConvertKelvinToFahrenheit(double kelvin, string expectedFahrenheit)
    {
        var temperature = new Temperature(kelvin, TemperatureUnit.Kelvin);

        var result = temperature.ConvertTo(TemperatureUnit.Fahrenheit);

        Assert.Equal(expectedFahrenheit, result);
    }
    
    [Theory]
    [InlineData(32, "273,15 K")]
    public void ConvertFahrenheitToKelvin(double fahrenheit, string expectedKelvin)
    {
        var temperature = new Temperature(fahrenheit, TemperatureUnit.Fahrenheit);

        var result = temperature.ConvertTo(TemperatureUnit.Kelvin);

        Assert.Equal(expectedKelvin, result);
    }
    
    [Fact]
    public void ThrowExceptionWhenKelvinIsNegative()
    {
        var exception = Assert.Throws<ArgumentException>(() => 
            new Temperature(-10, TemperatureUnit.Kelvin));
        
        Assert.Contains("cannot be negative", exception.Message);
    }
    
    [Theory]
    [InlineData(25, "25°C")]
    [InlineData(32, "32°F")]
    [InlineData(0, "0 K")]
    public void ReturnSameTemperatureWhenConvertingToSameUnit(double value, string expectedResult)
    {
        var unit = expectedResult.EndsWith("°C") ? TemperatureUnit.Celsius :
                   expectedResult.EndsWith("°F") ? TemperatureUnit.Fahrenheit :
                   TemperatureUnit.Kelvin;

        var temperature = new Temperature(value, unit);

        var result = temperature.ConvertTo(unit);

        Assert.Equal(expectedResult, result);
    }
    
    [Fact]
    public void FormatTemperatureCorrectly()
    {
        var celsius = new Temperature(25, TemperatureUnit.Celsius);
        var fahrenheit = new Temperature(98.6, TemperatureUnit.Fahrenheit);
        var kelvin = new Temperature(310, TemperatureUnit.Kelvin);

        Assert.Equal("25°C", celsius.ToString());
        Assert.Equal("98,6°F", fahrenheit.ToString());
        Assert.Equal("310 K", kelvin.ToString());
    }
}