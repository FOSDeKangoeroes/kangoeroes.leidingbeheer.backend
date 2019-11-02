using System.Threading.Tasks;
using kangoeroes.core.DTOs.Leader;

namespace kangoeroes.core.Interfaces.Services
{
    public interface ILeaderService
    {
        Task<BasicLeaderDTO> CreateLeader(CreateLeaderDTO dto);
    }
}