using System.Net;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Totems;
using kangoeroes.infrastructure;
using kangoeroes.infrastructure.Repositories;
using kangoeroes.infrastructure.Repositories.TotemsRepositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace kangoeroes.test.Repositories
{
    public class TotemEntryRepositoryTest
    {
        private Leiding _leader1;

        private Leiding _leader2;

        private Adjectief _adjective;

        private Totem _totem;

        private readonly ApplicationDbContext _dbContext;
        
        
        public TotemEntryRepositoryTest()
        {
            _adjective = new Adjectief
            {
                Naam = "Wijze"
            };
            
            _totem = new Totem
            {
                Naam = "Nachtegaal"
            };
            
            _leader1 = new Leiding
            {
                Naam = "pierlala",
                Voornaam = "Jantje"
            };
            
            _leader2 = new Leiding
            {
                Naam = "Lothbrok",
                Voornaam = "Ragnar"
            };
            
           _dbContext = CreateDbContext();

            _dbContext.Adjectieven.Add(_adjective);
            _dbContext.Leiding.Add(_leader1);
            _dbContext.Leiding.Add(_leader2);
            _dbContext.Totems.Add(_totem);
            _dbContext.SaveChanges();


        }
        
        [Fact]
        public async void SearchForFirstNameReturnsCorrectEntries()
        {
            var repo = new TotemEntryRepository(_dbContext);
            
            var totemEntry = new TotemEntry
            {
                Adjectief = _adjective,
                Leiding = _leader2,
                Totem = _totem
            };

            _dbContext.TotemEntries.Add(totemEntry);
            _dbContext.SaveChanges();
            
            var resourceParameters = new ResourceParameters
            {
                Query = "rag"
            };


            var result = repo.FindAll(resourceParameters);
            
            Assert.Single(result);
        }
        

        private ApplicationDbContext CreateDbContext()
        {
            DbContextOptions<ApplicationDbContext> options;
            
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            dbContextOptionsBuilder.UseInMemoryDatabase(databaseName: "totemEntryDatabase");

            options = dbContextOptionsBuilder.Options;
            
            ApplicationDbContext dbContext = new ApplicationDbContext(options);

            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            return dbContext;
        }
    }
}