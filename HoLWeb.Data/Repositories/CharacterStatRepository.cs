using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models.GeneralAttributes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class CharacterStatRepository : GenericRepository<CharacterStat>, ICharacterStatRepository
    {
        public CharacterStatRepository(HoLWebDbContext db,ILogger<DbSet<CharacterStat>> logger) : base(db,logger)
        {
        }
    }
}
