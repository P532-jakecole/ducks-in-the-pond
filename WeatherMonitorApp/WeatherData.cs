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
