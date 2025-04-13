using AutoMapper;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Models;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.BusinessLayer.Managers
{
    public class RaceManager(
        ILogger<DbSet<Race>> logger,
        IMapper mapper,
        IGenericRepository<Race> repository,
        IRaceRepository raceRepository,
        IWorldRepository worldRepository,
        IRaceStatRepository raceStatRepository,
        IThumbnailImageRepository thumbImgRepository
        ) : GenericManager<Race,RaceDto>(logger,mapper,repository), IRaceManager
    {
        private readonly IRaceRepository raceRepository = raceRepository;
        private readonly IWorldRepository worldRepository = worldRepository;
        private readonly IRaceStatRepository raceStatRepository = raceStatRepository;
        private readonly IThumbnailImageRepository thumbImgRepository = thumbImgRepository;

        public override async Task<IList<RaceDto>> GetAllDataAsync(bool dependencies = false)
        {
            IList<Race> date = await genericRepository.AllAsync(true);
            return mapper.Map<IList<RaceDto>>(date);
        }

        protected override async Task<Race> SetDependenciesAsync(Race entity,RaceDto dto)
        {
            entity = await WorldDependencies(entity,dto);
            entity = await StrengthDependency(entity,dto);
            entity = await AgilityDependency(entity,dto);
            entity = await ConstitutionDependency(entity,dto);
            entity = await IntelligenceDependency(entity,dto);
            entity = await CharismaDependency(entity,dto);
            entity = await ThumbnailDependency(entity,dto);

            return entity;
        }

        // collection dependencies
        private async Task<Race> WorldDependencies(Race entity,RaceDto dto)
        {
            List<World> dependencyList = new();
            if(dto.WorldIds != null && dto.WorldIds.Count != 0)
            {
                foreach(int id in dto.WorldIds)
                {
                    var loadEntity = await worldRepository.FindByIdAsync(id);
                    if(loadEntity != null)
                    {
                        dependencyList.Add(loadEntity);
                    }
                }
                entity.Worlds = dependencyList;
            }
            return entity;
        }
        // single dependencies
        private async Task<Race> StrengthDependency(Race entity,RaceDto dto)
        {
            if(dto.StrengthStatId > 0)
            {
                var loadEntity = await raceStatRepository.FindByIdAsync(dto.StrengthStatId.Value);
                if(loadEntity != null)
                {
                    entity.StrengthStat = loadEntity;
                }
            }
            return entity;
        }
        private async Task<Race> AgilityDependency(Race entity,RaceDto dto)
        {
            if(dto.AgilityStatId > 0)
            {
                var loadEntity = await raceStatRepository.FindByIdAsync(dto.AgilityStatId.Value);
                if(loadEntity != null)
                {
                    entity.AgilityStat = loadEntity;
                }
            }
            return entity;
        }
        private async Task<Race> ConstitutionDependency(Race entity,RaceDto dto)
        {
            if(dto.ConstitutionStatId > 0)
            {
                var loadEntity = await raceStatRepository.FindByIdAsync(dto.ConstitutionStatId.Value);
                if(loadEntity != null)
                {
                    entity.ConstitutionStat = loadEntity;
                }
            }
            return entity;

        }
        private async Task<Race> IntelligenceDependency(Race entity,RaceDto dto)
        {
            if(dto.IntelligenceStatId > 0)
            {
                var loadEntity = await raceStatRepository.FindByIdAsync(dto.IntelligenceStatId.Value);
                if(loadEntity != null)
                {
                    entity.IntelligenceStat = loadEntity;
                }
            }
            return entity;

        }
        private async Task<Race> CharismaDependency(Race entity,RaceDto dto)
        {
            if(dto.CharismaStatId > 0)
            {
                var loadEntity = await raceStatRepository.FindByIdAsync(dto.CharismaStatId.Value);
                if(loadEntity != null)
                {
                    entity.CharismaStat = loadEntity;
                }
            }
            return entity;

        }
        private async Task<Race> ThumbnailDependency(Race entity,RaceDto dto)
        {
            if(dto.ThumbnailImageId > 0)
            {
                var loadEntity = await thumbImgRepository.FindByIdAsync(dto.ThumbnailImageId);
                if(loadEntity != null)
                {
                    entity.ThumbnailImage = loadEntity;
                }
            }
            return entity;

        }

    }
}
