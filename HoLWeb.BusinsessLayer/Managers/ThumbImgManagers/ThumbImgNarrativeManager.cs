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
    public class ThumbImgNarrativeManager : GenericManager<ThumbImgNarrative,ThumbnailImageDto>, IThumbImgNarrativeManager
    {
        public ThumbImgNarrativeManager(ILogger<DbSet<ThumbImgNarrative>> logger,IMapper mapper,IGenericRepository<ThumbImgNarrative> repository) : base(logger,mapper,repository)
        {
        }

        protected override Task<ThumbImgNarrative> SetDependenciesAsync(ThumbImgNarrative entity,ThumbnailImageDto dto)
        {
            return Task.FromResult(entity);
        }
    }
}
