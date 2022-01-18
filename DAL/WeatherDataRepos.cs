using WeatherAPI.Data;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Model;

namespace WeatherAPI.DAL
{
    public class WeatherDataRepos : GenericRepos<DeserializedWeatherData>, IWeatherDataRepos
    {
        public WeatherDataRepos(WeatherAPIContext context)
            : base(context)
            {
        }
        public override async Task<DeserializedWeatherData> getById(int id)
        {
            var rs = DbSet
                    .Include(x => x.coord)
                    .Include(x => x.weathers)
                    .Include(x => x.main)
                    .Include(x => x.wind)
                    .Include(x => x.clouds)
                    .Include(x => x.sys)
                    .FirstOrDefault(x => x.Model_id == id);
            return rs;
        }
        //public override async Task<DeserializedWeatherData> getAll()
        //{
        //    var datas = from w in DbSet
        //                 select (new DeserializedWeatherData
        //                 {
        //                     Model_id = w.Model_id,
        //                     
        //                     Rooms = (from r in _context.Rooms
        //                              where r.HouseId == id
        //                              select r).ToList()
        //                 }
        //                 );
        //}
    }
}
