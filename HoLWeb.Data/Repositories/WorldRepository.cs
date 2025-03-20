using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class WorldRepository :GenericRepository<World>, IWorldRepository
    {
        public WorldRepository(HoLWebDbContext db,ILogger<DbSet<World>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<World> IncludeDependencies()
        {
            var query = dbSet
                        .Include(r => r.Races)
                        .Include(n => n.Narratives)
                        .Include(t => t.ThumbnailImage);

            if(!query.Any())
            {
                logger.LogInformation(nameof(World) + " data is empty.");
            }
            return query;
        }

    }
}
