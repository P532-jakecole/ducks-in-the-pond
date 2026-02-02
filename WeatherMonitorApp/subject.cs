namespace WeatherMonitorApp
{
interface Subject
{
    void registerObserver(Observer observer);

    void removeObserver();

    void notifyObserver();
}
}