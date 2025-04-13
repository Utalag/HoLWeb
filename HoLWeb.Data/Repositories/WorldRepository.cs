using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using HoLWeb.DataLayer.Models.IdentityModels;
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
                            .ThenInclude(s => s.StrengthStat)
                        .Include(r => r.Races)
                            .ThenInclude(s => s.AgilityStat)
                        .Include(r => r.Races)
                            .ThenInclude(s => s.ConstitutionStat)
                        .Include(r => r.Races)
                            .ThenInclude(s => s.IntelligenceStat)
                        .Include(r => r.Races)
                            .ThenInclude(s => s.CharismaStat)


                        .Include(n => n.Narratives)
                            .ThenInclude(u => u.Players)
                        .Include(n => n.Narratives)
                            .ThenInclude((u) => u.GameMaster);

                        //.Include(t => t.ThumbnailImage);





            if(!query.Any())
            {
                logger.LogInformation(nameof(World) + " data is empty.");
            }
            return query;
        }

    }
}
