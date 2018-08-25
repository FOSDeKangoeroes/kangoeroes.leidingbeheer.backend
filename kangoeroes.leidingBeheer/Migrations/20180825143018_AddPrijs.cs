using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class AddPrijs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "poef.prijs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createdOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    drankId = table.Column<int>(type: "int", nullable: true),
                    waarde = table.Column<decimal>(type: "decimal(65, 30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poef.prijs", x => x.id);
                    table.ForeignKey(
                        name: "FK_poef.prijs_poef.drank_drankId",
                        column: x => x.drankId,
                        principalTable: "poef.drank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_poef.prijs_drankId",
                table: "poef.prijs",
                column: "drankId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "poef.prijs");
        }
    }
}
