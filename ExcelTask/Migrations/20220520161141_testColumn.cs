using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelTask.Migrations
{
    public partial class testColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AtmospherePressure",
                table: "Data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Cloudiness",
                table: "Data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DirectionWind",
                table: "Data",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "H",
                table: "Data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeedWind",
                table: "Data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Td",
                table: "Data",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "VV",
                table: "Data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "WeatherConditions",
                table: "Data",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AtmospherePressure",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "Cloudiness",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "DirectionWind",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "H",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "SpeedWind",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "Td",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "VV",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "WeatherConditions",
                table: "Data");
        }
    }
}
