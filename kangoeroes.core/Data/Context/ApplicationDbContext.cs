using kangoeroes.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kangoeroes.core.Data.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Tak> Takken { get; set; }
        public DbSet<Leiding> Leiding { get; set; }

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
        }

        private static void MapTak(EntityTypeBuilder<Tak> builder)
        {
            builder.ToTable("tak");
        }

        private static void MapLeiding(EntityTypeBuilder<Leiding> builder)
        {
            builder.ToTable("leiding");
        }
    }
}