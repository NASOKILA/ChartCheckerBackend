using Microsoft.EntityFrameworkCore.Migrations;

namespace ChartChecker.Data.Migrations
{
    public partial class ChartCheckaddedrequiredattribute : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Store",
                table: "ChartChecks");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "ChartChecks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ChartChecks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChartType",
                table: "ChartChecks",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StoreName",
                table: "ChartChecks",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreName",
                table: "ChartChecks");

            migrationBuilder.AlterColumn<string>(
                name: "UserEmail",
                table: "ChartChecks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImagePath",
                table: "ChartChecks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ChartType",
                table: "ChartChecks",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Store",
                table: "ChartChecks",
                nullable: true);
        }
    }
}
