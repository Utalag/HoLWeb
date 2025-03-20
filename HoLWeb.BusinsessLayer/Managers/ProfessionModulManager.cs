using AutoMapper;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using HoLWeb.DataLayer.Database;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HoLWeb.DataLayer.Repositories;

namespace HoLWeb.BusinessLayer.Managers
{
    public class ProfessionModulManager(
        ILogger<DbSet<ProfessionModul>> logger,
        IMapper mapper,
        IGenericRepository<ProfessionModul> genericRepository,
        IProfessionModulRepository modulRepository,
        IProfessionSkillRepository skillRepository,
        INarrativeRepository narrativeRepository
        ) : GenericManager<ProfessionModul,ProfessionModulDto>(logger,mapper,genericRepository), IProfessionManager
    {
        private readonly IProfessionModulRepository modulRepository = modulRepository;
        private readonly IProfessionSkillRepository skillRepository = skillRepository;
        private readonly INarrativeRepository narrativeRepository = narrativeRepository;


        protected override async Task<ProfessionModul> SetDependenciesAsync(ProfessionModul entity,ProfessionModulDto dto)
        {
            entity = await BeginnerSkillDependencies(entity,dto);
            entity = await AdvancedSkillDependencies(entity,dto);
            entity = await ExpertSkillDependencies(entity,dto);
            entity = await NarrativeDependencies(entity,dto);
            return entity;
        }


        // collection dependencies
        private async Task<ProfessionModul> BeginnerSkillDependencies(ProfessionModul entity,ProfessionModulDto dto)
        {
            List<ProfessionSkill> dependencyList = new();

            if(dto.BeginnerSkillIds != null && dto.BeginnerSkillIds.Count != 0)
            {
                foreach(int id in dto.BeginnerSkillIds)
                {
                    var loadEntity = await skillRepository.FindByIdAsync(id);
                    if(loadEntity != null)
                    {
                        dependencyList.Add(loadEntity);
                    }
                }
                entity.BeginnerSkills = dependencyList;
            }
            return entity;
        }
        private async Task<ProfessionModul> AdvancedSkillDependencies(ProfessionModul entity,ProfessionModulDto dto)
        {
            List<ProfessionSkill> dependencyList = new();

            if(dto.AdvancedSkillIds != null && dto.AdvancedSkillIds.Count != 0)
            {
                foreach(int id in dto.AdvancedSkillIds)
                {
                    var loadEntity = await skillRepository.FindByIdAsync(id);
                    if(loadEntity != null)
                    {
                        dependencyList.Add(loadEntity);
                    }
                }
                entity.AdvancedSkills = dependencyList;
            }
            return entity;
        }
        private async Task<ProfessionModul> ExpertSkillDependencies(ProfessionModul entity,ProfessionModulDto dto)
        {
            List<ProfessionSkill> dependencyList = new();

            if(dto.ExpertSkillIds != null && dto.ExpertSkillIds.Count != 0)
            {
                foreach(int id in dto.ExpertSkillIds)
                {
                    var loadEntity = await skillRepository.FindByIdAsync(id);
                    if(loadEntity != null)
                    {
                        dependencyList.Add(loadEntity);
                    }
                }
                entity.ExpertSkills = dependencyList;
            }
            return entity;
        }
        private async Task<ProfessionModul> NarrativeDependencies(ProfessionModul entity,ProfessionModulDto dto)
        {
            List<Narrative> dependencyList = new();
            if(dto.NarrativeIds != null && dto.NarrativeIds.Count != 0)
            {
                foreach(int id in dto.NarrativeIds)
                {
                    var loadEntity = await narrativeRepository.FindByIdAsync(id);
                    if(loadEntity != null)
                    {
                        dependencyList.Add(loadEntity);
                    }
                }
                entity.Narratives = dependencyList;
            }
            return entity;
        }

        

    }
}
