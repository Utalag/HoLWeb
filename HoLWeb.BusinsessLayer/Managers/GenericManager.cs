using AutoMapper;
using HoLWeb.BusinessLayer.Interfaces;
using HoLWeb.DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HoLWeb.BusinessLayer.Managers
{
    public abstract class GenericManager<T, TDto> : IGenericManager<TDto>
        where T : class
        where TDto : class
    {
        protected readonly IGenericRepository<T> genericRepository;
        protected readonly IMapper mapper;
        protected readonly ILogger<DbSet<T>> logger;

        public GenericManager(
            ILogger<DbSet<T>> logger,
            IMapper mapper,
            IGenericRepository<T> genericRepository)
        {
            this.genericRepository = genericRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public virtual IList<TDto> GetAllData(bool dependencies = false)
        {

            IList<T> date = genericRepository.All(dependencies);
            return mapper.Map<IList<TDto>>(date);

        }
        public virtual IList<TDto> GetPage(int page = 0,int pageSize = int.MaxValue,bool dependencies = false)
        {
            IList<T> date = genericRepository.Page(page,pageSize,dependencies);
            return mapper.Map<IList<TDto>>(date);
        }
        public virtual TDto? GetDateById(int id,bool dependencies = false)
        {
            T? data = genericRepository.FindById(id,dependencies);
            if(data is null)
                return null;
            return mapper.Map<TDto>(data);
        }
        public virtual TDto AddData(TDto dto)
        {
            T data = mapper.Map<T>(dto);
            data = SetDependenciesAsync(data,dto).Result;
            T insertedData = genericRepository.Insert(data);
            return mapper.Map<TDto>(insertedData);
            //return mapper.Map<TDto>(Insert(mapper.Map<T>(dto)));
        }
        public virtual TDto? DeleteDate(int id,bool dependencies = false)
        {
            if(!genericRepository.ExistsWithId(id))
                return null;

            T date = genericRepository.FindById(id,dependencies)!;
            TDto dateDto = mapper.Map<TDto>(date);
            genericRepository.Delete(id);
            return dateDto;
        }
        public virtual TDto? UpdateData(TDto dto,int id)
        {
            // Ověření existence entity podle ID
            if(!genericRepository.ExistsWithId(id))
            {
                logger.LogWarning($"{nameof(T)} with id {id} not found");
                return null;
            }

            // Načtení existující entity z databáze
            T? existingT = genericRepository.FindById(id);
            if(existingT == null)
            {
                logger.LogWarning($"Failed to load {nameof(T)} entity with id {id}");
                return null;
            }

            // Mapování DTO na entitu
            mapper.Map(dto,existingT);
            // Set dependencies
            existingT = SetDependenciesAsync(existingT,dto).Result;

            try
            {
                var updateEntity = genericRepository.UpdateAsync(existingT);
                return mapper.Map<TDto>(updateEntity);

            }
            catch(DbUpdateConcurrencyException ex)
            {
                logger.LogError(ex,$"Concurrency error while updating {nameof(T)} with id {id}");
                throw;
            }
        }
        public virtual IList<TDto> GetDataByIds(List<int> ids,bool dependencies = false)
        {
            if(ids.Count == 0)
            {
                logger.LogWarning("GetDataByIds input is null/0");
                return new List<TDto>();
            }
            else
            {
                IList<T> data = genericRepository.FindByIds(ids,dependencies);
                return mapper.Map<IList<TDto>>(data);

            }
        }



        //--------------------- Async CRUD---------------------------------//

        public virtual async Task<IList<TDto>> GetAllDataAsync(bool dependencies = false)
        {
            IList<T> date = await genericRepository.AllAsync(dependencies);
            return mapper.Map<IList<TDto>>(date);
        }
        public virtual async Task<IList<TDto>> GetPageAsyc(int page = 0,int pageSize = int.MaxValue,bool dependencies = false)
        {
            IList<T> date = await genericRepository.PageAsync(page,pageSize,dependencies);
            return mapper.Map<IList<TDto>>(date);
        }
        public virtual async Task<TDto?> GetDateByIdAsync(int id,bool dependencies = false)
        {
            T? data = await genericRepository.FindByIdAsync(id,dependencies);
            if(data is null)
            { return null; }
            return await Task.Run(() => mapper.Map<TDto>(data));
        }
        public virtual async Task<TDto> AddDataAsync(TDto dto)
        {
            var newEntity = mapper.Map<T>(dto);
            newEntity = await SetDependenciesAsync(newEntity,dto);
            try
            {
                var created = await genericRepository.InsertAsync(newEntity);
                return mapper.Map<TDto>(created);
            }
            catch(Exception ex)
            {

                logger.LogError(ex,$"Error while creating {nameof(T)}");
                throw;
            }

        }
        public virtual async Task<TDto?> DeleteDateAsync(int id,bool dependencies = false)
        {
            if(!genericRepository.ExistsWithId(id))
                return null;

            T date = await genericRepository.FindByIdAsync(id,dependencies)!;
            TDto dateDto = await Task.Run(() => mapper.Map<TDto>(date));
            await genericRepository.DeleteAsync(id);
            return dateDto;
        }
        public virtual async Task<TDto?> UpdateDataAsync(TDto dto,int id)
        {
            // Ověření existence entity podle ID
            if(!await genericRepository.ExistsWithIdAsync(id))
            {
                logger.LogWarning($"{nameof(T)} with id {id} not found");
                return null;
            }

            // Načtení existující entity z databáze
            T? existingT = await genericRepository.FindByIdAsync(id);
            if(existingT == null)
            {
                logger.LogWarning($"Failed to load {nameof(T)} entity with id {id}");
                return null;
            }

            // Mapování DTO na entitu
            mapper.Map(dto,existingT);
            // Set dependencies
            existingT = await SetDependenciesAsync(existingT,dto);

            try
            {
                var updateEntity = await genericRepository.UpdateAsync(existingT);
                return mapper.Map<TDto>(updateEntity);

            }
            catch(DbUpdateConcurrencyException ex)
            {
                logger.LogError(ex,$"Concurrency error while updating {nameof(T)} with id {id}");
                throw;
            }
        }
        public virtual async Task<IList<TDto>> GetDataByIdsAsync(List<int> ids,bool dependencies = false)
        {
            if(ids.Count == 0)
            {
                logger.LogWarning("GetDataByIds input is null/0");
                return new List<TDto>();
            }

            IList<T> data = await genericRepository.FindByIdsAsync(ids,dependencies);
            return mapper.Map<IList<TDto>>(data);
        }



        // -----------------Abstract support methods-------------------//

        protected abstract Task<T> SetDependenciesAsync(T entity,TDto dto);

    }
}
