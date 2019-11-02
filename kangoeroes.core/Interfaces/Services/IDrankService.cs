using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.DTOs.Tab.Drink;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;

namespace kangoeroes.core.Interfaces.Services
{
    public interface IDrankService
    {
        PagedList<Drank> GetAll(ResourceParameters resourceParameters);
        Task<Drank> GetDrankById(int drankId);
        Task<Drank> CreateDrank(CreateDrinkDTO viewModel);
        Task<Drank> UpdateDrank(int drankId, UpdateDrinkDTO viewModel);
        Task DeleteDrank(int drankId);
        Task<PagedList<Drank>> GetDrankenForType(int drankTypeId, ResourceParameters resourceParameters);

        Task<IEnumerable<Prijs>> GetPricesForDrank(int drankId);
    }
}
