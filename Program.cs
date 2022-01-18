using Microsoft.EntityFrameworkCore;
using WeatherAPI.Data;
using WeatherAPI.Utility.Background;
using WeatherAPI.DAL;
using WeatherAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<WeatherAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WeatherReportContext")));
//builder.Services.AddSingleton<IHostedService, BackgroundApiCall>();                    // for backgroup task
builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IWeatherDataRepos, WeatherDataRepos>();

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapHub<ShareHub>("/ShareHub");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
