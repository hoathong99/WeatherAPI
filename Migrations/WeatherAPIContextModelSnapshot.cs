// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeatherAPI.Data;

#nullable disable

namespace WeatherAPI.Migrations
{
    [DbContext(typeof(WeatherAPIContext))]
    partial class WeatherAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WeatherAPI.Model._cloud", b =>
                {
                    b.Property<int>("Model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Model_id"), 1L, 1);

                    b.Property<int>("all")
                        .HasColumnType("int");

                    b.Property<int>("weatherdata_id")
                        .HasColumnType("int");

                    b.HasKey("Model_id");

                    b.HasIndex("weatherdata_id")
                        .IsUnique();

                    b.ToTable("_cloud");
                });

            modelBuilder.Entity("WeatherAPI.Model._coord", b =>
                {
                    b.Property<int>("Model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Model_id"), 1L, 1);

                    b.Property<double>("lat")
                        .HasColumnType("float");

                    b.Property<double>("lon")
                        .HasColumnType("float");

                    b.Property<int>("weatherdata_id")
                        .HasColumnType("int");

                    b.HasKey("Model_id");

                    b.HasIndex("weatherdata_id")
                        .IsUnique();

                    b.ToTable("_coord");
                });

            modelBuilder.Entity("WeatherAPI.Model._main", b =>
                {
                    b.Property<int>("Model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Model_id"), 1L, 1);

                    b.Property<double>("feels_like")
                        .HasColumnType("float");

                    b.Property<int>("grnd_level")
                        .HasColumnType("int");

                    b.Property<int>("humidity")
                        .HasColumnType("int");

                    b.Property<int>("pressure")
                        .HasColumnType("int");

                    b.Property<int>("sea_level")
                        .HasColumnType("int");

                    b.Property<double>("temp")
                        .HasColumnType("float");

                    b.Property<double>("temp_max")
                        .HasColumnType("float");

                    b.Property<double>("temp_min")
                        .HasColumnType("float");

                    b.Property<int>("weatherdata_id")
                        .HasColumnType("int");

                    b.HasKey("Model_id");

                    b.HasIndex("weatherdata_id")
                        .IsUnique();

                    b.ToTable("_main");
                });

            modelBuilder.Entity("WeatherAPI.Model._sys", b =>
                {
                    b.Property<int>("Model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Model_id"), 1L, 1);

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<int>("sunrise")
                        .HasColumnType("int");

                    b.Property<int>("sunset")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.Property<int>("weatherdata_id")
                        .HasColumnType("int");

                    b.HasKey("Model_id");

                    b.HasIndex("weatherdata_id")
                        .IsUnique();

                    b.ToTable("_sys");
                });

            modelBuilder.Entity("WeatherAPI.Model._weather", b =>
                {
                    b.Property<int>("Model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Model_id"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("main")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("weatherdata_id")
                        .HasColumnType("int");

                    b.HasKey("Model_id");

                    b.HasIndex("weatherdata_id");

                    b.ToTable("_weather");
                });

            modelBuilder.Entity("WeatherAPI.Model._wind", b =>
                {
                    b.Property<int>("Model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Model_id"), 1L, 1);

                    b.Property<double>("deg")
                        .HasColumnType("float");

                    b.Property<double>("gust")
                        .HasColumnType("float");

                    b.Property<double>("speed")
                        .HasColumnType("float");

                    b.Property<int>("weatherdata_id")
                        .HasColumnType("int");

                    b.HasKey("Model_id");

                    b.HasIndex("weatherdata_id")
                        .IsUnique();

                    b.ToTable("_wind");
                });

            modelBuilder.Entity("WeatherAPI.Model.DeserializedWeatherData", b =>
                {
                    b.Property<int>("Model_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Model_id"), 1L, 1);

                    b.Property<int>("cod")
                        .HasColumnType("int");

                    b.Property<int>("dt")
                        .HasColumnType("int");

                    b.Property<int>("id")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("timezone")
                        .HasColumnType("int");

                    b.Property<int>("visibility")
                        .HasColumnType("int");

                    b.HasKey("Model_id");

                    b.ToTable("WeatherData");
                });

            modelBuilder.Entity("WeatherAPI.Model._cloud", b =>
                {
                    b.HasOne("WeatherAPI.Model.DeserializedWeatherData", "weatherdata")
                        .WithOne("clouds")
                        .HasForeignKey("WeatherAPI.Model._cloud", "weatherdata_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("weatherdata");
                });

            modelBuilder.Entity("WeatherAPI.Model._coord", b =>
                {
                    b.HasOne("WeatherAPI.Model.DeserializedWeatherData", "weatherdata")
                        .WithOne("coord")
                        .HasForeignKey("WeatherAPI.Model._coord", "weatherdata_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("weatherdata");
                });

            modelBuilder.Entity("WeatherAPI.Model._main", b =>
                {
                    b.HasOne("WeatherAPI.Model.DeserializedWeatherData", "weatherdata")
                        .WithOne("main")
                        .HasForeignKey("WeatherAPI.Model._main", "weatherdata_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("weatherdata");
                });

            modelBuilder.Entity("WeatherAPI.Model._sys", b =>
                {
                    b.HasOne("WeatherAPI.Model.DeserializedWeatherData", "weatherdata")
                        .WithOne("sys")
                        .HasForeignKey("WeatherAPI.Model._sys", "weatherdata_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("weatherdata");
                });

            modelBuilder.Entity("WeatherAPI.Model._weather", b =>
                {
                    b.HasOne("WeatherAPI.Model.DeserializedWeatherData", "weatherdata")
                        .WithMany("weathers")
                        .HasForeignKey("weatherdata_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("weatherdata");
                });

            modelBuilder.Entity("WeatherAPI.Model._wind", b =>
                {
                    b.HasOne("WeatherAPI.Model.DeserializedWeatherData", "weatherdata")
                        .WithOne("wind")
                        .HasForeignKey("WeatherAPI.Model._wind", "weatherdata_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("weatherdata");
                });

            modelBuilder.Entity("WeatherAPI.Model.DeserializedWeatherData", b =>
                {
                    b.Navigation("clouds")
                        .IsRequired();

                    b.Navigation("coord")
                        .IsRequired();

                    b.Navigation("main")
                        .IsRequired();

                    b.Navigation("sys")
                        .IsRequired();

                    b.Navigation("weathers");

                    b.Navigation("wind")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
