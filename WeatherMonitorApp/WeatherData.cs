using System;
using System.Linq;
using Avalonia.Metadata;
using System.Collections.Generic;

public class WeatherData
{
    public double Temperature;
    public double Humidity;
    public double Pressure;

    public double getTemperature()
    {
        return Temperature;
    }

    public double getHumidity()
    {
        return Humidity;
    }
    public double getPressure()
    {
        return Pressure;
    }

}

// WeatherStation pulls data from "sensor devices"
public class WeatherStation
{
    private Random _random = new Random();

    public WeatherData measurementsChanged()
    {
        WeatherData newData = new WeatherData
        {
            Temperature = Math.Round(-5 + 30 * _random.NextDouble(), 1), // -5–25 °C
            Humidity = Math.Round(40 + 20 * _random.NextDouble(), 1),    // 40–60 %
            Pressure = Math.Round(1000 + 25 * _random.NextDouble(), 1)   // 1000–1020 hPa
        };

        return newData;
    }
    
}
