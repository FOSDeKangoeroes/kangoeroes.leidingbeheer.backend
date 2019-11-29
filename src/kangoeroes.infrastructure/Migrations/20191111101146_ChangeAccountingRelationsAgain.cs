using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.infrastructure.Migrations
{
    public partial class ChangeAccountingRelationsAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "ownerId",
                table: "account",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_account_leiding_ownerId",
                table: "account",
                column: "ownerId",
                principalTable: "leiding",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_account_leiding_ownerId",
                table: "account");

            migrationBuilder.AddColumn<Guid>(
                name: "debtAccountId",
                table: "leiding",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "tabAccountId",
                table: "leiding",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "ownerId",
                table: "account",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

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
        }
    }
}
