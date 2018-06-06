﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kangoeroes.core.Data.Context;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System.Linq.Dynamic.Core;

namespace kangoeroes.core.Data.Repositories
{
    public class TotemRepository : ITotemRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Totem> _totems;

        public TotemRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _totems = _dbContext.Totems;
        }

        private IQueryable<Totem> GetAllWithAllIncluded()
        {
            return _totems;
        }

        public PagedList<Totem> FindAll(ResourceParameters resourceParameters)
        {
            var result = GetAllWithAllIncluded();
            
            var sortString = resourceParameters.SortBy + " " + resourceParameters.SortOrder;

            if (!string.IsNullOrWhiteSpace(resourceParameters.Query))
            {
                result = result.Where(x => x.Naam.Contains(resourceParameters.Query));
                                           
            }
            
            
            if (!string.IsNullOrWhiteSpace(sortString))
            {
                result = result.OrderBy(sortString);
            }

            var pagedList = PagedList<Totem>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedList;
        }

        public Task<Totem> FindByIdAsync(int id)
        {
            return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Totem> FindByNaamAsync(string naam)
        {
            return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Naam == naam);
        }

        public Task AddAsync(Totem totem)
        {
           return _totems.AddAsync(totem);
        }

        public void Delete(Totem totem)
        {
             _totems.Remove(totem);
        }

        public Task SaveChangesAsync()
        {
           return _dbContext.SaveChangesAsync();
        }

        public Task<Totem> TotemExists(string naam)
        {
            return GetAllWithAllIncluded().FirstOrDefaultAsync(x => x.Matches(naam));
        }
    }
}