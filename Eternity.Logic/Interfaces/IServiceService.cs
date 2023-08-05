using Eternity.DTO.DTOs;

namespace Eternity.Logic.Interfaces
{
    public interface IServiceService
    {
        Task DeleteService(int id);
        Task AddService(ServiceDTO service);
        Task<ServiceDTO> ShowServices();
    }
}
