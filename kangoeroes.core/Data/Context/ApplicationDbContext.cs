using kangoeroes.core.Models;
using kangoeroes.core.Models.Totems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kangoeroes.core.Data.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Tak> Takken { get; set; }
        public DbSet<Leiding> Leiding { get; set; }
        public DbSet<Totem> Totems { get; set; } 
        public DbSet<Adjectief> Adjectieven { get; set; }
        public DbSet<TotemEntry> TotemEntries { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Tak>(MapTak);
            modelBuilder.Entity<Leiding>(MapLeiding);
            modelBuilder.Entity<Totem>(MapTotem);
            modelBuilder.Entity<Adjectief>(MapAdjectief);
            modelBuilder.Entity<TotemEntry>(MapTotemEntry);
        }

        private static void MapTak(EntityTypeBuilder<Tak> builder)
        {
            builder.ToTable("tak");
        }

        private static void MapLeiding(EntityTypeBuilder<Leiding> builder)
        {
            builder.ToTable("leiding");
        }
        
        private static void MapTotem(EntityTypeBuilder<Totem> builder)
        {
            builder.ToTable("totems.totem");
        }
        
        private static void MapAdjectief(EntityTypeBuilder<Adjectief> builder)
        {
            builder.ToTable("totems.adjectief");
        }
        
        private static void MapTotemEntry(EntityTypeBuilder<TotemEntry> builder)
        {
            builder.ToTable("totems.entry");
        }
    }
}