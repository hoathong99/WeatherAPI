using static WeatherAPI.Model.DeserializedWeatherData;

namespace WeatherAPI.Model
{
    public class Rawpacket
    {
        public int Model_id { get; set; }
        public _coord coord { get; set; }
        public _weather[] weather { get; set; }
        public _main main { get; set; }
        public int visibility { get; set; }
        public _wind wind { get; set; }
        public _cloud clouds { get; set; }
        public int dt { get; set; }
        public _sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }
}
