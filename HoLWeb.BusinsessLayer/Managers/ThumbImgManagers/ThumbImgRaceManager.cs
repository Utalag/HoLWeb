using AutoMapper;
using HoLWeb.DataLayer.Models.ThumbModels;
using HoLWeb.DataLayer.Database;
using HoLWeb.BusinessLayer.Interfaces.IThumbImgManagers;
using HoLWeb.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HoLWeb.DataLayer.Interfaces;

namespace HoLWeb.BusinessLayer.Managers.ThumbImgManagers
{
    public class ThumbImgRaceManager : GenericManager<ThumbImgRace,ThumbnailImageDto>, IThumbImgRaceManager
    {
        public ThumbImgRaceManager(ILogger<DbSet<ThumbImgRace>> logger,IMapper mapper,IGenericRepository<ThumbImgRace> repository) : base(logger,mapper,repository)
        {
        }

        protected override Task<ThumbImgRace> SetDependenciesAsync(ThumbImgRace entity,ThumbnailImageDto dto)
        {
            return Task.FromResult(entity);
        }
    }
}
