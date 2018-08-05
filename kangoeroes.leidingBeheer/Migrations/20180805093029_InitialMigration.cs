using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "poef.drankType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poef.drankType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(type: "longtext", nullable: true),
                    Volgorde = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "totems.adjectief",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Naam = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totems.adjectief", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "totems.totem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Naam = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totems.totem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "poef.drank",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true),
                    InStock = table.Column<bool>(type: "bit", nullable: false),
                    Naam = table.Column<string>(type: "longtext", nullable: true),
                    TypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poef.drank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_poef.drank_poef.drankType_TypeId",
                        column: x => x.TypeId,
                        principalTable: "poef.drankType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "leiding",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Auth0Id = table.Column<string>(type: "longtext", nullable: true),
                    DatumGestopt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: true),
                    LeidingSinds = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Naam = table.Column<string>(type: "longtext", nullable: true),
                    TakId = table.Column<int>(type: "int", nullable: true),
                    Voornaam = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leiding", x => x.Id);
                    table.ForeignKey(
                        name: "FK_leiding_tak_TakId",
                        column: x => x.TakId,
                        principalTable: "tak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "totems.entry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdjectiefId = table.Column<int>(type: "int", nullable: true),
                    DatumGegeven = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LeidingId = table.Column<int>(type: "int", nullable: true),
                    TotemId = table.Column<int>(type: "int", nullable: true),
                    VoorouderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totems.entry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_totems.entry_totems.adjectief_AdjectiefId",
                        column: x => x.AdjectiefId,
                        principalTable: "totems.adjectief",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_totems.entry_leiding_LeidingId",
                        column: x => x.LeidingId,
                        principalTable: "leiding",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_totems.entry_totems.totem_TotemId",
                        column: x => x.TotemId,
                        principalTable: "totems.totem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_totems.entry_totems.entry_VoorouderId",
                        column: x => x.VoorouderId,
                        principalTable: "totems.entry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leiding_TakId",
                table: "leiding",
                column: "TakId");

            migrationBuilder.CreateIndex(
                name: "IX_poef.drank_TypeId",
                table: "poef.drank",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_totems.entry_AdjectiefId",
                table: "totems.entry",
                column: "AdjectiefId");

            migrationBuilder.CreateIndex(
                name: "IX_totems.entry_LeidingId",
                table: "totems.entry",
                column: "LeidingId");

            migrationBuilder.CreateIndex(
                name: "IX_totems.entry_TotemId",
                table: "totems.entry",
                column: "TotemId");

            migrationBuilder.CreateIndex(
                name: "IX_totems.entry_VoorouderId",
                table: "totems.entry",
                column: "VoorouderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "poef.drank");

            migrationBuilder.DropTable(
                name: "totems.entry");

            migrationBuilder.DropTable(
                name: "poef.drankType");

            migrationBuilder.DropTable(
                name: "totems.adjectief");

            migrationBuilder.DropTable(
                name: "leiding");

            migrationBuilder.DropTable(
                name: "totems.totem");

            migrationBuilder.DropTable(
                name: "tak");
        }
    }
}
