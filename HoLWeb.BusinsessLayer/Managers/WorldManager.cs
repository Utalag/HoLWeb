using AutoMapper;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Models;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.BusinessLayer.Managers
{
    public class WorldManager : GenericManager<World,WorldDto>, IWorldManager
    {
        private readonly IWorldRepository worldRepository;
        private readonly IRaceRepository raceRepository;
        private readonly INarrativeRepository narrativeRepository;
        private readonly IThumbnailImageRepository thumbImgRepository;
        private readonly INarrativeManager narrativeManager;
        private readonly IRaceManager raceManager;

        public WorldManager(
            ILogger<DbSet<World>> logger,
            IMapper mapper,
            IGenericRepository<World> genericRepository,
            IRaceRepository raceRepository,
            INarrativeRepository narrativeRepository,
            IThumbnailImageRepository thumbImgRepository,
            IWorldRepository worldRepository,
            INarrativeManager narrativeManager,
            IRaceManager raceManager
        ) : base(logger,mapper,genericRepository)
        {
            this.worldRepository = worldRepository;
            this.raceRepository = raceRepository;
            this.narrativeRepository = narrativeRepository;
            this.thumbImgRepository = thumbImgRepository;
            this.narrativeManager = narrativeManager;
            this.raceManager = raceManager;
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
        public override async Task<WorldDto?> GetDateByIdAsync(int id,bool dependencies = false)
        {
            World? data = await worldRepository.FindByIdAsync(id,dependencies);
            if(data is null)
                return null;
            return mapper.Map<WorldDto>(data);
        }

        // Dependency methods
        protected override async Task<World> SetDependenciesAsync(World entity,WorldDto dto)
        {
            entity = await RaceDependency(entity,dto);
            entity = await NarrativeDependency(entity,dto);
            //entity = await ThumbnailDependency(entity,dto);
            return entity;
        }
        private async Task<World> RaceDependency(World world,WorldDto worldDto)
        {
            List<Race> races = new List<Race>();
            IList<Race> allRaces = await raceRepository.AllAsync();
            if(worldDto.RaceIds != null && worldDto.RaceIds.Count != 0)
            {
                foreach(int id in worldDto.RaceIds)
                {
                    //var race = await raceRepository.FindByIdAsync(id);
                    var race = allRaces.Where(r => r.Id == id).FirstOrDefault();
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

        

        public override async Task<WorldDto> AddDataAsync(WorldDto dto)
        {
            List<NarrativeDto> dtoNarrativs = dto.Narratives;
            World createdWorld = new World();
            World insertedWorld = mapper.Map<World>(dto);
            insertedWorld = await SetDependenciesAsync(insertedWorld,dto);
            try
            {
                createdWorld = await worldRepository.InsertAsync(insertedWorld);
            }
            catch(Exception ex)
            {

                logger.LogError(ex,$"Error while creating {nameof(World)}");
                throw;
            }

            if(dtoNarrativs != null && dtoNarrativs.Count != 0)
            {
                foreach(var narrativ in dtoNarrativs)
                {
                    Narrative newNarrativ = mapper.Map<Narrative>(narrativ);
                    newNarrativ.World = createdWorld;
                    var ner = await narrativeRepository.InsertAsync(newNarrativ);
                }
            }
            var created = await worldRepository.FindByIdAsync(createdWorld.Id);
            return mapper.Map<WorldDto>(created);

        }

        //private async Task<World> ThumbnailDependency(World world,WorldDto worldDto)
        //{
        //    if(worldDto.ThumbnailImageId != 0)
        //    {
        //        var thumb = await thumbImgRepository.FindByIdAsync(worldDto.ThumbnailImageId);
        //        if(thumb.Id != 0 || thumb != null)
        //        {
        //            world.ThumbnailImage = thumb;
        //        }
        //        world.ThumbnailImageId = worldDto.ThumbnailImageId;

        //    }
        //    return world;
        //}

        public async Task<WorldDto?> GetWorld(int id)
        {
            World? worlds = await worldRepository.FindByIdAsync(id,true);
            if(worlds is null)
            {
                return new WorldDto();
            }
            var dto = mapper.Map<WorldDto>(worlds);
            // fill Narratives
            List<int> narrativIds = dto.NarrativeIds.ToList();
            dto.Narratives.AddRange(await narrativeManager.GetDataByIdsAsync(narrativIds,false));
            
            // fill Races
            List<int> raceIds = dto.RaceIds.ToList();
            dto.Races.AddRange(await raceManager.GetDataByIdsAsync(raceIds,false));
            
            // fill ThumbnailImage
            //dto.ThumbnailImage = await thumbImgRepository.FindByIdAsync(dto.ThumbnailImageId);

            return dto;

        }
    }
}
