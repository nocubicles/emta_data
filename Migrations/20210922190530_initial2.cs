using Microsoft.EntityFrameworkCore.Migrations;

namespace estonian_companies.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "YearQuarter",
                table: "customerData",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearQuarter",
                table: "customerData");
        }
    }
}
