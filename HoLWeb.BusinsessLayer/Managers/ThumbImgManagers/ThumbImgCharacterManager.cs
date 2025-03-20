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

    public class ThumbImgCharacterManager : GenericManager<ThumbImgCharacter,ThumbnailImageDto> , IThumbImgCharacterManager
    {
        public ThumbImgCharacterManager(ILogger<DbSet<ThumbImgCharacter>> logger,IMapper mapper,IGenericRepository<ThumbImgCharacter> repository) : base(logger,mapper,repository)
        {
        }

        protected override Task<ThumbImgCharacter> SetDependenciesAsync(ThumbImgCharacter entity,ThumbnailImageDto dto)
        {
            return Task.FromResult(entity);
        }
    }
}
