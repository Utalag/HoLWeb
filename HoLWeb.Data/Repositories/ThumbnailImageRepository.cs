using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models.ThumbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    
    public class ThumbImgWorldRepository : GenericRepository<ThumbImgWorld>, IThumbImgWorldRepository
    {

        public ThumbImgWorldRepository(HoLWebDbContext db,ILogger<DbSet<ThumbImgWorld>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<ThumbImgWorld> IncludeDependencies()
        {
            var query = dbSet.Include(w => w.World);

            if(!query.Any())
            {
                logger.LogInformation(nameof(ThumbImgWorld) + " data is empty.");
            }
            return query;
        }
    }

    public class ThumbImgRaceRepository : GenericRepository<ThumbImgRace>, IThumbImgRaceRepository
    {
        public ThumbImgRaceRepository(HoLWebDbContext db,ILogger<DbSet<ThumbImgRace>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<ThumbImgRace> IncludeDependencies()
        {
            var query = dbSet.Include(r => r.Race);


            if(!query.Any())
            {
                logger.LogInformation(nameof(ThumbImgRace) + " data is empty.");
            }
            return query;
        }

    }

    public class ThumbImgCharacterRepository : GenericRepository<ThumbImgCharacter>, IThumbImgCharacterRepository
    {
        public ThumbImgCharacterRepository(HoLWebDbContext db,ILogger<DbSet<ThumbImgCharacter>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<ThumbImgCharacter> IncludeDependencies()
        {
            var query = dbSet.Include(w => w.Character);

            if(!query.Any())
            {
                logger.LogInformation(nameof(ThumbImgCharacter) + " data is empty.");
            }

            return query;
        }
    }

    public class ThumbImgNarrativeRepository : GenericRepository<ThumbImgNarrative>, IThumbImgNarrativeRepository
    {
        public ThumbImgNarrativeRepository(HoLWebDbContext db,ILogger<DbSet<ThumbImgNarrative>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<ThumbImgNarrative> IncludeDependencies()
        {
            var query = dbSet.Include(n => n.Narrative);
            if(!query.Any())
            {
                logger.LogInformation(nameof(ThumbImgNarrative) + " data is empty.");
            }
            return query;
        }
    }
}
