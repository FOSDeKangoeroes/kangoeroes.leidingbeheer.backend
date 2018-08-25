using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace kangoeroes.leidingBeheer.Migrations
{
  public partial class InitialMigration : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        "poef.drankType",
        table => new
        {
          Id = table.Column<int>("int", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          Naam = table.Column<int>("int", nullable: false)
        },
        constraints: table => { table.PrimaryKey("PK_poef.drankType", x => x.Id); });

      migrationBuilder.CreateTable(
        "tak",
        table => new
        {
          Id = table.Column<int>("int", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          Naam = table.Column<string>("longtext", nullable: true),
          Volgorde = table.Column<int>("int", nullable: false)
        },
        constraints: table => { table.PrimaryKey("PK_tak", x => x.Id); });

      migrationBuilder.CreateTable(
        "totems.adjectief",
        table => new
        {
          Id = table.Column<int>("int", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          CreatedOn = table.Column<DateTime>("datetime(6)", nullable: false),
          Naam = table.Column<string>("longtext", nullable: true)
        },
        constraints: table => { table.PrimaryKey("PK_totems.adjectief", x => x.Id); });

      migrationBuilder.CreateTable(
        "totems.totem",
        table => new
        {
          Id = table.Column<int>("int", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          CreatedOn = table.Column<DateTime>("datetime(6)", nullable: false),
          Naam = table.Column<string>("longtext", nullable: true)
        },
        constraints: table => { table.PrimaryKey("PK_totems.totem", x => x.Id); });

      migrationBuilder.CreateTable(
        "poef.drank",
        table => new
        {
          Id = table.Column<int>("int", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          ImageUrl = table.Column<string>("longtext", nullable: true),
          InStock = table.Column<bool>("bit", nullable: false),
          Naam = table.Column<string>("longtext", nullable: true),
          TypeId = table.Column<int>("int", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_poef.drank", x => x.Id);
          table.ForeignKey(
            "FK_poef.drank_poef.drankType_TypeId",
            x => x.TypeId,
            "poef.drankType",
            "Id",
            onDelete: ReferentialAction.Restrict);
        });

      migrationBuilder.CreateTable(
        "leiding",
        table => new
        {
          Id = table.Column<int>("int", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          Auth0Id = table.Column<string>("longtext", nullable: true),
          DatumGestopt = table.Column<DateTime>("datetime(6)", nullable: false),
          Email = table.Column<string>("longtext", nullable: true),
          LeidingSinds = table.Column<DateTime>("datetime(6)", nullable: false),
          Naam = table.Column<string>("longtext", nullable: true),
          TakId = table.Column<int>("int", nullable: true),
          Voornaam = table.Column<string>("longtext", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_leiding", x => x.Id);
          table.ForeignKey(
            "FK_leiding_tak_TakId",
            x => x.TakId,
            "tak",
            "Id",
            onDelete: ReferentialAction.Restrict);
        });

      migrationBuilder.CreateTable(
        "totems.entry",
        table => new
        {
          Id = table.Column<int>("int", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
          AdjectiefId = table.Column<int>("int", nullable: true),
          DatumGegeven = table.Column<DateTime>("datetime(6)", nullable: false),
          LeidingId = table.Column<int>("int", nullable: true),
          TotemId = table.Column<int>("int", nullable: true),
          VoorouderId = table.Column<int>("int", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_totems.entry", x => x.Id);
          table.ForeignKey(
            "FK_totems.entry_totems.adjectief_AdjectiefId",
            x => x.AdjectiefId,
            "totems.adjectief",
            "Id",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            "FK_totems.entry_leiding_LeidingId",
            x => x.LeidingId,
            "leiding",
            "Id",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            "FK_totems.entry_totems.totem_TotemId",
            x => x.TotemId,
            "totems.totem",
            "Id",
            onDelete: ReferentialAction.Restrict);
          table.ForeignKey(
            "FK_totems.entry_totems.entry_VoorouderId",
            x => x.VoorouderId,
            "totems.entry",
            "Id",
            onDelete: ReferentialAction.Restrict);
        });

      migrationBuilder.CreateIndex(
        "IX_leiding_TakId",
        "leiding",
        "TakId");

      migrationBuilder.CreateIndex(
        "IX_poef.drank_TypeId",
        "poef.drank",
        "TypeId");

      migrationBuilder.CreateIndex(
        "IX_totems.entry_AdjectiefId",
        "totems.entry",
        "AdjectiefId");

      migrationBuilder.CreateIndex(
        "IX_totems.entry_LeidingId",
        "totems.entry",
        "LeidingId");

      migrationBuilder.CreateIndex(
        "IX_totems.entry_TotemId",
        "totems.entry",
        "TotemId");

      migrationBuilder.CreateIndex(
        "IX_totems.entry_VoorouderId",
        "totems.entry",
        "VoorouderId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        "poef.drank");

      migrationBuilder.DropTable(
        "totems.entry");

      migrationBuilder.DropTable(
        "poef.drankType");

      migrationBuilder.DropTable(
        "totems.adjectief");

      migrationBuilder.DropTable(
        "leiding");

      migrationBuilder.DropTable(
        "totems.totem");

      migrationBuilder.DropTable(
        "tak");
    }
  }
}
