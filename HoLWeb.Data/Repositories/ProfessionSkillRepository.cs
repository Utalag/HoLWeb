using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class ProfessionSkillRepository : GenericRepository<ProfessionSkill>, IProfessionSkillRepository
    {
        public ProfessionSkillRepository(HoLWebDbContext db,ILogger<DbSet<ProfessionSkill>> logger) : base(db,logger)
        {
        }

        public IEnumerable<ProfessionSkill> GetSkillClass(SkillClassEnum skillClass)
        {
            try
            {
                var skills = dbSet.Where(s => s.SkillClass == skillClass).ToList();
                if(!skills.Any())
                {
                    logger.LogWarning("Skills not found");
                    return new List<ProfessionSkill>();
                }
                return skills;
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"An error occurred while getting skills for profession {ProfessionModul}",skillClass);
                return new List<ProfessionSkill>();
            }
        }
        public async Task<IEnumerable<ProfessionSkill>> GetSkillClassAsync(SkillClassEnum skillClass)
        {
            try
            {
                var skills = await dbSet.Where(s => s.SkillClass == skillClass).ToListAsync();
                if(skills == null || !skills.Any())
                {
                    logger.LogWarning("Skills not found for skill class {SkillClass}",skillClass);
                    return new List<ProfessionSkill>();
                }
                return skills;
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"An error occurred while getting skills for skill class {SkillClass}",skillClass);
                return new List<ProfessionSkill>();
            }
        }
        public IEnumerable<ProfessionSkill> GetProfessionClass(ProfessionClassEnum professionClass)
        {
            try
            {
                var skills = dbSet.Where(s => s.ProfessionClass == professionClass).ToList();
                if(!skills.Any())
                {
                    logger.LogWarning("Skills not found");
                    return new List<ProfessionSkill>();
                }
                return skills;
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"An error occurred while getting skills for profession {ProfessionModul}",professionClass);
                return new List<ProfessionSkill>();
            }
        }
        public async Task<IEnumerable<ProfessionSkill>> ProfessionClassAsync(ProfessionClassEnum professionClass)
        {
            try
            {
                var skills = await dbSet.Where(s => s.ProfessionClass == professionClass).ToListAsync();
                if(skills == null || !skills.Any())
                {
                    logger.LogWarning("Skills not found for skill class {ProfessionClass}",professionClass);
                    return new List<ProfessionSkill>();
                }
                return skills;
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"An error occurred while getting skills for skill class {ProfessionClass}",professionClass);
                return new List<ProfessionSkill>();
            }
        }
        public async Task<IEnumerable<ProfessionSkill>> KnowledgeGroupAsync(LevelGroupEnum knowledgeGroup)
        {
            try
            {
                var skills = await dbSet.Where(s => s.KnowledgeGroup == knowledgeGroup).ToListAsync();
                if(skills == null || !skills.Any())
                {
                    logger.LogWarning("Skills not found for skill class {KnowledgeGroup}",knowledgeGroup);
                    return new List<ProfessionSkill>();
                }
                return skills;
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"An error occurred while getting skills for skill class {KnowledgeGroup}",knowledgeGroup);
                return new List<ProfessionSkill>();
            }
        }
        public async Task<IEnumerable<ProfessionSkill>> GetSkillWithFilter_Async(LevelGroupEnum knowledgeGroup,SkillClassEnum skillClass,ProfessionClassEnum professionClass,bool skillsWithDependecies)
        {
            var skillQuery = dbSet.AsQueryable();
            skillQuery = skillQuery.Where(s => s.KnowledgeGroup == knowledgeGroup && s.SkillClass == skillClass && s.ProfessionClass == professionClass);


            if(skillsWithDependecies)
            {
                skillQuery = skillQuery.Where(s => s.DependencySkillId == 0);
            }
            return await skillQuery.ToListAsync();

        }


        protected override IQueryable<ProfessionSkill> IncludeDependencies()
        {
            var query = dbSet.Include(p => p.BaseSpecificSkills);

            if(!query.Any())
            {
                logger.LogInformation(nameof(ProfessionSkill) + " data is empty.");
            }
            return query;
        }


    }
}
