using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.Data.Context;
using kangoeroes.leidingBeheer.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Helpers;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.leidingBeheer.Data.Repositories
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

        private IQueryable<Tak> GetAllWithAllIncluded()
        {
            return _takken.Include(x => x.Leiding);
        }
     

        public PagedList<Tak> FindAll(ResourceParameters resourceParameters)
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

            var pagedList = PagedList<Tak>.Create(result, resourceParameters.PageNumber, resourceParameters.PageSize);

            return pagedList;
        }

        public Tak FindById(int id)
        {
            return GetAllWithAllIncluded().FirstOrDefault(x => x.Id == id);
        }

        public Tak FindByNaam(string naam)
        {
            return GetAllWithAllIncluded().FirstOrDefault(x => x.Naam == naam);
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