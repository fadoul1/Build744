namespace TemperatureConverter;

public class Temperature
{
    private readonly double _value;
    private readonly TemperatureUnit _unit;
    
    public Temperature(double value, TemperatureUnit unit)
    {
        if (unit == TemperatureUnit.Kelvin && value < 0)
        {
            throw new ArgumentException("Temperature in Kelvin cannot be negative.");
        }
            
        _value = value;
        _unit = unit;
    }
    
    public string ConvertTo(TemperatureUnit targetUnit)
    {
        Temperature convertedTemperature;
        
        if (_unit == targetUnit)
        {
            convertedTemperature = new Temperature(_value, _unit);
            return convertedTemperature.ToString();
        }
            
        // Convertir d'abord en Celsius comme unité intermédiaire
        var valueInCelsius = ConvertToCelsius();
            
        // Puis convertir de Celsius vers l'unité cible
        var convertedValue = Math.Round(ConvertFromCelsius(valueInCelsius, targetUnit), 2);
        
        convertedTemperature = new Temperature(convertedValue, targetUnit);
        return convertedTemperature.ToString();
    }
    
    private double ConvertToCelsius()
    {
        return _unit switch
        {
            TemperatureUnit.Celsius => _value,
            TemperatureUnit.Fahrenheit => (_value - 32) * 5 / 9,
            TemperatureUnit.Kelvin => _value - 273.15,
            _ => throw new ArgumentException($"Unsupported temperature unit: {_unit}")
        };
    }

    private static double ConvertFromCelsius(double celsiusValue, TemperatureUnit targetUnit)
    {
        return targetUnit switch
        {
            TemperatureUnit.Celsius => celsiusValue,
            TemperatureUnit.Fahrenheit => (celsiusValue * 9 / 5) + 32,
            TemperatureUnit.Kelvin => celsiusValue + 273.15,
            _ => throw new ArgumentException($"Unsupported temperature unit: {targetUnit}")
        };
    }

    
    public override string ToString()
    {
        var unitSymbol = _unit switch
        {
            TemperatureUnit.Celsius => "°C",
            TemperatureUnit.Fahrenheit => "°F",
            TemperatureUnit.Kelvin => " K",
            _ => ""
        };
            
        return $"{_value}{unitSymbol}";
    }
}