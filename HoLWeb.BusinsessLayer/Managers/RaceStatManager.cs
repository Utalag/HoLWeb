using AutoMapper;
using HoLWeb.DataLayer.Models.GeneralAttributes;
using HoLWeb.DataLayer.Database;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HoLWeb.DataLayer.Interfaces;

namespace HoLWeb.BusinessLayer.Managers
{
    public class RaceStatManager(
        ILogger<DbSet<RaceStat>> logger,
        IMapper mapper,
        IGenericRepository<RaceStat> repository) 
        : GenericManager<RaceStat,RaceStatDto>(logger,mapper,repository), IRaceStatManager
    {

        protected override Task<RaceStat> SetDependenciesAsync(RaceStat entity,RaceStatDto dto)
        {
            return Task.FromResult(entity);
        }
    }
}
