using AutoMapper;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Models;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.BusinessLayer.Managers
{
    public class ProfessionSkillManager(
        ILogger<DbSet<ProfessionSkill>> logger,
        IMapper mapper,
        IGenericRepository<ProfessionSkill> repository,
        IProfessionSkillRepository professionSkillRepository)
        : GenericManager<ProfessionSkill,ProfessionSkillDto>(logger,mapper,repository), IProfessionSkillManager
    {
        private readonly IProfessionSkillRepository professionSkillRepository = professionSkillRepository;



        // ----------------- Filtered dependency data by level  -----------------
        public SpecificSkillDto GetProfessionSkillByLevel(ProfessionSkillDto skill,int level)
        {
            var data = skill.BaseSpecificSkills.Where(x => x.ProfessionClass == skill.ProfessionClass).Where(x => x.Level <= level).LastOrDefault();
            return mapper.Map<SpecificSkillDto>(data);
        }

        // ----------------- SkillClassEnum -----------------
        public List<ProfessionSkillDto> GetAllProfessionSkillBySkillClass(SkillClassEnum skillClass)
        {
            var skills = mapper.Map<List<ProfessionSkillDto>>(professionSkillRepository.GetSkillClass(skillClass));
            return skills;
        }
        public List<ProfessionSkillDto> GetAllProfessionSkillBySkillClassAsync(SkillClassEnum skillClass)
        {
            var skills = mapper.Map<List<ProfessionSkillDto>>(professionSkillRepository.GetSkillClassAsync(skillClass));
            return skills;
        }
        //----------------- KnowledgeGroupEnum -----------------
        public List<ProfessionSkillDto> GetAllProfessionSkillByKnowledgeGroup(LevelGroupEnum knowledgeGroup)
        {
            var skills = mapper.Map<List<ProfessionSkillDto>>(professionSkillRepository.KnowledgeGroupAsync(knowledgeGroup));
            return skills;
        }
        public List<ProfessionSkillDto> GetAllProfessionSkillByKnowledgeGroupAsync(LevelGroupEnum knowledgeGroup)
        {
            var skills = mapper.Map<List<ProfessionSkillDto>>(professionSkillRepository.KnowledgeGroupAsync(knowledgeGroup));
            return skills;
        }
        //----------------- ProfessionClassEnum -----------------
        public List<ProfessionSkillDto> GetAllProfessionSkillByProfessionClass(ProfessionClassEnum professionClass)
        {
            var skills = mapper.Map<List<ProfessionSkillDto>>(professionSkillRepository.GetProfessionClass(professionClass));
            return skills;
        }
        public List<ProfessionSkillDto> GetAllProfessionSkillByProfessionClassAsync(ProfessionClassEnum professionClass)
        {
            var skills = mapper.Map<List<ProfessionSkillDto>>(professionSkillRepository.ProfessionClassAsync(professionClass));
            return skills;
        }
        //----------------- GetProfessionSkillWithFilter -----------------

        public async Task<List<ProfessionSkillDto>> GetProfessionSkillWithFilter_Async(LevelGroupEnum knowledgeGroup = LevelGroupEnum.all,SkillClassEnum skillClass = SkillClassEnum.allSkill,ProfessionClassEnum professionClass = ProfessionClassEnum.all,bool skillsWithDependecies = false)
        {
            var skills = mapper.Map<List<ProfessionSkillDto>>(await professionSkillRepository.GetSkillWithFilter_Async(knowledgeGroup,skillClass,professionClass,skillsWithDependecies));
            return skills;
        }

        protected override Task<ProfessionSkill> SetDependenciesAsync(ProfessionSkill entity,ProfessionSkillDto dto)
        {
            return Task.FromResult(entity);
        }
    }
}
