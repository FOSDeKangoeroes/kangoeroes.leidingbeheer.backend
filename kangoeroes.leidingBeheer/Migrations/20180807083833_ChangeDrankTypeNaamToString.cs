using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class ChangeDrankTypeNaamToString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "naam",
                table: "poef.drankType",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "naam",
                table: "poef.drankType",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext");
        }
    }
}
