namespace HoLWeb.BusinessLayer.Interfaces
{
    public interface IGenericManager<TDto>
        where TDto : class
    {
        TDto AddData(TDto dto);
        TDto? DeleteDate(int id,bool dependencies = false);
        IList<TDto> GetAllData(bool dependencies = false);
        TDto? GetDateById(int id,bool dependencies = false);
        IList<TDto> GetPage(int page = 0,int pageSize = int.MaxValue,bool dependencies = false);
        TDto? UpdateData(TDto dto,int id);

        //-----Async-----//

        Task<TDto> AddDataAsync(TDto dto);
        Task<TDto?> DeleteDateAsync(int id,bool dependencies = false);
        Task<IList<TDto>> GetAllDataAsync(bool dependencies = false);
        Task<TDto?> GetDateByIdAsync(int id,bool dependencies = false);
        Task<IList<TDto>> GetPageAsyc(int page = 0,int pageSize = int.MaxValue,bool dependencies = false);
        Task<TDto?> UpdateDataAsync(TDto dto,int id);
        IList<TDto> GetDataByIds(List<int> ids,bool dependencies = false);
        Task<IList<TDto>> GetDataByIdsAsync(List<int> ids,bool dependencies = false);
    }
}
