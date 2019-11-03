using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.infrastructure.Migrations
{
    public partial class ModelTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "auth0Id",
                table: "leiding");

            migrationBuilder.AddColumn<Guid>(
                name: "debtAccountId",
                table: "leiding",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "tabAccountId",
                table: "leiding",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "account",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    balance = table.Column<decimal>(nullable: false),
                    lastUpdated = table.Column<DateTime>(nullable: false),
                    accountType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_account", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    transactionType = table.Column<string>(nullable: false),
                    debtAccountId = table.Column<Guid>(nullable: true),
                    consumptionId = table.Column<int>(nullable: true),
                    tabAccountId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.id);
                    table.ForeignKey(
                        name: "FK_transaction_account_debtAccountId",
                        column: x => x.debtAccountId,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transaction_poef.orderline_consumptionId",
                        column: x => x.consumptionId,
                        principalTable: "poef.orderline",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_transaction_account_tabAccountId",
                        column: x => x.tabAccountId,
                        principalTable: "account",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_leiding_debtAccountId",
                table: "leiding",
                column: "debtAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_leiding_tabAccountId",
                table: "leiding",
                column: "tabAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_debtAccountId",
                table: "transaction",
                column: "debtAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_consumptionId",
                table: "transaction",
                column: "consumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_tabAccountId",
                table: "transaction",
                column: "tabAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_leiding_account_debtAccountId",
                table: "leiding",
                column: "debtAccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_leiding_account_tabAccountId",
                table: "leiding",
                column: "tabAccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leiding_account_debtAccountId",
                table: "leiding");

            migrationBuilder.DropForeignKey(
                name: "FK_leiding_account_tabAccountId",
                table: "leiding");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "account");

            migrationBuilder.DropIndex(
                name: "IX_leiding_debtAccountId",
                table: "leiding");

            migrationBuilder.DropIndex(
                name: "IX_leiding_tabAccountId",
                table: "leiding");

            migrationBuilder.DropColumn(
                name: "debtAccountId",
                table: "leiding");

            migrationBuilder.DropColumn(
                name: "tabAccountId",
                table: "leiding");

            migrationBuilder.AddColumn<string>(
                name: "auth0Id",
                table: "leiding",
                nullable: true);
        }
    }
}
