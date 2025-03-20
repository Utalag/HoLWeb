using HoLWeb.DataLayer.Database;
using HoLWeb.DataLayer.Interfaces;
using HoLWeb.DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.DataLayer.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly HoLWebDbContext db;
        protected readonly DbSet<TEntity> dbSet;
        protected readonly ILogger<DbSet<TEntity>> logger;

        public GenericRepository(HoLWebDbContext db,ILogger<DbSet<TEntity>> logger)
        {
            this.db = db;
            dbSet = db.Set<TEntity>();
            this.logger = logger;
        }

        public IList<TEntity> All(bool withDependencies = false)
        {
            IQueryable<TEntity> query = withDependencies ? IncludeDependencies() : dbSet;
            return query.ToList();
        }

        public async Task<IList<TEntity>> AllAsync(bool withDependencies = false)
        {
            IQueryable<TEntity> query = withDependencies ? IncludeDependencies() : dbSet;
            return await query.ToListAsync();
        }

        public TEntity? FindById(int id,bool withDependencies = false)
        {
            if(withDependencies)
            {
                var entity = IncludeDependencies().FirstOrDefault(x => EF.Property<int>(x,"Id") == id);
                if(entity == null)
                {
                    logger.LogWarning($"Entity with ID: {id} not found, entity return null");
                    return null;
                }
                else
                { 
                    return entity;
                }
            }
            else
            {
                var entity = dbSet.Find(id);
                if(entity == null)
                {
                    logger.LogWarning($"Entity with ID: {id} not found, entity return null");
                    return null;
                }
                else
                {
                    return entity;
                }
            }
        }

        public async Task<TEntity?> FindByIdAsync(int id,bool withDependencies = false)
        {
            if(withDependencies)
            {
                var entity = await IncludeDependencies().FirstOrDefaultAsync(x => EF.Property<int>(x,"Id") == id);
                if(entity == null)
                {
                    logger.LogWarning("Entity with ID: {Id} not found",id);
                }
                return entity;
            }
            else
            {
                return await dbSet.FindAsync(id);
            }
        }

        public IList<TEntity>? FindByIds(List<int> ids,bool withDependencies = false)
        {
            if(withDependencies)
            {
                var entities = IncludeDependencies().Where(e => ids.Contains(EF.Property<int>(e,"Id"))).ToList();
                if(entities.Count == 0)
                {
                    logger.LogWarning("Entities with IDs: {Ids} not found",ids);
                }
                return entities;
            }
            else
            {
                return dbSet.Where(e => ids.Contains(EF.Property<int>(e,"Id"))).ToList();
            }
        }

        public async Task<IList<TEntity>?> FindByIdsAsync(List<int> ids,bool withDependencies = false)
        {
            if(withDependencies)
            {
                var entities = await IncludeDependencies().Where(e => ids.Contains(EF.Property<int>(e,"Id"))).ToListAsync();
                if(entities.Count == 0)
                {
                    logger.LogWarning("Entities with IDs: {Ids} not found",ids);
                }
                return entities;
            }
            else
            {
                return await dbSet.Where(e => ids.Contains(EF.Property<int>(e,"Id"))).ToListAsync();
            }
        }

        public IList<TEntity> Page(int page,int pageSize,bool withDependencies = false)
        {
            IQueryable<TEntity> query = withDependencies ? IncludeDependencies() : dbSet;
            return query.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<IList<TEntity>> PageAsync(int page,int pageSize,bool withDependencies = false)
        {
            IQueryable<TEntity> query = withDependencies ? IncludeDependencies() : dbSet;
            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public TEntity Insert(TEntity entity)
        {
            dbSet.Add(entity);
            db.SaveChanges();
            return entity;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await db.SaveChangesAsync();
            return entity;
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                dbSet.Update(entity);
                db.SaveChanges();
            }
            catch(Exception ex)
            {
                logger.LogError(ex,"Error during SaveChanges");
                throw;
            }
            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {   
            
            //db.Attach(entity!).State = EntityState.Modified;
            dbSet.Update(entity);

            try
            {
                await db.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException ex)
            {
                ex.Entries.Single().Reload();
            }


            await db.SaveChangesAsync();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = dbSet.Find(id);
            if(entity != null)
            {
                dbSet.Remove(entity);
                db.SaveChanges();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            if(entity != null)
            {
                dbSet.Remove(entity);
                await db.SaveChangesAsync();
            }
        }

        public bool ExistsWithId(int id)
        {
            return dbSet.Any(e => EF.Property<int>(e,"Id") == id);
        }

        public async Task<bool> ExistsWithIdAsync(int id)
        {
            return await dbSet.AnyAsync(e => EF.Property<int>(e,"Id") == id);
        }

        protected virtual IQueryable<TEntity> IncludeDependencies()
        {
            var query = dbSet;

            if(!query.Any())
            {
                logger.LogInformation(nameof(TEntity) + " data is empty.");
            }
            return query;
        }

        //protected abstract IQueryable<TEntity> IncludeDependencies();
    }
}
