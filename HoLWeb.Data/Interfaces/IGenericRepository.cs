namespace HoLWeb.DataLayer.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IList<TEntity> All(bool withDependencies = false);
        Task<IList<TEntity>> AllAsync(bool withDependencies = false);
        TEntity? FindById(int id,bool withDependencies = false);
        Task<TEntity?> FindByIdAsync(int id,bool withDependencies = false);
        IList<TEntity>? FindByIds(List<int> ids,bool withDependencies = false);
        Task<IList<TEntity>?> FindByIdsAsync(List<int> ids,bool withDependencies = false);
        IList<TEntity> Page(int page,int pageSize,bool withDependencies = false);
        Task<IList<TEntity>> PageAsync(int page,int pageSize,bool withDependencies = false);
        TEntity Insert(TEntity entity);
        Task<TEntity> InsertAsync(TEntity entity);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        void Delete(int id);
        Task DeleteAsync(int id);
        bool ExistsWithId(int id);
        Task<bool> ExistsWithIdAsync(int id);
    }
}