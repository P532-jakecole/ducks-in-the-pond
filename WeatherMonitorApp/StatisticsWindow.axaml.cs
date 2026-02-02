using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.ComponentModel.Design;
using System.Reflection;

namespace WeatherMonitorApp
{

    public partial class StatisticsWindow : UserControl
    {
        private WeatherStation _station = new WeatherStation();

        private double avgTemp;
        private int avgCount = 0;

        private double minTemp = double.PositiveInfinity;

        private double maxTemp = double.NegativeInfinity;


        public StatisticsWindow(WeatherStation station)
        {
            InitializeComponent();

            _station = station;

        }

        public void UpdateStatisticsDisplay(WeatherData data)
        {
            double tempData = data.Temperature;
            if (avgCount == 0)
            {
                avgTemp = tempData;
            }
            else
            {
                avgTemp = Math.Round(((avgTemp * avgCount) + tempData) / (avgCount+1), 4);
            }
            avgCount += 1;

            minTemp = Math.Min(minTemp, data.Temperature);
            maxTemp = Math.Max(maxTemp, data.Temperature);

            AvgTempText.Text = $"Avg. Temp: {Math.Round(avgTemp, 2)} °C";
            MinTempText.Text = $"Min. Temp: {minTemp} °C";
            MaxTempText.Text = $"Max Temp: {maxTemp} °C";
        }

    }
}