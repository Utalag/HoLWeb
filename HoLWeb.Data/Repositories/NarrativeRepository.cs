using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class NarrativeRepository : GenericRepository<Narrative>, INarrativeRepository
    {
        public NarrativeRepository(HoLWebDbContext db,ILogger<DbSet<Narrative>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<Narrative> IncludeDependencies()
        {
            var query = dbSet
                        .Include(ch => ch.Characters)
                        .Include(w => w.World)
                        //.Include(t => t.ThumbnailImage)
                        .Include(p => p.ProfessionModules);

            if(!query.Any())
            {
                logger.LogInformation(nameof(Narrative) + " data is empty.");
            }
            return query;
        }


    }
}
