using AutoMapper;
using HoLWeb.DataLayer.Models.SkillsModels;
using HoLWeb.DataLayer.Database;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.BusinessLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HoLWeb.DataLayer.Interfaces;

namespace HoLWeb.BusinessLayer.Managers
{
    public class SpecificSkillManager(
        ILogger<DbSet<BaseSpecificSkill>> logger,
        IMapper mapper,
        IGenericRepository<BaseSpecificSkill> repository) 
        : GenericManager<BaseSpecificSkill,SpecificSkillDto>(logger,mapper,repository), ISpecificSkillManager
    {
        protected override Task<BaseSpecificSkill> SetDependenciesAsync(BaseSpecificSkill entity,SpecificSkillDto dto)
        {
            return Task.FromResult(entity);
        }
    }
}
