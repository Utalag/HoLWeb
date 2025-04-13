using HoLWeb.BusinessLayer.Models;

namespace HoLWeb.BusinessLayer.Interfaces
{
    public interface IWorldManager : IGenericManager<WorldDto>
    {
        Task<WorldDto?> GetWorld(int id);
    }
}