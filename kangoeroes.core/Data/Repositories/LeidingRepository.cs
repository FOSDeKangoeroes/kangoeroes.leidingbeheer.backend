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

        //Helper method to get all leiding with all dependencies already included
        private IQueryable<Leiding> GetAllWithAllIncluded()
        {
            return _leiding.Include(x => x.Tak);
        }

        public IEnumerable<Leiding> FindAll(string searchString = "", string sortString = "naam", int takId = 0)
        {
            var result = GetAllWithAllIncluded().Where(x => x.Naam.Contains(searchString) |
                                                            x.Voornaam.Contains(searchString) |
                                                            x.Email.Contains(searchString)
            );

            if (sortString.Trim() != String.Empty)
            {
                result = result.OrderBy(sortString);
            }
              
            if (takId != 0)
            {
                result = result.Where(x => x.Tak.Id == takId);
            }

            return result.ToList();
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