using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.infrastructure.Migrations
{
    public partial class AddTabIsAllowedProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "tabIsAllowed",
                table: "tak",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "tabIsAllowed",
                table: "tak");
        }
    }
}
