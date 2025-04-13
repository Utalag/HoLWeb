using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{

    public class ThumbnailImageRapository : GenericRepository<ThumbnailImage>, IThumbnailImageRepository
    {



        //protected override IQueryable<ThumbImgWorld> IncludeDependencies()
        //{
        //    var query = dbSet.Include(w => w.World);

        //    if(!query.Any())
        //    {
        //        logger.LogInformation(nameof(ThumbImgWorld) + " data is empty.");
        //    }
        //    return query;
        //}

        public ThumbnailImageRapository(HoLWebDbContext db,ILogger<DbSet<ThumbnailImage>> logger) : base(db,logger)
        {
        }
    }

}
