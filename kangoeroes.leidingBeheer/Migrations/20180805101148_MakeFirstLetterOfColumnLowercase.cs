using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class MakeFirstLetterOfColumnLowercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leiding_tak_takid",
                table: "leiding");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.drank_poef.drankType_typeid",
                table: "poef.drank");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.adjectief_adjectiefid",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_leiding_leidingid",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.totem_totemid",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.entry_voorouderid",
                table: "totems.entry");

            migrationBuilder.RenameColumn(
                name: "createdon",
                table: "totems.totem",
                newName: "createdOn");

            migrationBuilder.RenameColumn(
                name: "voorouderid",
                table: "totems.entry",
                newName: "voorouderId");

            migrationBuilder.RenameColumn(
                name: "totemid",
                table: "totems.entry",
                newName: "totemId");

            migrationBuilder.RenameColumn(
                name: "leidingid",
                table: "totems.entry",
                newName: "leidingId");

            migrationBuilder.RenameColumn(
                name: "datumgegeven",
                table: "totems.entry",
                newName: "datumGegeven");

            migrationBuilder.RenameColumn(
                name: "adjectiefid",
                table: "totems.entry",
                newName: "adjectiefId");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_voorouderid",
                table: "totems.entry",
                newName: "IX_totems.entry_voorouderId");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_totemid",
                table: "totems.entry",
                newName: "IX_totems.entry_totemId");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_leidingid",
                table: "totems.entry",
                newName: "IX_totems.entry_leidingId");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_adjectiefid",
                table: "totems.entry",
                newName: "IX_totems.entry_adjectiefId");

            migrationBuilder.RenameColumn(
                name: "createdon",
                table: "totems.adjectief",
                newName: "createdOn");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "poef.drank",
                newName: "typeId");

            migrationBuilder.RenameColumn(
                name: "instock",
                table: "poef.drank",
                newName: "inStock");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "poef.drank",
                newName: "imageUrl");

            migrationBuilder.RenameIndex(
                name: "IX_poef.drank_typeid",
                table: "poef.drank",
                newName: "IX_poef.drank_typeId");

            migrationBuilder.RenameColumn(
                name: "takid",
                table: "leiding",
                newName: "takId");

            migrationBuilder.RenameColumn(
                name: "leidingsinds",
                table: "leiding",
                newName: "leidingSinds");

            migrationBuilder.RenameColumn(
                name: "datumgestopt",
                table: "leiding",
                newName: "datumGestopt");

            migrationBuilder.RenameColumn(
                name: "auth0id",
                table: "leiding",
                newName: "auth0Id");

            migrationBuilder.RenameIndex(
                name: "IX_leiding_takid",
                table: "leiding",
                newName: "IX_leiding_takId");

            migrationBuilder.AddForeignKey(
                name: "FK_leiding_tak_takId",
                table: "leiding",
                column: "takId",
                principalTable: "tak",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.drank_poef.drankType_typeId",
                table: "poef.drank",
                column: "typeId",
                principalTable: "poef.drankType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.adjectief_adjectiefId",
                table: "totems.entry",
                column: "adjectiefId",
                principalTable: "totems.adjectief",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_leiding_leidingId",
                table: "totems.entry",
                column: "leidingId",
                principalTable: "leiding",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.totem_totemId",
                table: "totems.entry",
                column: "totemId",
                principalTable: "totems.totem",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.entry_voorouderId",
                table: "totems.entry",
                column: "voorouderId",
                principalTable: "totems.entry",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leiding_tak_takId",
                table: "leiding");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.drank_poef.drankType_typeId",
                table: "poef.drank");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.adjectief_adjectiefId",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_leiding_leidingId",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.totem_totemId",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.entry_voorouderId",
                table: "totems.entry");

            migrationBuilder.RenameColumn(
                name: "createdOn",
                table: "totems.totem",
                newName: "createdon");

            migrationBuilder.RenameColumn(
                name: "voorouderId",
                table: "totems.entry",
                newName: "voorouderid");

            migrationBuilder.RenameColumn(
                name: "totemId",
                table: "totems.entry",
                newName: "totemid");

            migrationBuilder.RenameColumn(
                name: "leidingId",
                table: "totems.entry",
                newName: "leidingid");

            migrationBuilder.RenameColumn(
                name: "datumGegeven",
                table: "totems.entry",
                newName: "datumgegeven");

            migrationBuilder.RenameColumn(
                name: "adjectiefId",
                table: "totems.entry",
                newName: "adjectiefid");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_voorouderId",
                table: "totems.entry",
                newName: "IX_totems.entry_voorouderid");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_totemId",
                table: "totems.entry",
                newName: "IX_totems.entry_totemid");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_leidingId",
                table: "totems.entry",
                newName: "IX_totems.entry_leidingid");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_adjectiefId",
                table: "totems.entry",
                newName: "IX_totems.entry_adjectiefid");

            migrationBuilder.RenameColumn(
                name: "createdOn",
                table: "totems.adjectief",
                newName: "createdon");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "poef.drank",
                newName: "typeid");

            migrationBuilder.RenameColumn(
                name: "inStock",
                table: "poef.drank",
                newName: "instock");

            migrationBuilder.RenameColumn(
                name: "imageUrl",
                table: "poef.drank",
                newName: "imageurl");

            migrationBuilder.RenameIndex(
                name: "IX_poef.drank_typeId",
                table: "poef.drank",
                newName: "IX_poef.drank_typeid");

            migrationBuilder.RenameColumn(
                name: "takId",
                table: "leiding",
                newName: "takid");

            migrationBuilder.RenameColumn(
                name: "leidingSinds",
                table: "leiding",
                newName: "leidingsinds");

            migrationBuilder.RenameColumn(
                name: "datumGestopt",
                table: "leiding",
                newName: "datumgestopt");

            migrationBuilder.RenameColumn(
                name: "auth0Id",
                table: "leiding",
                newName: "auth0id");

            migrationBuilder.RenameIndex(
                name: "IX_leiding_takId",
                table: "leiding",
                newName: "IX_leiding_takid");

            migrationBuilder.AddForeignKey(
                name: "FK_leiding_tak_takid",
                table: "leiding",
                column: "takid",
                principalTable: "tak",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.drank_poef.drankType_typeid",
                table: "poef.drank",
                column: "typeid",
                principalTable: "poef.drankType",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.adjectief_adjectiefid",
                table: "totems.entry",
                column: "adjectiefid",
                principalTable: "totems.adjectief",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_leiding_leidingid",
                table: "totems.entry",
                column: "leidingid",
                principalTable: "leiding",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.totem_totemid",
                table: "totems.entry",
                column: "totemid",
                principalTable: "totems.totem",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.entry_voorouderid",
                table: "totems.entry",
                column: "voorouderid",
                principalTable: "totems.entry",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
