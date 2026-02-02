using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Linq;

namespace WeatherMonitorApp
{

    public partial class CurrentConditionsWindow : UserControl
    {
        private WeatherStation _station = new WeatherStation();

        public CurrentConditionsWindow(WeatherStation station)
        {
            InitializeComponent();

            _station = station;

        }

        public void UpdateWeatherDisplay(WeatherData data)
        {
            TemperatureText.Text = $"Temperature: {data.Temperature} °C";
            HumidityText.Text = $"Humidity: {data.Humidity} %";
            PressureText.Text = $"Pressure: {data.Pressure} hPa";
       }
    }
}