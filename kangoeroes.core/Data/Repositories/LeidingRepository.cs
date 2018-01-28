using System;
using System.Collections.Generic;
using System.Linq;
using kangoeroes.core.Data.Context;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;


namespace kangoeroes.core.Data.Repositories
{
    public class LeidingRepository : ILeidingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Leiding> _leiding;

        public LeidingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _leiding = _dbContext.Leiding;
        }

        private IQueryable<Leiding> GetAllWithAllIncluded()
        {
            return _leiding.Include(x => x.Tak);
        }

        public IEnumerable<Leiding> FindAll()
        {
            return GetAllWithAllIncluded().ToList();
        }

        public IEnumerable<Leiding> FindAll(string sortBy)
        {
            return GetAllWithAllIncluded().OrderBy(sortBy).ToList();
        }

        public IEnumerable<Leiding> FindAll(string searchString, string sortString)
        {
            //Tijdelijke hack. Should NOT be here

            if (sortString.Trim() == String.Empty)
            {
                sortString = "naam";
            }

            return GetAllWithAllIncluded().Where(x => x.Naam.Contains(searchString) |
                                                      x.Voornaam.Contains(searchString) |
                                                      x.Email.Contains(searchString)
                )
                .OrderBy(sortString);
        }


        public Leiding FindById(int id)
        {
            return GetAllWithAllIncluded().FirstOrDefault(x => x.Id == id);
        }

        public void Add(Leiding leiding)
        {
            _leiding.Add(leiding);
        }

        public void Update(Leiding leiding)
        {
            _leiding.Update(leiding);
        }

        public void Delete(Leiding leiding)
        {
            _leiding.Remove(leiding);
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}