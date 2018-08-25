using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class MakeDrankRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_poef.prijs_poef.drank_drankId",
                table: "poef.prijs");

            migrationBuilder.AlterColumn<int>(
                name: "drankId",
                table: "poef.prijs",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.prijs_poef.drank_drankId",
                table: "poef.prijs",
                column: "drankId",
                principalTable: "poef.drank",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_poef.prijs_poef.drank_drankId",
                table: "poef.prijs");

            migrationBuilder.AlterColumn<int>(
                name: "drankId",
                table: "poef.prijs",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_poef.prijs_poef.drank_drankId",
                table: "poef.prijs",
                column: "drankId",
                principalTable: "poef.drank",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
