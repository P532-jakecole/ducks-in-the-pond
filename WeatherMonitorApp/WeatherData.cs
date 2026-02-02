using System;
using System.Linq;
using Avalonia.Metadata;
using System.Collections.Generic;
using Avalonia.Controls;
using Tmds.DBus.Protocol;
using WeatherMonitorApp;

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
public class WeatherStation: Subject
{
    private Random _random = new Random();

    List<Observer> subscribedDisplays = new List<Observer>();

    private WeatherData getMeasurements()
    {
        WeatherData newData = new WeatherData
        {
            Temperature = Math.Round(-5 + 30 * _random.NextDouble(), 1), // -5–25 °C
            Humidity = Math.Round(40 + 20 * _random.NextDouble(), 1),    // 40–60 %
            Pressure = Math.Round(1000 + 25 * _random.NextDouble(), 1)   // 1000–1020 hPa
        };

        return newData;
    }

    public void measurementsChanged()
    {
        notifyObserver();
    }

    public void notifyObserver()
    {
        var data = getMeasurements();
        foreach (Observer observer in subscribedDisplays){
            observer.update(data);
        }
    }

    public void registerObserver(Observer observer)
    {
        subscribedDisplays.Add(observer);
    }

    public void removeObserver()
    {
        throw new NotImplementedException();
    }
}
