using Avalonia.Controls;
using Avalonia.Interactivity;
using System;

namespace WeatherMonitorApp
{
    // WeatherData object to store readings

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
