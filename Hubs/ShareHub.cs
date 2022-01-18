using Microsoft.AspNetCore.SignalR;
using WeatherAPI.Model;
namespace WeatherAPI.Hubs
{
    public class ShareHub : Hub<IShareHub>
    {
        public async Task ReceivedWeatherData(DeserializedWeatherData data)
        {
            //await Clients.All.SendAsync("NewWeatherDataReceived", data);
            await Clients.All.ReceivedWeatherData(data);
        }
    }
}
