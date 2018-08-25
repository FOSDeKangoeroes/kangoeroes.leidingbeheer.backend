using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class MakeNaamDrankTypeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "naam",
                table: "poef.drankType",
                type: "varchar(127)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_poef.drankType_naam",
                table: "poef.drankType",
                column: "naam");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_poef.drankType_naam",
                table: "poef.drankType");

            migrationBuilder.AlterColumn<string>(
                name: "naam",
                table: "poef.drankType",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(127)");
        }
    }
}
