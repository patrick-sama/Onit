using Microsoft.EntityFrameworkCore.Migrations;

namespace Onit.Migrations
{
    public partial class seconda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Identificativo",
                table: "Arrivi",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Identificativo",
                table: "Arrivi");
        }
    }
}
