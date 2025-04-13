using AutoMapper;
using HoLWeb.BusinessLayer.Interfaces.IThumbImgManagers;
using HoLWeb.BusinessLayer.Models;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.BusinessLayer.Managers
{
    public class ThumbImgManager : GenericManager<ThumbnailImage,ThumbnailImageDto>, IThumbImgManager
    {
        public ThumbImgManager(ILogger<DbSet<ThumbnailImage>> logger,IMapper mapper,IGenericRepository<ThumbnailImage> repository) : base(logger,mapper,repository)
        {
        }

        protected override Task<ThumbnailImage> SetDependenciesAsync(ThumbnailImage entity,ThumbnailImageDto dto)
        {
            return Task.FromResult(entity);
        }
    }
}
