using kangoeroes.core.Models;
using kangoeroes.leidingBeheer.Helpers;

namespace kangoeroes.leidingBeheer.Data.Repositories.Interfaces
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