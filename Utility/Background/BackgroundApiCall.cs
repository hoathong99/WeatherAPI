using WeatherAPI.Model;
using WeatherAPI.Data;

namespace WeatherAPI.Utility.Background
{
    public class BackgroundApiCall : BackgroundService
    {
        public BackgroundApiCall(IServiceScopeFactory scopeFactory) : base(scopeFactory)
        {
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {

            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var _context = scope.ServiceProvider.GetRequiredService<WeatherAPIContext>();

                    Console.WriteLine("[IncomingEthTxService] Service is Running");

                    // Run something
                    string api = "http://api.openweathermap.org/data/2.5/weather?id=1562822&appid=ca86f2f359eb1e4afef8ff6a2e1d1559";   
                    //
                    HttpClient client = new HttpClient();
                    HttpResponseMessage response = await client.GetAsync(api);
                    string apiResponse = await response.Content.ReadAsStringAsync();

                    Deserialize utility = new Deserialize();
                    DeserializedWeatherData data = utility.ConvertToDeserializedWeatherData(apiResponse);
                    _context.Add(data);
                    await _context.SaveChangesAsync();

                    //--------------

                    await Task.Delay(4, stoppingToken);             // delay task every 1s
                }
            }
        }
    }
}
