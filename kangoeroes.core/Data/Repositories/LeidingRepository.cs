using System.Collections.Generic;
using System.Linq;
using kangoeroes.core.Data.Context;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Models;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.core.Data.Repositories
{
    public class LeidingRepository: ILeidingRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Leiding> _leiding;

        public LeidingRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _leiding = _dbContext.Leiding;
        }
        public IEnumerable<Leiding> GetAll()
        {
            return _leiding.Include(x => x.Tak).ToList();
        }

        public Leiding FindById(int id)
        {
            return _leiding.Include(x => x.Tak).FirstOrDefault(x => x.Id == id);
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