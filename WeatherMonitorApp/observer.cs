namespace WeatherMonitorApp
{
    public interface Observer
    {
        void update(WeatherData data);
    }
}