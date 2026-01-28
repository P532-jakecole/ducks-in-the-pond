using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace WeatherMonitorApp
{
    // WeatherData object to store readings
    public class WeatherData
    {
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
    }

    // WeatherStation pulls data from "sensor devices"
    public class WeatherStation
    {
        private Random _random = new Random();

        public WeatherData GetWeatherData()
        {
            // Simulate reading from sensors
            return new WeatherData
            {
                Temperature = Math.Round(15 + 10 * _random.NextDouble(), 1), // 15–25 °C
                Humidity = Math.Round(40 + 20 * _random.NextDouble(), 1),    // 40–60 %
                Pressure = Math.Round(1000 + 20 * _random.NextDouble(), 1)   // 1000–1020 hPa
            };
        }
    }

    public partial class MainWindow : Window
    {
        private WeatherStation _station = new WeatherStation();

        public MainWindow()
        {
            InitializeComponent();

            RefreshButton.Click += RefreshButton_Click;

            // Initial load
            UpdateWeatherDisplay();
        }

        private void RefreshButton_Click(object? sender, RoutedEventArgs e)
        {
            UpdateWeatherDisplay();
        }

        private void UpdateWeatherDisplay()
        {
            var data = _station.GetWeatherData();
            TemperatureText.Text = $"Temperature: {data.Temperature} °C";
            HumidityText.Text = $"Humidity: {data.Humidity} %";
            PressureText.Text = $"Pressure: {data.Pressure} hPa";
        }
    }
}
