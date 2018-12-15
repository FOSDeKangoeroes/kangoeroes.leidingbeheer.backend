using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.webUI.Migrations
{
    public partial class AddQuantityToOrderline : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "pricePaid",
                table: "poef.orderline");

            migrationBuilder.AddColumn<decimal>(
                name: "drinkPrice",
                table: "poef.orderline",
                type: "decimal(65, 30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "quantity",
                table: "poef.orderline",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "drinkPrice",
                table: "poef.orderline");

            migrationBuilder.DropColumn(
                name: "quantity",
                table: "poef.orderline");

            migrationBuilder.AddColumn<decimal>(
                name: "pricePaid",
                table: "poef.orderline",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
