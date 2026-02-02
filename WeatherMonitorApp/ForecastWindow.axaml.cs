using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.ComponentModel.Design;
using System.Reflection;

namespace WeatherMonitorApp
{

    public partial class ForecastWindow : UserControl
    {
        private WeatherStation _station = new WeatherStation();

        public ForecastWindow(WeatherStation station)
        {
            InitializeComponent();

            _station = station;

        }

        public void UpdateForecastDisplay(WeatherData data)
        {
            string forecast;
            double pressure = data.getPressure();
            double temp = data.getTemperature();

            if (pressure < 1008)
            {
                if (temp < 0)
                {
                    forecast = "Snowing";
                }
                else
                {
                    forecast = "Raining";
                }
            }else if ( pressure > 1018)
            {
                forecast = "Clear Skies";
            }
            else
            {
                forecast = "Partly Cloudy";
            }

            ForecastText.Text = $"Forecast for Today: {forecast}";

        }

    }
}