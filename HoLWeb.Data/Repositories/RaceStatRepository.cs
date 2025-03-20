using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models.GeneralAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class RaceStatRepository : GenericRepository<RaceStat>, IRaceStatRepository
    {
        public RaceStatRepository(HoLWebDbContext db,ILogger<DbSet<RaceStat>> logger) : base(db,logger)
        {
        }
    }
}
