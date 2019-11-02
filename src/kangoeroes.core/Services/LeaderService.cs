using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Leader;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models;

namespace kangoeroes.core.Services
{
    public class LeaderService : ILeaderService
    {
        private readonly ITakRepository _takRepository;
        private readonly ILeidingRepository _leidingRepository;
        private readonly IMapper _mapper;

        public LeaderService(ITakRepository takRepository, ILeidingRepository leidingRepository, IMapper mapper)
        {
            _leidingRepository = leidingRepository;
            _takRepository = takRepository;
            _mapper = mapper;
        }

        public async Task<BasicLeaderDTO> CreateLeader(CreateLeaderDTO dto)
        {
            Tak tak = null;
            if (dto.TakId != 0)
            {
                tak = await _takRepository.FindByIdAsync(dto.TakId);
                if (tak == null)
                {
                    throw new EntityNotFoundException($"Tak met id {dto.TakId} werd niet gevonden.");
                }
            }

            var leader = new Leiding
            {
                Naam = dto.Naam.Trim(),
                Voornaam = dto.Voornaam.Trim(),
                LeidingSinds = dto.LeidingSinds.ToLocalTime(),
                Tak = tak
            };

            await _leidingRepository.AddAsync(leader);
            await _leidingRepository.SaveChangesAsync();

            return _mapper.Map<BasicLeaderDTO>(leader);
        }
    }
}