using System.Threading.Tasks;
using kangoeroes.core.Models.Poef;
using System.Collections.Generic;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.webUI.DTOs.Tab.Drink;

namespace kangoeroes.webUI.Services.PoefServices.Interfaces
{
    public interface IDrankService
    {
        PagedList<Drank> GetAll(ResourceParameters resourceParameters);
        Task<Drank> GetDrankById(int drankId);
        Task<Drank> CreateDrank(AddDrankViewModel viewModel);
        Task<Drank> UpdateDrank(int drankId, UpdateDrankViewModel viewModel);
        Task DeleteDrank(int drankId);
        Task<PagedList<Drank>> GetDrankenForType(int drankTypeId, ResourceParameters resourceParameters);

        Task<IEnumerable<Prijs>> GetPricesForDrank(int drankId);
    }
}
