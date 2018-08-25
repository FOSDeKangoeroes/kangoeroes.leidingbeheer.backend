using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.leidingBeheer.Migrations
{
  public partial class ChangeDrankTypeNaamToString : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<string>(
        "naam",
        "poef.drankType",
        "longtext",
        nullable: false,
        oldClrType: typeof(int));
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterColumn<int>(
        "naam",
        "poef.drankType",
        nullable: false,
        oldClrType: typeof(string),
        oldType: "longtext");
    }
  }
}
