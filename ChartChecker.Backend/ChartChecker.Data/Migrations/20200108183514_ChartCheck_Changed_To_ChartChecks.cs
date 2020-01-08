using Microsoft.EntityFrameworkCore.Migrations;

namespace ChartChecker.Data.Migrations
{
    public partial class ChartCheck_Changed_To_ChartChecks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChartCheck",
                table: "ChartCheck");

            migrationBuilder.RenameTable(
                name: "ChartCheck",
                newName: "ChartChecks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChartChecks",
                table: "ChartChecks",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChartChecks",
                table: "ChartChecks");

            migrationBuilder.RenameTable(
                name: "ChartChecks",
                newName: "ChartCheck");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChartCheck",
                table: "ChartCheck",
                column: "Id");
        }
    }
}
