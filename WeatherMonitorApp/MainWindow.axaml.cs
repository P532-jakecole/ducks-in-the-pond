using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace WeatherMonitorApp
{
    // WeatherData object to store readings

    public partial class MainWindow : Window
    {
        private WeatherStation _station = new WeatherStation();
        private StatisticsWindow statWindow;
        private CurrentConditionsWindow currWindow;

        private ForecastWindow forecastWindow;

        public MainWindow()
        {
            InitializeComponent();

            statWindow = new StatisticsWindow(_station);
            currWindow = new CurrentConditionsWindow(_station);
            forecastWindow = new ForecastWindow(_station);

            DisplayContent.Content = currWindow;

            RefreshButton.Click += RefreshButton_Click;
            CurrentButton.Click += CurrentButton_Click;
            RemoveButton.Click += RemoveButton_Click;
            StatisticsButton.Click += StatisticsButton_Click;
            ForecastButton.Click += ForecastButton_Click;

            StatisticsAdd.Click += StatisticsAdd_Click;
            ForecastAdd.Click += ForecastAdd_Click;

            // Initial load
            UpdateWeatherDisplay();
        }

        private void RefreshButton_Click(object? sender, RoutedEventArgs e)
        {
            UpdateWeatherDisplay();
        }

        private void StatisticsButton_Click(object? sender, RoutedEventArgs e)
        {
            DisplayContent.Content = statWindow;
        }

        private void CurrentButton_Click(object? sender, RoutedEventArgs e)
        {
            DisplayContent.Content = currWindow;
        }

        private void ForecastButton_Click(object? sender, RoutedEventArgs e)
        {
            DisplayContent.Content = forecastWindow;
        }

        private void RemoveButton_Click(object? sender, RoutedEventArgs e)
        {
             Dictionary<string, Button[]> textBox = new()
            {
                {"ForecastWindow", [ForecastButton, ForecastAdd]},
                {"StatisticsWindow", [StatisticsButton, StatisticsAdd]}
            };

            string current = DisplayContent.Content.GetType().Name;
            if (current != "CurrentConditionsWindow")
            {
                Button[] button = textBox[current];

                button[0].IsVisible = false;
                button[1].IsVisible = true;

                DisplayContent.Content = currWindow;
            }
        }

        private void StatisticsAdd_Click(object? sender, RoutedEventArgs e)
        {
            
                StatisticsButton.IsVisible = true;
                StatisticsAdd.IsVisible = false;

                DisplayContent.Content = statWindow;
        }

        private void ForecastAdd_Click(object? sender, RoutedEventArgs e)
        {
            
                ForecastButton.IsVisible = true;
                ForecastAdd.IsVisible = false;

                DisplayContent.Content = forecastWindow;
        }

        private void UpdateWeatherDisplay()
        {
            var data = _station.measurementsChanged();
            
            statWindow.UpdateStatisticsDisplay(data);
            currWindow.UpdateWeatherDisplay(data);
            forecastWindow.UpdateForecastDisplay(data);

        }
    }
}

