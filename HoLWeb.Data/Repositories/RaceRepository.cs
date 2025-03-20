using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class RaceRepository : GenericRepository<Race>, IRaceRepository
    {
        public RaceRepository(HoLWebDbContext db,ILogger<DbSet<Race>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<Race> IncludeDependencies()
        {
            var query = dbSet
                            .Include(w => w.Worlds)
                            .Include(t => t.ThumbnailImage)
                            .Include(stat => stat.StrengthStat)
                            .Include(stat => stat.AgilityStat)
                            .Include(stat => stat.ConstitutionStat)
                            .Include(stat => stat.IntelligenceStat)
                            .Include(stat => stat.CharismaStat);

            if(!query.Any())
            {
                logger.LogInformation(nameof(Race) + " data is empty.");
            }
            return query;
        }

    }
}
