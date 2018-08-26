using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class AddOrderEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "poef.order",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    createdOn = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    orderedById = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_poef.order", x => x.id);
                    table.ForeignKey(
                        name: "FK_poef.order_leiding_orderedById",
                        column: x => x.orderedById,
                        principalTable: "leiding",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "poef.orderline",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    drankId = table.Column<int>(type: "int", nullable: true),
                    orderId = table.Column<int>(type: "int", nullable: true),
                    orderedForId = table.Column<int>(type: "int", nullable: true),
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
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_poef.orderline_poef.order_orderId",
                        column: x => x.orderId,
                        principalTable: "poef.order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_poef.orderline_leiding_orderedForId",
                        column: x => x.orderedForId,
                        principalTable: "leiding",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "poef.orderline");

            migrationBuilder.DropTable(
                name: "poef.order");
        }
    }
}
