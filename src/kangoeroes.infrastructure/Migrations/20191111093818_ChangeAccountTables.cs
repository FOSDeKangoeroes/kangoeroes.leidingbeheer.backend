using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.infrastructure.Migrations
{
    public partial class ChangeAccountTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leiding_account_debtAccountId",
                table: "leiding");

            migrationBuilder.DropForeignKey(
                name: "FK_leiding_account_tabAccountId",
                table: "leiding");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_debtAccountId",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_poef.orderline_consumptionId",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_tabAccountId",
                table: "transaction");

            migrationBuilder.DropIndex(
                name: "IX_transaction_debtAccountId",
                table: "transaction");

            migrationBuilder.DropIndex(
                name: "IX_transaction_consumptionId",
                table: "transaction");

            migrationBuilder.DropIndex(
                name: "IX_leiding_debtAccountId",
                table: "leiding");

            migrationBuilder.DropIndex(
                name: "IX_leiding_tabAccountId",
                table: "leiding");

            migrationBuilder.DropColumn(
                name: "debtAccountId",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "consumptionId",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "transactionType",
                table: "transaction");

            migrationBuilder.RenameColumn(
                name: "tabAccountId",
                table: "transaction",
                newName: "accountId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_tabAccountId",
                table: "transaction",
                newName: "IX_transaction_accountId");

            migrationBuilder.AlterColumn<Guid>(
                name: "tabAccountId",
                table: "leiding",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "debtAccountId",
                table: "leiding",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ownerId",
                table: "account",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_leiding_debtAccountId",
                table: "leiding",
                column: "debtAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_leiding_tabAccountId",
                table: "leiding",
                column: "tabAccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_account_ownerId",
                table: "account",
                column: "ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_account_leiding_ownerId",
                table: "account",
                column: "ownerId",
                principalTable: "leiding",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_leiding_account_debtAccountId",
                table: "leiding",
                column: "debtAccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_leiding_account_tabAccountId",
                table: "leiding",
                column: "tabAccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_accountId",
                table: "transaction",
                column: "accountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_leiding_ownerId",
                table: "account");

            migrationBuilder.DropForeignKey(
                name: "FK_leiding_account_debtAccountId",
                table: "leiding");

            migrationBuilder.DropForeignKey(
                name: "FK_leiding_account_tabAccountId",
                table: "leiding");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_account_accountId",
                table: "transaction");

            migrationBuilder.DropIndex(
                name: "IX_leiding_debtAccountId",
                table: "leiding");

            migrationBuilder.DropIndex(
                name: "IX_leiding_tabAccountId",
                table: "leiding");

            migrationBuilder.DropIndex(
                name: "IX_account_ownerId",
                table: "account");

            migrationBuilder.DropColumn(
                name: "ownerId",
                table: "account");

            migrationBuilder.RenameColumn(
                name: "accountId",
                table: "transaction",
                newName: "tabAccountId");

            migrationBuilder.RenameIndex(
                name: "IX_transaction_accountId",
                table: "transaction",
                newName: "IX_transaction_tabAccountId");

            migrationBuilder.AddColumn<Guid>(
                name: "debtAccountId",
                table: "transaction",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "consumptionId",
                table: "transaction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "transactionType",
                table: "transaction",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "tabAccountId",
                table: "leiding",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "debtAccountId",
                table: "leiding",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_transaction_debtAccountId",
                table: "transaction",
                column: "debtAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_transaction_consumptionId",
                table: "transaction",
                column: "consumptionId");

            migrationBuilder.CreateIndex(
                name: "IX_leiding_debtAccountId",
                table: "leiding",
                column: "debtAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_leiding_tabAccountId",
                table: "leiding",
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

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_debtAccountId",
                table: "transaction",
                column: "debtAccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_poef.orderline_consumptionId",
                table: "transaction",
                column: "consumptionId",
                principalTable: "poef.orderline",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_account_tabAccountId",
                table: "transaction",
                column: "tabAccountId",
                principalTable: "account",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
