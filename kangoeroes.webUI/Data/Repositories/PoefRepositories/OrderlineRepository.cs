using System.Threading.Tasks;
using kangoeroes.core.Helpers;
using kangoeroes.core.Helpers.ResourceParameters;
using kangoeroes.core.Models.Poef;
using kangoeroes.webUI.Data.Context;
using kangoeroes.webUI.Data.Repositories.PoefRepositories.Interfaces;
using kangoeroes.webUI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace kangoeroes.webUI.Data.Repositories.PoefRepositories
{
  public class OrderlineRepository: BaseRepository<Orderline>, IOrderlineRepository
  {
    private readonly DbSet<Orderline> _orderlines;

    public OrderlineRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
      _orderlines = dbContext.Orderlines;
    }

    public override PagedList<Orderline> FindAll(ResourceParameters resourceParameters)
    {
      throw new System.NotImplementedException();
    }

    public override Task<Orderline> FindByIdAsync(int id)
    {
      return _orderlines.FirstOrDefaultAsync(x => x.Id == id);
    }
  }
}
