using System;
using System.Collections.Generic;
using System.Linq;
using kangoeroes.core.Data.Context;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Models;
using Microsoft.EntityFrameworkCore;


namespace kangoeroes.core.Data.Repositories
{
    public class TakRepository: ITakRepository
    {

        private readonly DbSet<Tak> _takken;
        private readonly ApplicationDbContext _dbContext;

        public TakRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _takken = dbContext.Takken;
        }
        public IEnumerable<Tak> GetAll()
        {
       
            return _takken.Include(x => x.Leiding).OrderBy(x => x.Volgorde).ToList();
        }

        public Tak FindById(int id)
        {
            return _takken.Include(x => x.Leiding).FirstOrDefault(x => x.Id == id);
        }

        public Tak FindByNaam(string naam)
        {
            return _takken.Include(x => x.Leiding).FirstOrDefault(x => x.Naam == naam);
        }

        public void Add(Tak tak)
        {
            _takken.Add(tak);
        }

        public void Delete(Tak tak)
        {
            if (tak.Leiding.Count > 0)
            {
                throw new ArgumentException("Tak bevat nog leiding. Verwijder eerst de leiding uit de tak vooraleer de tak te verwijderen.");
            }
            _takken.Remove(tak);
        }

        public void Update(Tak tak)
        {
            _takken.Update(tak);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}