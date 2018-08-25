using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.leidingBeheer.Migrations
{
  public partial class EnforceRequiredColumns : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
        "FK_leiding_tak_TakId",
        "leiding");

      migrationBuilder.DropForeignKey(
        "FK_poef.drank_poef.drankType_TypeId",
        "poef.drank");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.adjectief_AdjectiefId",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_leiding_LeidingId",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.totem_TotemId",
        "totems.entry");

      migrationBuilder.DropForeignKey(
        "FK_totems.entry_totems.entry_VoorouderId",
        "totems.entry");

      migrationBuilder.RenameColumn(
        "Naam",
        "totems.totem",
        "naam");

      migrationBuilder.RenameColumn(
        "CreatedOn",
        "totems.totem",
        "createdon");

      migrationBuilder.RenameColumn(
        "Id",
        "totems.totem",
        "id");

      migrationBuilder.RenameColumn(
        "VoorouderId",
        "totems.entry",
        "voorouderid");

      migrationBuilder.RenameColumn(
        "TotemId",
        "totems.entry",
        "totemid");

      migrationBuilder.RenameColumn(
        "LeidingId",
        "totems.entry",
        "leidingid");

      migrationBuilder.RenameColumn(
        "DatumGegeven",
        "totems.entry",
        "datumgegeven");

      migrationBuilder.RenameColumn(
        "AdjectiefId",
        "totems.entry",
        "adjectiefid");

      migrationBuilder.RenameColumn(
        "Id",
        "totems.entry",
        "id");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_VoorouderId",
        table: "totems.entry",
        newName: "IX_totems.entry_voorouderid");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_TotemId",
        table: "totems.entry",
        newName: "IX_totems.entry_totemid");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_LeidingId",
        table: "totems.entry",
        newName: "IX_totems.entry_leidingid");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_AdjectiefId",
        table: "totems.entry",
        newName: "IX_totems.entry_adjectiefid");

      migrationBuilder.RenameColumn(
        "Naam",
        "totems.adjectief",
        "naam");

      migrationBuilder.RenameColumn(
        "CreatedOn",
        "totems.adjectief",
        "createdon");

      migrationBuilder.RenameColumn(
        "Id",
        "totems.adjectief",
        "id");

      migrationBuilder.RenameColumn(
        "Volgorde",
        "tak",
        "volgorde");

      migrationBuilder.RenameColumn(
        "Naam",
        "tak",
        "naam");

      migrationBuilder.RenameColumn(
        "Id",
        "tak",
        "id");

      migrationBuilder.RenameColumn(
        "Naam",
        "poef.drankType",
        "naam");

      migrationBuilder.RenameColumn(
        "Id",
        "poef.drankType",
        "id");

      migrationBuilder.RenameColumn(
        "TypeId",
        "poef.drank",
        "typeid");

      migrationBuilder.RenameColumn(
        "Naam",
        "poef.drank",
        "naam");

      migrationBuilder.RenameColumn(
        "InStock",
        "poef.drank",
        "instock");

      migrationBuilder.RenameColumn(
        "ImageUrl",
        "poef.drank",
        "imageurl");

      migrationBuilder.RenameColumn(
        "Id",
        "poef.drank",
        "id");

      migrationBuilder.RenameIndex(
        "IX_poef.drank_TypeId",
        table: "poef.drank",
        newName: "IX_poef.drank_typeid");

      migrationBuilder.RenameColumn(
        "Voornaam",
        "leiding",
        "voornaam");

      migrationBuilder.RenameColumn(
        "TakId",
        "leiding",
        "takid");

      migrationBuilder.RenameColumn(
        "Naam",
        "leiding",
        "naam");

      migrationBuilder.RenameColumn(
        "LeidingSinds",
        "leiding",
        "leidingsinds");

      migrationBuilder.RenameColumn(
        "Email",
        "leiding",
        "email");

      migrationBuilder.RenameColumn(
        "DatumGestopt",
        "leiding",
        "datumgestopt");

      migrationBuilder.RenameColumn(
        "Auth0Id",
        "leiding",
        "auth0id");

      migrationBuilder.RenameColumn(
        "Id",
        "leiding",
        "id");

      migrationBuilder.RenameIndex(
        "IX_leiding_TakId",
        table: "leiding",
        newName: "IX_leiding_takid");

      migrationBuilder.AlterColumn<string>(
        "naam",
        "totems.totem",
        "longtext",
        nullable: false,
        oldClrType: typeof(string),
        oldNullable: true);

      migrationBuilder.AlterColumn<string>(
        "naam",
        "totems.adjectief",
        "longtext",
        nullable: false,
        oldClrType: typeof(string),
        oldNullable: true);

      migrationBuilder.AlterColumn<string>(
        "naam",
        "tak",
        "longtext",
        nullable: false,
        oldClrType: typeof(string),
        oldNullable: true);

      migrationBuilder.AlterColumn<string>(
        "naam",
        "poef.drank",
        "longtext",
        nullable: false,
        oldClrType: typeof(string),
        oldNullable: true);

      migrationBuilder.AlterColumn<string>(
        "voornaam",
        "leiding",
        "longtext",
        nullable: false,
        oldClrType: typeof(string),
        oldNullable: true);

      migrationBuilder.AlterColumn<string>(
        "naam",
        "leiding",
        "longtext",
        nullable: false,
        oldClrType: typeof(string),
        oldNullable: true);

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

    protected override void Down(MigrationBuilder migrationBuilder)
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
        "naam",
        "totems.totem",
        "Naam");

      migrationBuilder.RenameColumn(
        "createdon",
        "totems.totem",
        "CreatedOn");

      migrationBuilder.RenameColumn(
        "id",
        "totems.totem",
        "Id");

      migrationBuilder.RenameColumn(
        "voorouderid",
        "totems.entry",
        "VoorouderId");

      migrationBuilder.RenameColumn(
        "totemid",
        "totems.entry",
        "TotemId");

      migrationBuilder.RenameColumn(
        "leidingid",
        "totems.entry",
        "LeidingId");

      migrationBuilder.RenameColumn(
        "datumgegeven",
        "totems.entry",
        "DatumGegeven");

      migrationBuilder.RenameColumn(
        "adjectiefid",
        "totems.entry",
        "AdjectiefId");

      migrationBuilder.RenameColumn(
        "id",
        "totems.entry",
        "Id");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_voorouderid",
        table: "totems.entry",
        newName: "IX_totems.entry_VoorouderId");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_totemid",
        table: "totems.entry",
        newName: "IX_totems.entry_TotemId");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_leidingid",
        table: "totems.entry",
        newName: "IX_totems.entry_LeidingId");

      migrationBuilder.RenameIndex(
        "IX_totems.entry_adjectiefid",
        table: "totems.entry",
        newName: "IX_totems.entry_AdjectiefId");

      migrationBuilder.RenameColumn(
        "naam",
        "totems.adjectief",
        "Naam");

      migrationBuilder.RenameColumn(
        "createdon",
        "totems.adjectief",
        "CreatedOn");

      migrationBuilder.RenameColumn(
        "id",
        "totems.adjectief",
        "Id");

      migrationBuilder.RenameColumn(
        "volgorde",
        "tak",
        "Volgorde");

      migrationBuilder.RenameColumn(
        "naam",
        "tak",
        "Naam");

      migrationBuilder.RenameColumn(
        "id",
        "tak",
        "Id");

      migrationBuilder.RenameColumn(
        "naam",
        "poef.drankType",
        "Naam");

      migrationBuilder.RenameColumn(
        "id",
        "poef.drankType",
        "Id");

      migrationBuilder.RenameColumn(
        "typeid",
        "poef.drank",
        "TypeId");

      migrationBuilder.RenameColumn(
        "naam",
        "poef.drank",
        "Naam");

      migrationBuilder.RenameColumn(
        "instock",
        "poef.drank",
        "InStock");

      migrationBuilder.RenameColumn(
        "imageurl",
        "poef.drank",
        "ImageUrl");

      migrationBuilder.RenameColumn(
        "id",
        "poef.drank",
        "Id");

      migrationBuilder.RenameIndex(
        "IX_poef.drank_typeid",
        table: "poef.drank",
        newName: "IX_poef.drank_TypeId");

      migrationBuilder.RenameColumn(
        "voornaam",
        "leiding",
        "Voornaam");

      migrationBuilder.RenameColumn(
        "takid",
        "leiding",
        "TakId");

      migrationBuilder.RenameColumn(
        "naam",
        "leiding",
        "Naam");

      migrationBuilder.RenameColumn(
        "leidingsinds",
        "leiding",
        "LeidingSinds");

      migrationBuilder.RenameColumn(
        "email",
        "leiding",
        "Email");

      migrationBuilder.RenameColumn(
        "datumgestopt",
        "leiding",
        "DatumGestopt");

      migrationBuilder.RenameColumn(
        "auth0id",
        "leiding",
        "Auth0Id");

      migrationBuilder.RenameColumn(
        "id",
        "leiding",
        "Id");

      migrationBuilder.RenameIndex(
        "IX_leiding_takid",
        table: "leiding",
        newName: "IX_leiding_TakId");

      migrationBuilder.AlterColumn<string>(
        "Naam",
        "totems.totem",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "longtext");

      migrationBuilder.AlterColumn<string>(
        "Naam",
        "totems.adjectief",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "longtext");

      migrationBuilder.AlterColumn<string>(
        "Naam",
        "tak",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "longtext");

      migrationBuilder.AlterColumn<string>(
        "Naam",
        "poef.drank",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "longtext");

      migrationBuilder.AlterColumn<string>(
        "Voornaam",
        "leiding",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "longtext");

      migrationBuilder.AlterColumn<string>(
        "Naam",
        "leiding",
        nullable: true,
        oldClrType: typeof(string),
        oldType: "longtext");

      migrationBuilder.AddForeignKey(
        "FK_leiding_tak_TakId",
        "leiding",
        "TakId",
        "tak",
        principalColumn: "Id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_poef.drank_poef.drankType_TypeId",
        "poef.drank",
        "TypeId",
        "poef.drankType",
        principalColumn: "Id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.adjectief_AdjectiefId",
        "totems.entry",
        "AdjectiefId",
        "totems.adjectief",
        principalColumn: "Id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_leiding_LeidingId",
        "totems.entry",
        "LeidingId",
        "leiding",
        principalColumn: "Id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.totem_TotemId",
        "totems.entry",
        "TotemId",
        "totems.totem",
        principalColumn: "Id",
        onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
        "FK_totems.entry_totems.entry_VoorouderId",
        "totems.entry",
        "VoorouderId",
        "totems.entry",
        principalColumn: "Id",
        onDelete: ReferentialAction.Restrict);
    }
  }
}
