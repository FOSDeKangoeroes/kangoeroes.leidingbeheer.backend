using System.Collections.Generic;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models;

namespace kangoeroes.core.Data.Repositories.Interfaces
{
    public interface ITakRepository
    {
        PagedList<Tak> FindAll(ResourceParameters resourceParameters) ;

        Tak FindById(int id);

        Tak FindByNaam(string name);

        void Add(Tak tak);

        void Delete(Tak tak);

        void Update(Tak tak);

        void SaveChanges();
    }
}