using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeatherAPI.Model
{
    public class DeserializedWeatherData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Model_id { get; set; }
        public _coord coord { get; set; }
        public virtual ICollection<_weather> weathers { get; set; }
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
    public class _coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
        //------------------------------------------//  navigation
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Model_id { get; set; }
        public int weatherdata_id { get; set; }
        public DeserializedWeatherData weatherdata { get; set; }

    }
    public class _weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
        //------------------------------------------//  navigation
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Model_id { get; set; }
        [ForeignKey("DeserializedWeatherData")]
        public int weatherdata_id { get; set; }
        public DeserializedWeatherData weatherdata { get; set; }
    }
    public class _main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
        //------------------------------------------//  navigation
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Model_id { get; set; }
        public int weatherdata_id { get; set; }
        public DeserializedWeatherData weatherdata { get; set; }
    }
    public class _wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
        public double gust { get; set; }
        //------------------------------------------//  navigation
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Model_id { get; set; }
        public int weatherdata_id { get; set; }
        public DeserializedWeatherData weatherdata { get; set; }
    }
    public class _sys
    {
        public int type { get; set; }
        public int id { get; set; }

        public string country { get; set; }

        public int sunrise { get; set; }            // in Unix

        public int sunset { get; set; }             // in Unix
        //------------------------------------------//  navigation
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Model_id { get; set; }
        public int weatherdata_id { get; set; }
        public DeserializedWeatherData weatherdata { get; set; }

    }
    public class _cloud
    {
        public int all { get; set; }
        //------------------------------------------//  navigation
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Model_id { get; set; }
        public int weatherdata_id { get; set; }
        public DeserializedWeatherData weatherdata { get; set; }
    }
}
