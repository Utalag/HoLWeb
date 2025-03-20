using AutoMapper;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Managers;
using HoLWeb.BusinessLayer.Models;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using HoLWeb.DataLayer.Models.IdentityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



public class NarrativeManager(ILogger<DbSet<Narrative>> logger,IMapper mapper,IGenericRepository<Narrative> repository,
    INarrativeRepository narrativeRepository,
    IWorldRepository worldRepository,
    IThumbImgNarrativeRepository thumbImgNarrativeRepository,
    ICharacterRepository characterRepository,
    IProfessionModulRepository professionModulRepository,
    UserManager<ApplicationUser> userManager
    ) : GenericManager<Narrative,NarrativeDto>(logger,mapper,repository), INarrativeManager
{
    private readonly INarrativeRepository narrativeRepository = narrativeRepository;
    private readonly IWorldRepository worldRepository = worldRepository;
    private readonly IThumbImgNarrativeRepository thumbImgNarrativeRepository= thumbImgNarrativeRepository;
    private readonly ICharacterRepository characterRepository= characterRepository;
    private readonly IProfessionModulRepository professionModulRepository= professionModulRepository;
    private readonly UserManager<ApplicationUser> userManager= userManager;




    protected override async Task<Narrative> SetDependenciesAsync(Narrative entity,NarrativeDto dto)
    {
        entity = await ThumbnailDependency(entity,dto);
        entity = await GameMasterDependency(entity,dto);
        entity = await WorldDependency(entity,dto);
        entity = await CharacterDependency(entity,dto);
        entity = await ProfessionModulDependency(entity,dto);
        entity = await PlayersDependency(entity,dto);
        return entity;
    }

    // collection dependencies
    private async Task<Narrative> CharacterDependency(Narrative entity,NarrativeDto dto)
    {
        List<Character> dependencyList = new();
        if(dto.CharacterIds != null && dto.CharacterIds.Count != 0)
        {
            foreach(int id in dto.CharacterIds)
            {
                var loadEntity = await characterRepository.FindByIdAsync(id);
                if(loadEntity != null)
                {
                    dependencyList.Add(loadEntity);
                }
            }
            entity.Characters = dependencyList;
        }
        return entity;
    }
    private async Task<Narrative> ProfessionModulDependency(Narrative entity,NarrativeDto dto)
    {
        List<ProfessionModul> dependencyList = new();
        if(dto.ProfessionModulIds != null && dto.ProfessionModulIds.Count != 0)
        {
            foreach(int id in dto.ProfessionModulIds)
            {
                var loadEntity = await professionModulRepository.FindByIdAsync(id);
                if(loadEntity != null)
                {
                    dependencyList.Add(loadEntity);
                }
            }
            entity.ProfessionModules = dependencyList;
        }
        return entity;
    }
    private async Task<Narrative> PlayersDependency(Narrative entity,NarrativeDto dto)
    {
        List<ApplicationUser> dependencyList = new List<ApplicationUser>();
        if(dto.PlayersGuids != null && dto.PlayersGuids.Count != 0)
        {
            foreach(var id in dto.PlayersGuids)
            {
                var loadEntity = await userManager.FindByIdAsync(id.ToString());
                if(loadEntity != null)
                {
                    dependencyList.Add(loadEntity);
                }
            }
            entity.Players = dependencyList;
        }
        return entity;
    }

    // single dependencies
    private async Task<Narrative> ThumbnailDependency(Narrative entity,NarrativeDto dto)
    {
        if(dto.ThumbnailImageId != 0)
        {
            var thumb = await thumbImgNarrativeRepository.FindByIdAsync(dto.ThumbnailImageId);
            if(thumb != null)
            {
                entity.ThumbnailImage = thumb;
            }
        }
        return entity;
    }
    private async Task<Narrative> GameMasterDependency(Narrative entity,NarrativeDto dto)
    {
        if(dto.GameMasterGuid != null)
        {
            var gm = await userManager.FindByIdAsync(dto.GameMasterGuid);
            if(gm != null)
            {
                entity.GameMaster = gm;
            }
        }
        return entity;
    }
    private async Task<Narrative> WorldDependency(Narrative entity,NarrativeDto dto)
    {
        if(dto.WorldId != 0)
        {
            var world = await worldRepository.FindByIdAsync(dto.WorldId);
            if(world != null)
            {
                entity.World = world;
            }
        }
        return entity;
    }

}
