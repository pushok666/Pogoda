using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelTask.Migrations
{
    public partial class ChangeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_Dates_DateDataId",
                table: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Data_DateDataId",
                table: "Data");

            migrationBuilder.DropColumn(
                name: "DateDataId",
                table: "Data");

            migrationBuilder.AlterColumn<float>(
                name: "Temperature",
                table: "Data",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<float>(
                name: "AirHumidity",
                table: "Data",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateIndex(
                name: "IX_Data_IdDate",
                table: "Data",
                column: "IdDate");

            migrationBuilder.AddForeignKey(
                name: "FK_Data_Dates_IdDate",
                table: "Data",
                column: "IdDate",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Data_Dates_IdDate",
                table: "Data");

            migrationBuilder.DropIndex(
                name: "IX_Data_IdDate",
                table: "Data");

            migrationBuilder.AlterColumn<int>(
                name: "Temperature",
                table: "Data",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<int>(
                name: "AirHumidity",
                table: "Data",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<int>(
                name: "DateDataId",
                table: "Data",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Data_DateDataId",
                table: "Data",
                column: "DateDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_Data_Dates_DateDataId",
                table: "Data",
                column: "DateDataId",
                principalTable: "Dates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
