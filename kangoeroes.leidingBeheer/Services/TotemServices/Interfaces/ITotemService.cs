﻿using System.Collections.Generic;
using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Models.Totems;
using kangoeroes.leidingBeheer.Models.ViewModels.Totem;

namespace kangoeroes.leidingBeheer.Services.TotemServices.Interfaces
{
  public interface ITotemService
  {
    PagedList<Totem> FindAll(ResourceParameters resourceParameters);
    Task<BasicTotemViewModel> FindByIdAsync(int id);
    Task<BasicTotemViewModel> AddTotemAsync(AddTotemViewModel viewModel);
    Task<BasicTotemViewModel> UpdateTotemAsync(UpdateTotemViewModel viewModel, int id);
  }
}