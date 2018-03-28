using System;
using System.Collections.Generic;
using System.Linq;
using kangoeroes.core.Data.Context;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using kangoeroes.core.Helpers;


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

        public PagedList<Leiding> FindAll(LeidingResourceParameters resourceParameters)
        {

            var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

            var result = GetAllWithAllIncluded();
            

            if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
            {
                result = result.Where(x => x.Naam.Contains(resourceParameters.Query) |
                                           x.Voornaam.Contains(resourceParameters.Query) |
                                           x.Email.Contains(resourceParameters.Query));
            }

            if (!string.IsNullOrWhiteSpace(sortString))
            {
                result = result.OrderBy(sortString);
            }
              
            if (resourceParameters.Tak != 0)
            {
                result = result.Where(x => x.Tak.Id == resourceParameters.Tak);
            }

            var pagedList = PagedList<Leiding>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedList;
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