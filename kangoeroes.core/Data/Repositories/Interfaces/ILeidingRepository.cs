using System.Collections.Generic;
using kangoeroes.core.Models;

namespace kangoeroes.core.Data.Repositories.Interfaces
{
    public interface ILeidingRepository
    {
        IEnumerable<Leiding> FindAll();
        IEnumerable<Leiding> FindAll(string sortBy);
        IEnumerable<Leiding> FindAll(string searchString, string sortString);
            Leiding FindById(int id);
        void Add(Leiding leiding);
        void Update(Leiding leiding);
        void Delete(Leiding leiding);
        void SaveChanges();
    }
}