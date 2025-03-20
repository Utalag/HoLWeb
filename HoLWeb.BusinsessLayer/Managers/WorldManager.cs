using AutoMapper;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Models;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.BusinessLayer.Managers
{
    public class WorldManager : GenericManager<World,WorldDto>, IWorldManager
    {
        private readonly IWorldRepository worldRepository;
        private readonly IRaceRepository raceRepository;
        private readonly INarrativeRepository narrativeRepository;
        private readonly IThumbImgWorldRepository thumbImgRepository;

        public WorldManager(
            ILogger<DbSet<World>> logger,
            IMapper mapper,
            IGenericRepository<World> genericRepository,
            IRaceRepository raceRepository,
            INarrativeRepository narrativeRepository,
            IThumbImgWorldRepository thumbImgRepository,
            IWorldRepository worldRepository
        ) : base(logger,mapper,genericRepository)
        {
            this.worldRepository = worldRepository;
            this.raceRepository = raceRepository;
            this.narrativeRepository = narrativeRepository;
            this.thumbImgRepository = thumbImgRepository;
        }


        public override async Task<IList<WorldDto>> GetAllDataAsync(bool dependencies)
        {

            IList<World> date = await worldRepository.AllAsync(dependencies);
            return mapper.Map<IList<WorldDto>>(date);
        }

        public override IList<WorldDto> GetPage(int page = 0,int pageSize = int.MaxValue,bool dependencies = false)
        {
            IList<World> date = worldRepository.Page(page,pageSize,dependencies);
            return mapper.Map<IList<WorldDto>>(date);
        }
        public override async Task<IList<WorldDto>> GetPageAsyc(int page = 0,int pageSize = int.MaxValue,bool dependencies = false)
        {
            IList<World> date = await worldRepository.PageAsync(page,pageSize,dependencies);
            return mapper.Map<IList<WorldDto>>(date);
        }


        // Dependency methods
        protected override async Task<World> SetDependenciesAsync(World entity,WorldDto dto)
        {
            entity = await RaceDependency(entity,dto);
            entity = await NarrativeDependency(entity,dto);
            entity = await ThumbnailDependency(entity,dto);
            return entity;
        }
        private async Task<World> RaceDependency(World world,WorldDto worldDto)
        {
            List<Race> races = new List<Race>();
            if(worldDto.RaceIds != null && worldDto.RaceIds.Count != 0)
            {
                foreach(int id in worldDto.RaceIds)
                {
                    var race = await raceRepository.FindByIdAsync(id);
                    if(race != null)
                    {
                        races.Add(race);
                    }
                }
                world.Races = races;
            }
            return world;
        }
        private async Task<World> NarrativeDependency(World world,WorldDto worldDto)
        {
            List<Narrative> narratives = new List<Narrative>();
            if(worldDto.NarrativeIds != null && worldDto.NarrativeIds.Count != 0)
            {
                foreach(int id in worldDto.NarrativeIds)
                {
                    var narrative = await narrativeRepository.FindByIdAsync(id);
                    if(narrative != null)
                    {
                        narratives.Add(narrative);
                    }
                }
                world.Narratives = narratives;
            }
            return world;
        }
        private async Task<World> ThumbnailDependency(World world,WorldDto worldDto)
        {
            if(worldDto.ThumbnailImageId != 0)
            {
                var thumb = await thumbImgRepository.FindByIdAsync(worldDto.ThumbnailImageId);
                if(thumb != null)
                {
                    world.ThumbnailImage = thumb;
                }
            }
            return world;
        }


        // Manual mapping
        /*
            private World DtoToWorld(World world,WorldDto worldDto)
        {
            world.WorldName = worldDto.WorldName;
            world.WorldDescription = worldDto.WorldDescription;
            world.AmountOfMagicInTheWorld = worldDto.AmountOfMagicInTheWorld;

            // races map
            if(worldDto.RaceIds != null && worldDto.RaceIds.Count != 0)
            {
                var races = raceRepository.FindByIds(worldDto.RaceIds.ToList());
                if(races != null && races.Any())
                {
                    world.Races = races.ToList();
                }
                else
                    world.Races = new List<Race>();
            }
            // narratives map
            if(worldDto.NarrativeIds != null && worldDto.NarrativeIds.Count != 0)
            {
                var narratives = narrativeRepository.FindByIds(worldDto.NarrativeIds.ToList());
                if(narratives != null && narratives.Any())
                {
                    world.Narratives = narratives.ToList();
                }
            }
            // thumbnail map
            if(worldDto.ThumbnailImageId != 0)
            {
                var thumb = thumbImgRepository.FindById(worldDto.ThumbnailImageId);
                if(thumb != null)
                {
                    world.ThumbnailImage = thumb;
                }
            }
            return world;
        }
            private WorldDto WorldToDto(World world)
        {
            WorldDto worldDto = new WorldDto()
            {
                Id = world.Id,
                WorldName = world.WorldName,
                WorldDescription = world.WorldDescription,
                AmountOfMagicInTheWorld = world.AmountOfMagicInTheWorld,
                RaceIds = world.Races.Select(r => r.Id).ToList(),
                NarrativeIds = world.Narratives.Select(n => n.Id).ToList(),
                ThumbnailImageId = world.ThumbnailImage.Id
            };
            return worldDto;
        }
         */

    }
}
