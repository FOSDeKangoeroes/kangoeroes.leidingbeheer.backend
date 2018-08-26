using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class MakeDrankAndDrankTypeUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_poef.drankType_naam",
                table: "poef.drankType");

            migrationBuilder.DropIndex(
                name: "IX_poef.drank_naam",
                table: "poef.drank");

            migrationBuilder.CreateIndex(
                name: "IX_poef.drankType_naam",
                table: "poef.drankType",
                column: "naam",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_poef.drank_naam",
                table: "poef.drank",
                column: "naam",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_poef.drankType_naam",
                table: "poef.drankType");

            migrationBuilder.DropIndex(
                name: "IX_poef.drank_naam",
                table: "poef.drank");

            migrationBuilder.CreateIndex(
                name: "IX_poef.drankType_naam",
                table: "poef.drankType",
                column: "naam");

            migrationBuilder.CreateIndex(
                name: "IX_poef.drank_naam",
                table: "poef.drank",
                column: "naam");
        }
    }
}
