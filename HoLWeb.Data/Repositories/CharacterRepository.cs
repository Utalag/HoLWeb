using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class CharacterRepository : GenericRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(HoLWebDbContext db,ILogger<DbSet<Character>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<Character> IncludeDependencies()
        {
            var query = dbSet
                        .Include(w => w.Narrative)
                        .Include(stat => stat.NavForStrengthStat)
                        .Include(stat => stat.NavForAgilityStat)
                        .Include(stat => stat.NavForConstitutionStat)
                        .Include(stat => stat.NavForIntelligenceStat)
                        .Include(stat => stat.NavForCharismaStat)
                        .Include(p => p.IndividualProfessionSkills)
                        .Include(t => t.ThumbnailImage);

            if(!query.Any())
            {
                logger.LogInformation(nameof(Character) + " data is empty.");
            }
            return query;
        }
    }
}
