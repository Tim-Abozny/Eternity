using Eternity.DataProvider.Models;
using Eternity.DTO.DTOs;

namespace Eternity.Logic.Interfaces
{
    public interface IServiceService
    {
        Task DeleteService(int id);
        Task AddService(ServiceDTO service);
        Task<List<Service>> ShowServices();
    }
}
