using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.DTOs.Leader;
using kangoeroes.core.Exceptions;
using kangoeroes.core.Interfaces.Repositories;
using kangoeroes.core.Interfaces.Services;
using kangoeroes.core.Models;
using kangoeroes.core.Models.Accounting;

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
            //Check if a section is provided for the leader
            Tak tak = null;
            if (dto.TakId != 0)
            {
                tak = await _takRepository.FindByIdAsync(dto.TakId);
                if (tak == null)
                {
                    throw new EntityNotFoundException($"Tak met id {dto.TakId} werd niet gevonden.");
                }
            }


            //Map the dto to the leader entity. TODO: This smells fishy. I don't like new()
            var leader = new Leiding
            {
                Naam = dto.Naam.Trim(),
                Voornaam = dto.Voornaam.Trim(),
                LeidingSinds = dto.LeidingSinds.ToLocalTime(),
                Tak = tak,
                Email = dto.Email.Trim().ToLower(),
                Accounts = new List<Account>(2)
            };

            //Only create accounts if needed. E.g.: leaders created through the totemdatabase probably shouldn't have an account at first.
            if (dto.CreateAccounts)
            {
                leader.Accounts.Add(new Account(AccountType.Debt));
                leader.Accounts.Add(new Account(AccountType.Tab));
            }


            await _leidingRepository.AddAsync(leader);
            await _leidingRepository.SaveChangesAsync();

            return _mapper.Map<BasicLeaderDTO>(leader);
        }

        public async Task<BasicLeaderDTO> UpdateLeader(int leaderId, UpdateLeaderDTO dto)
        {
            var leader = await _leidingRepository.FindByIdAsync(leaderId);

            if (leader == null)
            {
                throw new EntityNotFoundException($"Leiding met id {leaderId} werd niet gevonden.");
            }

            leader.Email = dto.Email?.Trim().ToLower();
            leader.Naam = dto.Naam.Trim();
            leader.Voornaam = dto.Voornaam.Trim();
            leader.LeidingSinds = dto.LeidingSinds.ToLocalTime();
            leader.DatumGestopt = dto.DatumGestopt.ToLocalTime();
            await _leidingRepository.SaveChangesAsync();

            var model = _mapper.Map<BasicLeaderDTO>(leader);

            return model;
        }

        public async Task<BasicLeaderDTO> ChangeSectionOfLeader(int leaderId, UpdateSectionDTO dto)
        {
            var leader = await _leidingRepository.FindByIdAsync(leaderId);

            if (leader == null)
            {
                throw new EntityNotFoundException($"Leiding met id {leaderId} werd niet gevonden.");
            }

            var newSection = await _takRepository.FindByIdAsync(dto.NewSectionId);

            if (newSection == null)
            {
                throw new EntityNotFoundException($"Nieuwe tak met id {dto.NewSectionId} werd niet gevonden.");
            }

            leader.Tak = newSection;

            await _leidingRepository.SaveChangesAsync();

            var model = _mapper.Map<BasicLeaderDTO>(leader);

            return model;
        }

        public async Task CreateAccountForLeader(int leaderId, decimal debtStartBalance, decimal tabStartBalance)
        {
            var leader = await _leidingRepository.FindByIdAsync(leaderId);

            var debtAccount = new Account(AccountType.Debt)
            {
                Balance = debtStartBalance
            };
            var tabAccount = new Account(AccountType.Tab)
            {
                Balance = tabStartBalance
            };

            leader.Accounts.Add(debtAccount);
            leader.Accounts.Add(tabAccount);

           await _leidingRepository.SaveChangesAsync();
        }
    }
}