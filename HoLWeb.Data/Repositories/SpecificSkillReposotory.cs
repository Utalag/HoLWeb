using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models.SkillsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class SpecificSkillReposotory : GenericRepository<BaseSpecificSkill>, ISpecificSkillReposotory
    {
        public SpecificSkillReposotory(HoLWebDbContext db,ILogger<DbSet<BaseSpecificSkill>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<BaseSpecificSkill> IncludeDependencies()
        {
            var query = dbSet.Include(p => p.ProfessionSkill);

            if(!query.Any())
            {
                logger.LogInformation(nameof(BaseSpecificSkill) + " data is empty.");
            }
            return query;
        }
    }
}
