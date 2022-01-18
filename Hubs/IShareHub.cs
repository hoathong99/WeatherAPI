using WeatherAPI.Model;

namespace WeatherAPI.Hubs
{
    public interface IShareHub
    {
        Task ReceivedWeatherData(DeserializedWeatherData data);
    }
}
