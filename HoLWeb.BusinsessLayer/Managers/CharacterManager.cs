using AutoMapper;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Models;
using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using HoLWeb.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.BusinessLayer.Managers
{
    public class CharacterManager(IGenericRepository<Character> genericRepository,ILogger<DbSet<Character>> logger,IMapper mapper,
        IRaceRepository raceRepository,
        ICharacterStatRepository characterStatRepository,
        IThumbImgCharacterRepository thumbImgRepository,
        IProfessionSkillRepository skillRepository,
        ICharacterRepository characterRepository
        ) : GenericManager<Character,CharacterDto>(logger,mapper,genericRepository), ICharacterManager
    {
        private readonly IRaceRepository raceRepository = raceRepository;
        private readonly ICharacterStatRepository characterStatRepository = characterStatRepository;
        private readonly IThumbImgCharacterRepository thumbImgRepository = thumbImgRepository;
        private readonly IProfessionSkillRepository skillRepository= skillRepository;
        private readonly ICharacterRepository characterRepository = characterRepository;



        //public override IList<CharacterDto> GetAllData(bool dependencies = false)
        //{
        //    IList<Character> date = characterRepository.All(dependencies);
        //    var dto = mapper.Map<IList<CharacterDto>>(date);
        //    return dto;
        //}

        //public override CharacterDto GetDateById(int id,bool dependencies = false)
        //{
        //    Character? data = characterRepository.FindById(id);
        //    if(data is null)
        //        return null;

        //    var dto = mapper.Map<CharacterDto>(data);
        //    dto.Strength = data.StrengthStatId == 0 ? new CharacterStatDto() : characterStatRepository.FindById(data.StrengthStatId);
        //    dto.Agility = data.AgilityStatId == 0 ? new CharacterStatDto() : statManager.GetDateById(data.AgilityStatId);
        //    dto.Constitution = data.ConstitutionStatId == 0 ? new CharacterStatDto() : statManager.GetDateById(data.ConstitutionStatId);
        //    dto.Intelligence = data.IntelligenceStatId == 0 ? new CharacterStatDto() : statManager.GetDateById(data.IntelligenceStatId);
        //    dto.Charisma = data.CharismaStatId == 0 ? new CharacterStatDto() : statManager.GetDateById(data.CharismaStatId);
        //    return dto;
        //}



        public CharacterDto SetDefaultAtributeAsRaceRange(CharacterDto character,RaceDto raceData)
        {
            if(character == null || raceData == null)
            {
                logger.LogError("Character or RaceData is null");
                return null;
            }
            character.Strength.RangeLow = raceData.StrengthStat.RangeLow;
            character.Strength.RangeHigh = raceData.StrengthStat.RangeHigh;
            character.Agility.RangeLow = raceData.AgilityStat.RangeLow;
            character.Agility.RangeHigh = raceData.AgilityStat.RangeHigh;
            character.Constitution.RangeLow = raceData.ConstitutionStat.RangeLow;
            character.Constitution.RangeHigh = raceData.ConstitutionStat.RangeHigh;
            character.Intelligence.RangeLow = raceData.IntelligenceStat.RangeLow;
            character.Intelligence.RangeHigh = raceData.IntelligenceStat.RangeHigh;
            character.Charisma.RangeLow = raceData.CharismaStat.RangeLow;
            character.Charisma.RangeHigh = raceData.CharismaStat.RangeHigh;
            return character;
        }

        public CharacterDto SetOnePrimaryAtribut(CharacterDto character,RaceDto race,AtributEnum atribute,int index = 0)
        {

            switch(atribute)
            {
                case AtributEnum.strength:
                {
                    character.Strength.RangeLow = character.EnhancedStrength[index] + race.StrengthStat.Correction;
                    character.Strength.RangeHigh = character.EnhancedStrength[index] + race.StrengthStat.Correction + 5;
                }
                break;

                case AtributEnum.agility:
                {
                    character.Agility.RangeLow = character.EnhancedAgility[index] + race.AgilityStat.Correction;
                    character.Agility.RangeHigh = character.EnhancedAgility[index] + race.AgilityStat.Correction + 5;
                }
                break;
                case AtributEnum.constitution:
                {
                    character.Constitution.RangeLow = character.EnhancedConstitution[index] + race.ConstitutionStat.Correction;
                    character.Constitution.RangeHigh = character.EnhancedConstitution[index] + race.ConstitutionStat.Correction + 5;
                }
                break;
                case AtributEnum.intelligence:
                {
                    character.Intelligence.RangeLow = character.EnhancedIntelligence[index] + race.IntelligenceStat.Correction;
                    character.Intelligence.RangeHigh = character.EnhancedIntelligence[index] + race.IntelligenceStat.Correction + 5;
                }
                break;
                case AtributEnum.charisma:
                {
                    character.Charisma.RangeLow = character.EnhancedCharisma[index] + race.CharismaStat.Correction;
                    character.Charisma.RangeHigh = character.EnhancedCharisma[index] + race.CharismaStat.Correction + 5;
                }
                break;
            }
            return character;
        }





        protected override async Task<Character> SetDependenciesAsync(Character entity,CharacterDto dto)
        {
            entity = await StrengthDependency(entity,dto);
            entity = await AgilityDependency(entity,dto);
            entity = await ConstitutionDependency(entity,dto);
            entity = await IntelligenceDependency(entity,dto);
            entity = await CharismaDependency(entity,dto);
            entity = await ThumbnailDependency(entity,dto);
            entity = await SkillsDependencies(entity,dto);
            return entity;

        }
        // collection dependencies
        private async Task<Character> SkillsDependencies(Character entity,CharacterDto dto)
        {
            List<ProfessionSkill> dependencyList = [];
            if(dto.IndividualProfessionSkillIds != null && dto.IndividualProfessionSkillIds.Count != 0)
            {
                foreach(int id in dto.IndividualProfessionSkillIds)
                {
                    var loadEntity = await skillRepository.FindByIdAsync(id);
                    if(loadEntity != null)
                    {
                        dependencyList.Add(loadEntity);
                    }
                }
                entity.IndividualProfessionSkills = dependencyList;
            }
            return entity;
        }
        // single dependencies
        private async Task<Character> StrengthDependency(Character entity,CharacterDto dto)
        {
            if(dto.StrengthStatId > 0)
            {
                var loadEntity = await characterStatRepository.FindByIdAsync(dto.StrengthStatId);
                if(loadEntity != null)
                {
                    entity.NavForStrengthStat = loadEntity;
                }
            }
            return entity;
        }
        private async Task<Character> AgilityDependency(Character entity,CharacterDto dto)
        {
            if(dto.AgilityStatId > 0)
            {
                var loadEntity = await characterStatRepository.FindByIdAsync(dto.AgilityStatId);
                if(loadEntity != null)
                {
                    entity.NavForAgilityStat = loadEntity;
                }
            }
            return entity;
        }
        private async Task<Character> ConstitutionDependency(Character entity,CharacterDto dto)
        {
            if(dto.ConstitutionStatId > 0)
            {
                var loadEntity = await characterStatRepository.FindByIdAsync(dto.ConstitutionStatId);
                if(loadEntity != null)
                {
                    entity.NavForConstitutionStat = loadEntity;
                }
            }
            return entity;

        }
        private async Task<Character> IntelligenceDependency(Character entity,CharacterDto dto)
        {
            if(dto.IntelligenceStatId > 0)
            {
                var loadEntity = await characterStatRepository.FindByIdAsync(dto.IntelligenceStatId);
                if(loadEntity != null)
                {
                    entity.NavForIntelligenceStat = loadEntity;
                }
            }
            return entity;

        }
        private async Task<Character> CharismaDependency(Character entity,CharacterDto dto)
        {
            if(dto.CharismaStatId > 0)
            {
                var loadEntity = await characterStatRepository.FindByIdAsync(dto.CharismaStatId);
                if(loadEntity != null)
                {
                    entity.NavForCharismaStat = loadEntity;
                }
            }
            return entity;

        }
        private async Task<Character> ThumbnailDependency(Character entity,CharacterDto dto)
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


    };
}
