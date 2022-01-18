using Newtonsoft.Json;
using WeatherAPI.Model;

namespace WeatherAPI.Utility
{
    public class Deserialize
    {
        public DeserializedWeatherData ConvertToDeserializedWeatherData(string apiResponse)
        {
            Rawpacket input = JsonConvert.DeserializeObject<Rawpacket>(apiResponse);        // get response content
            DeserializedWeatherData rs = new DeserializedWeatherData();
            rs.Model_id = input.Model_id;
            rs.coord = input.coord;
            rs.main = input.main;
            rs.visibility = input.visibility;
            rs.wind = input.wind;
            rs.clouds = input.clouds;
            rs.dt = input.dt;
            rs.sys = input.sys;
            rs.timezone = input.timezone;
            rs.id = input.id;
            rs.name = input.name;
            rs.cod = input.cod;
            rs.weathers = input.weather.ToArray();
            return rs;
        }
    }
}

