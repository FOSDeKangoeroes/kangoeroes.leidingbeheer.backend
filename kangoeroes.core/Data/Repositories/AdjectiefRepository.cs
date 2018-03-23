using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.core.Models.Totems;

namespace kangoeroes.core.Data.Repositories
{
    public class AdjectiefRepository: IAdjectiefRepository
    {
        public IEnumerable<Adjectief> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Adjectief> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Adjectief> FindByNaamAsync(string naam)
        {
            throw new System.NotImplementedException();
        }

        public Task AddAsync(Adjectief adjectief)
        {
            throw new System.NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}