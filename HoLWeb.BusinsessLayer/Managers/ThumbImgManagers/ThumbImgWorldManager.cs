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
    public class ThumbImgWorldManager : GenericManager<ThumbImgWorld,ThumbnailImageDto>, IThumbImgWorldManager
    {
        public ThumbImgWorldManager(ILogger<DbSet<ThumbImgWorld>> logger,IMapper mapper,IGenericRepository<ThumbImgWorld> repository) : base(logger,mapper,repository)
        {
        }

        protected override Task<ThumbImgWorld> SetDependenciesAsync(ThumbImgWorld entity,ThumbnailImageDto dto)
        {
            return Task.FromResult(entity);
        }
    }
}
