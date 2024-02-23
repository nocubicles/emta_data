using Microsoft.EntityFrameworkCore.Migrations;

namespace estonian_companies.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "customerData",
                columns: table => new
                {
                    RegistryCode = table.Column<string>(type: "TEXT", nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Quarter = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RegisteredVAT = table.Column<bool>(type: "INTEGER", nullable: false),
                    StateTax = table.Column<decimal>(type: "TEXT", nullable: false),
                    WorkforceTax = table.Column<decimal>(type: "TEXT", nullable: false),
                    Revenue = table.Column<decimal>(type: "TEXT", nullable: false),
                    EmployeeCount = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customerData", x => new { x.RegistryCode, x.Year, x.Quarter });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customerData");
        }
    }
}
