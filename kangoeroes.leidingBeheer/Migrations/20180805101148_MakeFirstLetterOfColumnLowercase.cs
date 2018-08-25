using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.leidingBeheer.Migrations
{
  public partial class MakeFirstLetterOfColumnLowercase : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
        "FK_leiding_tak_takid",
        "leiding");

      migrationBuilder.DropForeignKey(
        "FK_poef.drank_poef.drankType_typeid",
        "poef.drank");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.adjectief_adjectiefid",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_leiding_leidingid",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.totem_totemid",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.entry_voorouderid",
        "totems.entry");

      migrationBuilder.RenameColumn(
        "createdon",
        "totems.totem",
        "createdOn");

      migrationBuilder.RenameColumn(
        "voorouderid",
        "totems.entry",
        "voorouderId");

      migrationBuilder.RenameColumn(
        "totemid",
        "totems.entry",
        "totemId");

      migrationBuilder.RenameColumn(
        "leidingid",
        "totems.entry",
        "leidingId");

      migrationBuilder.RenameColumn(
        "datumgegeven",
        "totems.entry",
        "datumGegeven");

      migrationBuilder.RenameColumn(
        "adjectiefid",
        "totems.entry",
        "adjectiefId");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_voorouderid",
        table: "totems.entry",
        newName: "IX_totems.entry_voorouderId");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_totemid",
        table: "totems.entry",
        newName: "IX_totems.entry_totemId");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_leidingid",
        table: "totems.entry",
        newName: "IX_totems.entry_leidingId");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_adjectiefid",
        table: "totems.entry",
        newName: "IX_totems.entry_adjectiefId");

      migrationBuilder.RenameColumn(
        "createdon",
        "totems.adjectief",
        "createdOn");

      migrationBuilder.RenameColumn(
        "typeid",
        "poef.drank",
        "typeId");

      migrationBuilder.RenameColumn(
        "instock",
        "poef.drank",
        "inStock");

      migrationBuilder.RenameColumn(
        "imageurl",
        "poef.drank",
        "imageUrl");

      migrationBuilder.RenameIndex(
        "IX_poef.drank_typeid",
        table: "poef.drank",
        newName: "IX_poef.drank_typeId");

      migrationBuilder.RenameColumn(
        "takid",
        "leiding",
        "takId");

      migrationBuilder.RenameColumn(
        "leidingsinds",
        "leiding",
        "leidingSinds");

      migrationBuilder.RenameColumn(
        "datumgestopt",
        "leiding",
        "datumGestopt");

      migrationBuilder.RenameColumn(
        "auth0id",
        "leiding",
        "auth0Id");

      migrationBuilder.RenameIndex(
        "IX_leiding_takid",
        table: "leiding",
        newName: "IX_leiding_takId");

      migrationBuilder.AddForeignKey(
        "FK_leiding_tak_takId",
        "leiding",
        "takId",
        "tak",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_poef.drank_poef.drankType_typeId",
        "poef.drank",
        "typeId",
        "poef.drankType",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.adjectief_adjectiefId",
        "totems.entry",
        "adjectiefId",
        "totems.adjectief",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_leiding_leidingId",
        "totems.entry",
        "leidingId",
        "leiding",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.totem_totemId",
        "totems.entry",
        "totemId",
        "totems.totem",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.entry_voorouderId",
        "totems.entry",
        "voorouderId",
        "totems.entry",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
        "FK_leiding_tak_takId",
        "leiding");

      migrationBuilder.DropForeignKey(
        "FK_poef.drank_poef.drankType_typeId",
        "poef.drank");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.adjectief_adjectiefId",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_leiding_leidingId",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.totem_totemId",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.entry_voorouderId",
        "totems.entry");

      migrationBuilder.RenameColumn(
        "createdOn",
        "totems.totem",
        "createdon");

      migrationBuilder.RenameColumn(
        "voorouderId",
        "totems.entry",
        "voorouderid");

      migrationBuilder.RenameColumn(
        "totemId",
        "totems.entry",
        "totemid");

      migrationBuilder.RenameColumn(
        "leidingId",
        "totems.entry",
        "leidingid");

      migrationBuilder.RenameColumn(
        "datumGegeven",
        "totems.entry",
        "datumgegeven");

      migrationBuilder.RenameColumn(
        "adjectiefId",
        "totems.entry",
        "adjectiefid");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_voorouderId",
        table: "totems.entry",
        newName: "IX_totems.entry_voorouderid");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_totemId",
        table: "totems.entry",
        newName: "IX_totems.entry_totemid");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_leidingId",
        table: "totems.entry",
        newName: "IX_totems.entry_leidingid");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_adjectiefId",
        table: "totems.entry",
        newName: "IX_totems.entry_adjectiefid");

      migrationBuilder.RenameColumn(
        "createdOn",
        "totems.adjectief",
        "createdon");

      migrationBuilder.RenameColumn(
        "typeId",
        "poef.drank",
        "typeid");

      migrationBuilder.RenameColumn(
        "inStock",
        "poef.drank",
        "instock");

      migrationBuilder.RenameColumn(
        "imageUrl",
        "poef.drank",
        "imageurl");

      migrationBuilder.RenameIndex(
        "IX_poef.drank_typeId",
        table: "poef.drank",
        newName: "IX_poef.drank_typeid");

      migrationBuilder.RenameColumn(
        "takId",
        "leiding",
        "takid");

      migrationBuilder.RenameColumn(
        "leidingSinds",
        "leiding",
        "leidingsinds");

      migrationBuilder.RenameColumn(
        "datumGestopt",
        "leiding",
        "datumgestopt");

      migrationBuilder.RenameColumn(
        "auth0Id",
        "leiding",
        "auth0id");

      migrationBuilder.RenameIndex(
        "IX_leiding_takId",
        table: "leiding",
        newName: "IX_leiding_takid");

      migrationBuilder.AddForeignKey(
        "FK_leiding_tak_takid",
        "leiding",
        "takid",
        "tak",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_poef.drank_poef.drankType_typeid",
        "poef.drank",
        "typeid",
        "poef.drankType",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.adjectief_adjectiefid",
        "totems.entry",
        "adjectiefid",
        "totems.adjectief",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_leiding_leidingid",
        "totems.entry",
        "leidingid",
        "leiding",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.totem_totemid",
        "totems.entry",
        "totemid",
        "totems.totem",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.entry_voorouderid",
        "totems.entry",
        "voorouderid",
        "totems.entry",
        principalColumn: "id",
        onDelete: ReferentialAction.Restrict);
    }
  }
}
