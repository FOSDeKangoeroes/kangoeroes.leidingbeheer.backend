using System.Collections.Generic;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models;

namespace kangoeroes.core.Data.Repositories.Interfaces
{
    public interface ILeidingRepository
    {
        PagedList<Leiding> FindAll(LeidingResourceParameters resourceParameters);
        Leiding FindById(int id);
        void Add(Leiding leiding);
        void Update(Leiding leiding);
        void Delete(Leiding leiding);
        void SaveChanges();
    }
}