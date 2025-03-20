using AutoMapper;
using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Runtime.CompilerServices;

namespace HoLWeb.DataLayer.Repositories
{
    public class ProfessionModulRepository : GenericRepository<ProfessionModul>, IProfessionModulRepository
    {
        public ProfessionModulRepository(HoLWebDbContext db,ILogger<DbSet<ProfessionModul>> logger) : base(db,logger)
        {
        }

        protected override IQueryable<ProfessionModul> IncludeDependencies()
        {
            var query = dbSet
                        .Include(n => n.Narratives)
                        .Include(s => s.BeginnerSkills)
                        .Include(s => s.AdvancedSkills)
                        .Include(s => s.ExpertSkills);

            if(!query.Any())
            {
                logger.LogInformation(nameof(ProfessionModul) + " data is empty.");
            }
            return query;
        }











    }
}
