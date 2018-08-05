using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace kangoeroes.leidingBeheer.Migrations
{
    public partial class EnforceRequiredColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_leiding_tak_TakId",
                table: "leiding");

            migrationBuilder.DropForeignKey(
                name: "FK_poef.drank_poef.drankType_TypeId",
                table: "poef.drank");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.adjectief_AdjectiefId",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_leiding_LeidingId",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.totem_TotemId",
                table: "totems.entry");

            migrationBuilder.DropForeignKey(
                name: "FK_totems.entry_totems.entry_VoorouderId",
                table: "totems.entry");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "totems.totem",
                newName: "naam");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "totems.totem",
                newName: "createdon");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "totems.totem",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "VoorouderId",
                table: "totems.entry",
                newName: "voorouderid");

            migrationBuilder.RenameColumn(
                name: "TotemId",
                table: "totems.entry",
                newName: "totemid");

            migrationBuilder.RenameColumn(
                name: "LeidingId",
                table: "totems.entry",
                newName: "leidingid");

            migrationBuilder.RenameColumn(
                name: "DatumGegeven",
                table: "totems.entry",
                newName: "datumgegeven");

            migrationBuilder.RenameColumn(
                name: "AdjectiefId",
                table: "totems.entry",
                newName: "adjectiefid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "totems.entry",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_VoorouderId",
                table: "totems.entry",
                newName: "IX_totems.entry_voorouderid");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_TotemId",
                table: "totems.entry",
                newName: "IX_totems.entry_totemid");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_LeidingId",
                table: "totems.entry",
                newName: "IX_totems.entry_leidingid");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_AdjectiefId",
                table: "totems.entry",
                newName: "IX_totems.entry_adjectiefid");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "totems.adjectief",
                newName: "naam");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                table: "totems.adjectief",
                newName: "createdon");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "totems.adjectief",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Volgorde",
                table: "tak",
                newName: "volgorde");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "tak",
                newName: "naam");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tak",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "poef.drankType",
                newName: "naam");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "poef.drankType",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "poef.drank",
                newName: "typeid");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "poef.drank",
                newName: "naam");

            migrationBuilder.RenameColumn(
                name: "InStock",
                table: "poef.drank",
                newName: "instock");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "poef.drank",
                newName: "imageurl");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "poef.drank",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_poef.drank_TypeId",
                table: "poef.drank",
                newName: "IX_poef.drank_typeid");

            migrationBuilder.RenameColumn(
                name: "Voornaam",
                table: "leiding",
                newName: "voornaam");

            migrationBuilder.RenameColumn(
                name: "TakId",
                table: "leiding",
                newName: "takid");

            migrationBuilder.RenameColumn(
                name: "Naam",
                table: "leiding",
                newName: "naam");

            migrationBuilder.RenameColumn(
                name: "LeidingSinds",
                table: "leiding",
                newName: "leidingsinds");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "leiding",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "DatumGestopt",
                table: "leiding",
                newName: "datumgestopt");

            migrationBuilder.RenameColumn(
                name: "Auth0Id",
                table: "leiding",
                newName: "auth0id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "leiding",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_leiding_TakId",
                table: "leiding",
                newName: "IX_leiding_takid");

            migrationBuilder.AlterColumn<string>(
                name: "naam",
                table: "totems.totem",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "naam",
                table: "totems.adjectief",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "naam",
                table: "tak",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "naam",
                table: "poef.drank",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "voornaam",
                table: "leiding",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "naam",
                table: "leiding",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "naam",
                table: "totems.totem",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "createdon",
                table: "totems.totem",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "totems.totem",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "voorouderid",
                table: "totems.entry",
                newName: "VoorouderId");

            migrationBuilder.RenameColumn(
                name: "totemid",
                table: "totems.entry",
                newName: "TotemId");

            migrationBuilder.RenameColumn(
                name: "leidingid",
                table: "totems.entry",
                newName: "LeidingId");

            migrationBuilder.RenameColumn(
                name: "datumgegeven",
                table: "totems.entry",
                newName: "DatumGegeven");

            migrationBuilder.RenameColumn(
                name: "adjectiefid",
                table: "totems.entry",
                newName: "AdjectiefId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "totems.entry",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_voorouderid",
                table: "totems.entry",
                newName: "IX_totems.entry_VoorouderId");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_totemid",
                table: "totems.entry",
                newName: "IX_totems.entry_TotemId");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_leidingid",
                table: "totems.entry",
                newName: "IX_totems.entry_LeidingId");

            migrationBuilder.RenameIndex(
                name: "IX_totems.entry_adjectiefid",
                table: "totems.entry",
                newName: "IX_totems.entry_AdjectiefId");

            migrationBuilder.RenameColumn(
                name: "naam",
                table: "totems.adjectief",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "createdon",
                table: "totems.adjectief",
                newName: "CreatedOn");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "totems.adjectief",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "volgorde",
                table: "tak",
                newName: "Volgorde");

            migrationBuilder.RenameColumn(
                name: "naam",
                table: "tak",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tak",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "naam",
                table: "poef.drankType",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "poef.drankType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "typeid",
                table: "poef.drank",
                newName: "TypeId");

            migrationBuilder.RenameColumn(
                name: "naam",
                table: "poef.drank",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "instock",
                table: "poef.drank",
                newName: "InStock");

            migrationBuilder.RenameColumn(
                name: "imageurl",
                table: "poef.drank",
                newName: "ImageUrl");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "poef.drank",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_poef.drank_typeid",
                table: "poef.drank",
                newName: "IX_poef.drank_TypeId");

            migrationBuilder.RenameColumn(
                name: "voornaam",
                table: "leiding",
                newName: "Voornaam");

            migrationBuilder.RenameColumn(
                name: "takid",
                table: "leiding",
                newName: "TakId");

            migrationBuilder.RenameColumn(
                name: "naam",
                table: "leiding",
                newName: "Naam");

            migrationBuilder.RenameColumn(
                name: "leidingsinds",
                table: "leiding",
                newName: "LeidingSinds");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "leiding",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "datumgestopt",
                table: "leiding",
                newName: "DatumGestopt");

            migrationBuilder.RenameColumn(
                name: "auth0id",
                table: "leiding",
                newName: "Auth0Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "leiding",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_leiding_takid",
                table: "leiding",
                newName: "IX_leiding_TakId");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "totems.totem",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "totems.adjectief",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "tak",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "poef.drank",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Voornaam",
                table: "leiding",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AlterColumn<string>(
                name: "Naam",
                table: "leiding",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext");

            migrationBuilder.AddForeignKey(
                name: "FK_leiding_tak_TakId",
                table: "leiding",
                column: "TakId",
                principalTable: "tak",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_poef.drank_poef.drankType_TypeId",
                table: "poef.drank",
                column: "TypeId",
                principalTable: "poef.drankType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.adjectief_AdjectiefId",
                table: "totems.entry",
                column: "AdjectiefId",
                principalTable: "totems.adjectief",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_leiding_LeidingId",
                table: "totems.entry",
                column: "LeidingId",
                principalTable: "leiding",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.totem_TotemId",
                table: "totems.entry",
                column: "TotemId",
                principalTable: "totems.totem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_totems.entry_totems.entry_VoorouderId",
                table: "totems.entry",
                column: "VoorouderId",
                principalTable: "totems.entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
