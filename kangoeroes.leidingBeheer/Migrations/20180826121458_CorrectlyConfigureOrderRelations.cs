using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class CorrectlyConfigureOrderRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_poef.order_leiding_orderedById",
                table: "poef.order");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.orderline_poef.drank_drankId",
                table: "poef.orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.orderline_poef.order_orderId",
                table: "poef.orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.orderline_leiding_orderedForId",
                table: "poef.orderline");

            migrationBuilder.AlterColumn<int>(
                name: "orderedForId",
                table: "poef.orderline",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "orderId",
                table: "poef.orderline",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "drankId",
                table: "poef.orderline",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "orderedById",
                table: "poef.order",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.order_leiding_orderedById",
                table: "poef.order",
                column: "orderedById",
                principalTable: "leiding",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.orderline_poef.drank_drankId",
                table: "poef.orderline",
                column: "drankId",
                principalTable: "poef.drank",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.orderline_poef.order_orderId",
                table: "poef.orderline",
                column: "orderId",
                principalTable: "poef.order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.orderline_leiding_orderedForId",
                table: "poef.orderline",
                column: "orderedForId",
                principalTable: "leiding",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_poef.order_leiding_orderedById",
                table: "poef.order");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.orderline_poef.drank_drankId",
                table: "poef.orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.orderline_poef.order_orderId",
                table: "poef.orderline");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.orderline_leiding_orderedForId",
                table: "poef.orderline");

            migrationBuilder.AlterColumn<int>(
                name: "orderedForId",
                table: "poef.orderline",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "orderId",
                table: "poef.orderline",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "drankId",
                table: "poef.orderline",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "orderedById",
                table: "poef.order",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_poef.order_leiding_orderedById",
                table: "poef.order",
                column: "orderedById",
                principalTable: "leiding",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.orderline_poef.drank_drankId",
                table: "poef.orderline",
                column: "drankId",
                principalTable: "poef.drank",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.orderline_poef.order_orderId",
                table: "poef.orderline",
                column: "orderId",
                principalTable: "poef.order",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.orderline_leiding_orderedForId",
                table: "poef.orderline",
                column: "orderedForId",
                principalTable: "leiding",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
