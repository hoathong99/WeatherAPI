using Microsoft.EntityFrameworkCore;
using WeatherAPI.Model;

namespace WeatherAPI.Data
{
    public class WeatherAPIContext : DbContext
    {
        public WeatherAPIContext(DbContextOptions<WeatherAPIContext> options)
     : base(options)
        {
        }

        public DbSet<DeserializedWeatherData> WeatherData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DeserializedWeatherData>()
            .HasOne<_coord>(s => s.coord)
            .WithOne(ad => ad.weatherdata)
            .HasForeignKey<_coord>(ad => ad.weatherdata_id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeserializedWeatherData>()
            .HasMany<_weather>(s => s.weathers)
            .WithOne(ad => ad.weatherdata)
            .HasForeignKey(k => k.weatherdata_id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeserializedWeatherData>()
            .HasMany<_weather>(s => s.weathers)
            .WithOne(ad => ad.weatherdata)
            .HasForeignKey(k => k.weatherdata_id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeserializedWeatherData>()
            .HasOne<_main>(s => s.main)
            .WithOne(ad => ad.weatherdata)
            .HasForeignKey<_main>(ad => ad.weatherdata_id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeserializedWeatherData>()
            .HasOne<_wind>(s => s.wind)
            .WithOne(ad => ad.weatherdata)
            .HasForeignKey<_wind>(ad => ad.weatherdata_id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeserializedWeatherData>()
            .HasOne<_cloud>(s => s.clouds)
            .WithOne(ad => ad.weatherdata)
            .HasForeignKey<_cloud>(ad => ad.weatherdata_id)
            .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DeserializedWeatherData>()
            .HasOne<_sys>(s => s.sys)
            .WithOne(ad => ad.weatherdata)
            .HasForeignKey<_sys>(ad => ad.weatherdata_id)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
