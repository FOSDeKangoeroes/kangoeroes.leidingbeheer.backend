using kangoeroes.core.Models;
using kangoeroes.core.Models.Poef;
using kangoeroes.core.Models.Totems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kangoeroes.infrastructure
{
  public class ApplicationDbContext : DbContext
  {
    #region DbSets

        public DbSet<Tak> Takken { get; set; }
        public DbSet<Leiding> Leiding { get; set; }
        public DbSet<Totem> Totems { get; set; }
        public DbSet<Adjectief> Adjectieven { get; set; }
        public DbSet<TotemEntry> TotemEntries { get; set; }
        public DbSet<DrankType> DrankTypes { get; set; }
        public DbSet<Drank> Dranken { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Orderline> Orderlines { get; set; }

    #endregion



    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Tak>(MapTak);
      modelBuilder.Entity<Leiding>(MapLeiding);
      modelBuilder.Entity<Totem>(MapTotem);
      modelBuilder.Entity<Adjectief>(MapAdjectief);
      modelBuilder.Entity<TotemEntry>(MapTotemEntry);
      modelBuilder.Entity<DrankType>(MapDrankType);
      modelBuilder.Entity<Drank>(MapDrank);
      modelBuilder.Entity<Prijs>(MapPrijs);
      modelBuilder.Entity<Order>(MapOrder);
      modelBuilder.Entity<Orderline>(MapOrderline);

      // Alle entiteiten omzetten van PascalCase naar camelCase.
      foreach (var entity in modelBuilder.Model.GetEntityTypes())
      {
        foreach (var property in entity.GetProperties())
        {
          property.Relational().ColumnName = char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1);
        }
      }
    }



    #region Mapping methods


    private static void MapTak(EntityTypeBuilder<Tak> builder)
    {
      builder.ToTable("tak");
      builder.Property(x => x.Naam).IsRequired();
    }

    private static void MapLeiding(EntityTypeBuilder<Leiding> builder)
    {
      builder.ToTable("leiding");
      builder.Property(x => x.Naam).IsRequired();
      builder.Property(x => x.Voornaam).IsRequired();
    }

    private static void MapTotem(EntityTypeBuilder<Totem> builder)
    {
      builder.ToTable("totems.totem");
      builder.Property(x => x.Naam).IsRequired();
    }

    private static void MapAdjectief(EntityTypeBuilder<Adjectief> builder)
    {
      builder.ToTable("totems.adjectief");
      builder.Property(x => x.Naam).IsRequired();
    }

    private static void MapTotemEntry(EntityTypeBuilder<TotemEntry> builder)
    {
      builder.ToTable("totems.entry");

      builder.HasOne(x => x.Adjectief);
      builder.HasOne(x => x.Leiding);
      builder.HasOne(x => x.Totem);

    }

    private static void MapDrankType(EntityTypeBuilder<DrankType> builder)
    {
      builder.ToTable("poef.drankType");
      builder.HasIndex(x => x.Naam).IsUnique();
      builder.HasKey(x => x.Id);
      builder.Property(x => x.Naam).IsRequired();


    }

    private static void MapDrank(EntityTypeBuilder<Drank> builder)
    {

      builder.ToTable("poef.drank");
      builder.Property(x => x.Naam).IsRequired();
      builder.HasKey(x => x.Id);
      builder.HasIndex(x => x.Naam).IsUnique();
      builder.HasOne(x => x.Type).WithMany(x => x.Dranken);
    }

    private void MapPrijs(EntityTypeBuilder<Prijs> builder)
    {
      builder.ToTable("poef.prijs");
      builder.HasKey(x => x.Id);
      builder.Property(x => x.CreatedOn).IsRequired();
      builder.Property(x => x.Waarde).IsRequired();
      builder.HasOne(x => x.Drank).WithMany(x => x.Prijzen).IsRequired();
    }

    private void MapOrder(EntityTypeBuilder<Order> builder)
    {
      builder.ToTable("poef.order");
      builder.Property(x => x.CreatedOn).IsRequired();
      builder.HasKey(x => x.Id);
      builder.HasOne(x => x.OrderedBy).WithMany(x => x.Orders).IsRequired();
      builder.HasMany(x => x.Orderlines).WithOne(x => x.Order).IsRequired();

    }

    private void MapOrderline(EntityTypeBuilder<Orderline> builder)
    {
      builder.ToTable("poef.orderline");
      builder.HasKey(x => x.Id);
      builder.HasOne(x => x.Drank).WithMany(x => x.Orderlines).IsRequired();
      builder.HasOne(x => x.OrderedFor).WithMany(x => x.Consumpties).IsRequired();
      builder.Property(x => x.DrinkPrice).IsRequired();

    }


    #endregion
  }
}
