using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "poef.drankType",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "varchar(127)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poef.drankType", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tak",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    naam = table.Column<string>(type: "longtext", nullable: false),
                    volgorde = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tak", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "totems.adjectief",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createdOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    naam = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totems.adjectief", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "totems.totem",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createdOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    naam = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totems.totem", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "poef.drank",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    imageUrl = table.Column<string>(type: "longtext", nullable: true),
                    inStock = table.Column<bool>(type: "bit", nullable: false),
                    naam = table.Column<string>(type: "varchar(127)", nullable: false),
                    typeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poef.drank", x => x.id);
                    table.ForeignKey(
                        name: "FK_poef.drank_poef.drankType_typeId",
                        column: x => x.typeId,
                        principalTable: "poef.drankType",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "leiding",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    auth0Id = table.Column<string>(type: "longtext", nullable: true),
                    datumGestopt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    email = table.Column<string>(type: "longtext", nullable: true),
                    leidingSinds = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    naam = table.Column<string>(type: "longtext", nullable: false),
                    takId = table.Column<int>(type: "int", nullable: true),
                    voornaam = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leiding", x => x.id);
                    table.ForeignKey(
                        name: "FK_leiding_tak_takId",
                        column: x => x.takId,
                        principalTable: "tak",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "poef.prijs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createdOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    drankId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "poef.order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createdOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    orderedById = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poef.order", x => x.id);
                    table.ForeignKey(
                        name: "FK_poef.order_leiding_orderedById",
                        column: x => x.orderedById,
                        principalTable: "leiding",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "totems.entry",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    adjectiefId = table.Column<int>(type: "int", nullable: true),
                    datumGegeven = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    leidingId = table.Column<int>(type: "int", nullable: true),
                    totemId = table.Column<int>(type: "int", nullable: true),
                    voorouderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totems.entry", x => x.id);
                    table.ForeignKey(
                        name: "FK_totems.entry_totems.adjectief_adjectiefId",
                        column: x => x.adjectiefId,
                        principalTable: "totems.adjectief",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_totems.entry_leiding_leidingId",
                        column: x => x.leidingId,
                        principalTable: "leiding",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_totems.entry_totems.totem_totemId",
                        column: x => x.totemId,
                        principalTable: "totems.totem",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_totems.entry_totems.entry_voorouderId",
                        column: x => x.voorouderId,
                        principalTable: "totems.entry",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "poef.orderline",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    drankId = table.Column<int>(type: "int", nullable: false),
                    orderId = table.Column<int>(type: "int", nullable: false),
                    orderedForId = table.Column<int>(type: "int", nullable: false),
                    pricePaid = table.Column<decimal>(type: "decimal(65, 30)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poef.orderline", x => x.id);
                    table.ForeignKey(
                        name: "FK_poef.orderline_poef.drank_drankId",
                        column: x => x.drankId,
                        principalTable: "poef.drank",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_poef.orderline_poef.order_orderId",
                        column: x => x.orderId,
                        principalTable: "poef.order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_poef.orderline_leiding_orderedForId",
                        column: x => x.orderedForId,
                        principalTable: "leiding",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leiding_takId",
                table: "leiding",
                column: "takId");

            migrationBuilder.CreateIndex(
                name: "IX_poef.drank_naam",
                table: "poef.drank",
                column: "naam");

            migrationBuilder.CreateIndex(
                name: "IX_poef.drank_typeId",
                table: "poef.drank",
                column: "typeId");

            migrationBuilder.CreateIndex(
                name: "IX_poef.drankType_naam",
                table: "poef.drankType",
                column: "naam");

            migrationBuilder.CreateIndex(
                name: "IX_poef.order_orderedById",
                table: "poef.order",
                column: "orderedById");

            migrationBuilder.CreateIndex(
                name: "IX_poef.orderline_drankId",
                table: "poef.orderline",
                column: "drankId");

            migrationBuilder.CreateIndex(
                name: "IX_poef.orderline_orderId",
                table: "poef.orderline",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_poef.orderline_orderedForId",
                table: "poef.orderline",
                column: "orderedForId");

            migrationBuilder.CreateIndex(
                name: "IX_poef.prijs_drankId",
                table: "poef.prijs",
                column: "drankId");

            migrationBuilder.CreateIndex(
                name: "IX_totems.entry_adjectiefId",
                table: "totems.entry",
                column: "adjectiefId");

            migrationBuilder.CreateIndex(
                name: "IX_totems.entry_leidingId",
                table: "totems.entry",
                column: "leidingId");

            migrationBuilder.CreateIndex(
                name: "IX_totems.entry_totemId",
                table: "totems.entry",
                column: "totemId");

            migrationBuilder.CreateIndex(
                name: "IX_totems.entry_voorouderId",
                table: "totems.entry",
                column: "voorouderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "poef.orderline");

            migrationBuilder.DropTable(
                name: "poef.prijs");

            migrationBuilder.DropTable(
                name: "totems.entry");

            migrationBuilder.DropTable(
                name: "poef.order");

            migrationBuilder.DropTable(
                name: "poef.drank");

            migrationBuilder.DropTable(
                name: "totems.adjectief");

            migrationBuilder.DropTable(
                name: "totems.totem");

            migrationBuilder.DropTable(
                name: "leiding");

            migrationBuilder.DropTable(
                name: "poef.drankType");

            migrationBuilder.DropTable(
                name: "tak");
        }
    }
}
