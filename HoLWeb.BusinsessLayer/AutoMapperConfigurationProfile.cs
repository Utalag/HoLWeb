

using AutoMapper;
using HoLWeb.DataLayer.Models;
using HoLWeb.DataLayer.Models.GeneralAttributes;
using HoLWeb.DataLayer.Models.SkillsModels;
using HoLWeb.DataLayer.Models.ThumbModels;
using HoLWeb.BusinessLayer.Models;


namespace HoLWeb.BusinessLayer
{
    public class AutoMapperConfigurationProfile : Profile
    {

        public AutoMapperConfigurationProfile()
        {
            Map_ProfessionModul();
            Map_Race();
            Map_World();
            Map_Narrative();
            Map_Character();
            Map_ProfessionSkill();
            Map_SpecificSkill();
            Map_RaceStat();
            Map_CharacterStat();
            Map_ThumbnailImage();
            Map_ValueTuple();
        }

        private void Map_ProfessionModul()
        {
            CreateMap<ProfessionModul,ProfessionModulDto>()
                .ForMember(m => m.BeginnerSkillIds,opt => opt.MapFrom(m => m.BeginnerSkills != null ? m.BeginnerSkills.Select(s => s.Id).ToList() : new List<int>()))
                .ForMember(m => m.AdvancedSkillIds,opt => opt.MapFrom(m => m.AdvancedSkills != null ? m.AdvancedSkills.Select(s => s.Id).ToList() : new List<int>()))
                .ForMember(m => m.ExpertSkillIds,opt => opt.MapFrom(m => m.ExpertSkills != null ? m.ExpertSkills.Select(s => s.Id).ToList() : new List<int>()));

            //.ForMember(m => m.NarrativeIds,opt => opt.MapFrom(m => m.Narratives != null ? m.Narratives.Select(s => s.Id).ToList() : new List<int>()));



            CreateMap<ProfessionModulDto,ProfessionModul>()
                .ForMember(s => s.BeginnerSkills,opt => opt.Ignore())
                .ForMember(s => s.AdvancedSkills,opt => opt.Ignore())
                .ForMember(s => s.ExpertSkills,opt => opt.Ignore());

            //.ForMember(s => s.BeginnerSkills,opt => opt.MapFrom(s => s.BeginnerSkillIds.Select(id => professionRepository.FindById(id)).Where(skill => skill != null).ToList()));

        }
        private void Map_RaceStat()
        {
            CreateMap<RaceStat,RaceStatDto>();
            CreateMap<RaceStatDto,RaceStat>();
        }
        private void Map_CharacterStat()
        {
            CreateMap<CharacterStat,CharacterStatDto>();
            CreateMap<CharacterStatDto,CharacterStat>();
        }
        private void Map_Race()
        {
            CreateMap<Race,RaceDto>();
            CreateMap<RaceDto,Race>();
        }
        private void Map_World()
        {
            CreateMap<World,WorldDto>()
                .ForMember(m => m.RaceIds,opt => opt.MapFrom(m => m.Races.Select(s => s.Id).ToList()))
                .ForMember(n => n.NarrativeIds,opt => opt.MapFrom(n => n.Narratives.Select(s => s.Id).ToList()))
                .ForMember(img => img.ThumbnailImageId,opt => opt.MapFrom(img => img.ThumbnailImage.Id))

                .ForMember(pl=>pl.Players,opt => opt.MapFrom(pl => pl.Players.Select(s => s.Id).ToList()))
                

                .ForMember(ignore => ignore.Narratives,opt=>opt.Ignore())
                .ForMember(ignore => ignore.Races,opt => opt.Ignore())
                .ForMember(ignore => ignore.ThumbnailImage,opt => opt.Ignore());

            CreateMap<WorldDto,World>()
                .ForMember(m => m.Narratives,opt => opt.Ignore())
                .ForMember(m => m.Races,opt => opt.Ignore())
                .ForMember(m => m.ThumbnailImage,opt => opt.Ignore());
        }
        private void Map_Narrative()
        {
            CreateMap<Narrative,NarrativeDto>()
                .ForMember(w => w.WorldId,opt => opt.MapFrom(w => w.World != null ? w.World.Id : 0))
                .ForMember(i => i.ThumbnailImageId,opt => opt.MapFrom(i => i.ThumbnailImage != null ? i.ThumbnailImage.Id : 0))
                .ForMember(m => m.RaceIds,opt => opt.MapFrom(m => m.World != null && m.World.Races != null ? m.World.Races.Select(s => s.Id).ToList() : new List<int>()))
                .ForMember(c => c.CharacterIds,opt => opt.MapFrom(c => c.Characters.Select(s => s.Id)))
                .ForMember(p => p.ProfessionModulIds,opt => opt.MapFrom(p => p.ProfessionModules.Select(s => s.Id)))
                .ForMember(p => p.PlayersGuids,opt => opt.MapFrom(p => p.Players.Select(s => s.Id).ToList()))
                .ForMember(g => g.GameMasterGuid,opt => opt.MapFrom(g => g.GameMaster != null ? g.GameMaster.Id.ToString() : ""))

                .ForMember(ignore => ignore.Characters,opt => opt.Ignore())
                .ForMember(ignore => ignore.World,opt => opt.Ignore())
                .ForMember(ignore => ignore.ProfessionModules,opt => opt.Ignore());

            CreateMap<NarrativeDto,Narrative>()
                .ForMember(w => w.World,opt => opt.Ignore())
                .ForMember(c => c.Characters,opt => opt.Ignore())
                .ForMember(p => p.ProfessionModules,opt => opt.Ignore())
                .ForMember(t => t.ThumbnailImage,opt => opt.Ignore());

        }
        private void Map_Character()
        {
            CreateMap<Character,CharacterDto>()
                .ForMember(s => s.Strength,opt => opt.MapFrom(s => s.NavForStrengthStat))
                .ForMember(a => a.Agility,opt => opt.MapFrom(a => a.NavForAgilityStat))
                .ForMember(c => c.Constitution,opt => opt.MapFrom(c => c.NavForConstitutionStat))
                .ForMember(i => i.Intelligence,opt => opt.MapFrom(i => i.NavForIntelligenceStat))
                .ForMember(ch => ch.Charisma,opt => opt.MapFrom(ch => ch.NavForCharismaStat))
                
                .ForMember(w=>w.WorldId,opt => opt.MapFrom(w => w.Narrative.WorldId))
                .ForMember(n => n.NarrativeId,opt => opt.MapFrom(n => n.NarrativeId))
                .ForMember(t=>t.ThumbnailImageId,opt => opt.MapFrom(t => t.ThumbnailImage.Id))
                .ForMember(ip => ip.IndividualProfessionSkillIds,opt => opt.MapFrom(ip => ip.IndividualProfessionSkills.Select(s => s.Id).ToList()));
            
            CreateMap<CharacterDto,Character>()
                .ForMember(s => s.NavForStrengthStat,opt => opt.Ignore())
                .ForMember(a => a.NavForAgilityStat,opt => opt.Ignore())
                .ForMember(c => c.NavForConstitutionStat,opt => opt.Ignore())
                .ForMember(i => i.NavForIntelligenceStat,opt => opt.Ignore())
                .ForMember(ch => ch.NavForCharismaStat,opt => opt.Ignore())

                .ForMember(w => w.Narrative,opt => opt.Ignore())
                .ForMember(t => t.ThumbnailImage,opt => opt.Ignore())
                .ForMember(ip => ip.IndividualProfessionSkills,opt => opt.Ignore());
        }
        private void Map_ProfessionSkill()
        {
            CreateMap<ProfessionSkill,ProfessionSkillDto>();
            CreateMap<ProfessionSkillDto,ProfessionSkill>();
            // .ForMember(dest => dest.SkillClass,opt => opt.MapFrom(src => src.SkillClass));
        }
        private void Map_SpecificSkill()
        {
            CreateMap<BaseSpecificSkill,SpecificSkillDto>();
        }
        private void Map_ThumbnailImage()
        {   //Model to Dto
            CreateMap<ThumbImgRace,ThumbnailImageDto>()
                .ForMember(r => r.RaceId,opt => opt.MapFrom(r => r.RaceId));
            CreateMap<ThumbImgWorld,ThumbnailImageDto>()
                .ForMember(w => w.WorldId,opt => opt.MapFrom(w => w.WorldId));
            CreateMap<ThumbImgCharacter,ThumbnailImageDto>()
                .ForMember(c => c.CharacterId,opt => opt.MapFrom(c => c.CharacterId));
            CreateMap<ThumbImgNarrative,ThumbnailImageDto>()
                .ForMember(n => n.NarrativeId,opt => opt.MapFrom(n => n.NarrativeId));

            //Dto to Model
            CreateMap<ThumbnailImageDto,ThumbImgRace>()
                .ForMember(r => r.Race,opt => opt.Ignore());
            CreateMap<ThumbnailImageDto,ThumbImgWorld>()
                .ForMember(w => w.World,opt => opt.Ignore());
            CreateMap<ThumbnailImageDto,ThumbImgCharacter>()
                .ForMember(c => c.Character,opt => opt.Ignore());
            CreateMap<ThumbnailImageDto,ThumbImgNarrative>()
                .ForMember(n=>n.Narrative,opt => opt.Ignore());
        }
        private void Map_ValueTuple()
        {
            CreateMap<Tuple<int,int>,int[]>()
            .ConvertUsing(tuple => new int[] { tuple.Item1,tuple.Item2 });
        }
    }
}

