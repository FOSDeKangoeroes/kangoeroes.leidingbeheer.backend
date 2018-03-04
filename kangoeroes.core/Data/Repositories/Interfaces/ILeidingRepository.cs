using System.Collections.Generic;
using kangoeroes.core.Models;

namespace kangoeroes.core.Data.Repositories.Interfaces
{
    public interface ILeidingRepository
    {
        IEnumerable<Leiding> FindAll(string searchString = "", string sortString = "naam", int takId = 0);
        Leiding FindById(int id);
        void Add(Leiding leiding);
        void Update(Leiding leiding);
        void Delete(Leiding leiding);
        void SaveChanges();
    }
}