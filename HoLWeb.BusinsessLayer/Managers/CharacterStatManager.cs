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
    public class CharacterStatManager : GenericManager<CharacterStat,CharacterStatDto>, ICharacterStatManager
    {
        public CharacterStatManager(ILogger<DbSet<CharacterStat>> logger,IMapper mapper,IGenericRepository<CharacterStat> repository) : base(logger,mapper,repository)
        {
        }

        protected override Task<CharacterStat> SetDependenciesAsync(CharacterStat entity,CharacterStatDto dto)
        {
            return Task.FromResult(entity);
        }


    }
}
