using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherAPI.Migrations
{
    public partial class a1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherData",
                columns: table => new
                {
                    Model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    visibility = table.Column<int>(type: "int", nullable: false),
                    dt = table.Column<int>(type: "int", nullable: false),
                    timezone = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherData", x => x.Model_id);
                });

            migrationBuilder.CreateTable(
                name: "_cloud",
                columns: table => new
                {
                    Model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    all = table.Column<int>(type: "int", nullable: false),
                    weatherdata_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__cloud", x => x.Model_id);
                    table.ForeignKey(
                        name: "FK__cloud_WeatherData_weatherdata_id",
                        column: x => x.weatherdata_id,
                        principalTable: "WeatherData",
                        principalColumn: "Model_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_coord",
                columns: table => new
                {
                    Model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lon = table.Column<double>(type: "float", nullable: false),
                    lat = table.Column<double>(type: "float", nullable: false),
                    weatherdata_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__coord", x => x.Model_id);
                    table.ForeignKey(
                        name: "FK__coord_WeatherData_weatherdata_id",
                        column: x => x.weatherdata_id,
                        principalTable: "WeatherData",
                        principalColumn: "Model_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_main",
                columns: table => new
                {
                    Model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    temp = table.Column<double>(type: "float", nullable: false),
                    feels_like = table.Column<double>(type: "float", nullable: false),
                    temp_min = table.Column<double>(type: "float", nullable: false),
                    temp_max = table.Column<double>(type: "float", nullable: false),
                    pressure = table.Column<int>(type: "int", nullable: false),
                    humidity = table.Column<int>(type: "int", nullable: false),
                    sea_level = table.Column<int>(type: "int", nullable: false),
                    grnd_level = table.Column<int>(type: "int", nullable: false),
                    weatherdata_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__main", x => x.Model_id);
                    table.ForeignKey(
                        name: "FK__main_WeatherData_weatherdata_id",
                        column: x => x.weatherdata_id,
                        principalTable: "WeatherData",
                        principalColumn: "Model_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_sys",
                columns: table => new
                {
                    Model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<int>(type: "int", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    sunrise = table.Column<int>(type: "int", nullable: false),
                    sunset = table.Column<int>(type: "int", nullable: false),
                    weatherdata_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__sys", x => x.Model_id);
                    table.ForeignKey(
                        name: "FK__sys_WeatherData_weatherdata_id",
                        column: x => x.weatherdata_id,
                        principalTable: "WeatherData",
                        principalColumn: "Model_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_weather",
                columns: table => new
                {
                    Model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id = table.Column<int>(type: "int", nullable: false),
                    main = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    icon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    weatherdata_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__weather", x => x.Model_id);
                    table.ForeignKey(
                        name: "FK__weather_WeatherData_weatherdata_id",
                        column: x => x.weatherdata_id,
                        principalTable: "WeatherData",
                        principalColumn: "Model_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "_wind",
                columns: table => new
                {
                    Model_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    speed = table.Column<double>(type: "float", nullable: false),
                    deg = table.Column<double>(type: "float", nullable: false),
                    gust = table.Column<double>(type: "float", nullable: false),
                    weatherdata_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__wind", x => x.Model_id);
                    table.ForeignKey(
                        name: "FK__wind_WeatherData_weatherdata_id",
                        column: x => x.weatherdata_id,
                        principalTable: "WeatherData",
                        principalColumn: "Model_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX__cloud_weatherdata_id",
                table: "_cloud",
                column: "weatherdata_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__coord_weatherdata_id",
                table: "_coord",
                column: "weatherdata_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__main_weatherdata_id",
                table: "_main",
                column: "weatherdata_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__sys_weatherdata_id",
                table: "_sys",
                column: "weatherdata_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX__weather_weatherdata_id",
                table: "_weather",
                column: "weatherdata_id");

            migrationBuilder.CreateIndex(
                name: "IX__wind_weatherdata_id",
                table: "_wind",
                column: "weatherdata_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "_cloud");

            migrationBuilder.DropTable(
                name: "_coord");

            migrationBuilder.DropTable(
                name: "_main");

            migrationBuilder.DropTable(
                name: "_sys");

            migrationBuilder.DropTable(
                name: "_weather");

            migrationBuilder.DropTable(
                name: "_wind");

            migrationBuilder.DropTable(
                name: "WeatherData");
        }
    }
}
