using kangoeroes.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace kangoeroes.core.Data.Context
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Tak> Takken { get; set; }

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
        }

        private static void MapTak(EntityTypeBuilder<Tak> builder)
        {
            builder.ToTable("tak");
        }
    }
}