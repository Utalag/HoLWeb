using HoLWeb.DataLayer.Models;

namespace HoLWeb.DataLayer.Interfaces
{
    public interface IProfessionSkillRepository : IGenericRepository<ProfessionSkill>
    {

        IEnumerable<ProfessionSkill> GetSkillClass(SkillClassEnum skillClass);
        Task<IEnumerable<ProfessionSkill>> GetSkillClassAsync(SkillClassEnum skillClass);

        IEnumerable<ProfessionSkill> GetProfessionClass(ProfessionClassEnum professionClass);
        Task<IEnumerable<ProfessionSkill>> ProfessionClassAsync(ProfessionClassEnum professionClass);


        Task<IEnumerable<ProfessionSkill>> KnowledgeGroupAsync(LevelGroupEnum knowledgeGroup);

        Task<IEnumerable<ProfessionSkill>> GetSkillWithFilter_Async(LevelGroupEnum knowledgeGroup,SkillClassEnum skillClass,ProfessionClassEnum professionClass,bool skillsWithDependecies);

    }
}
