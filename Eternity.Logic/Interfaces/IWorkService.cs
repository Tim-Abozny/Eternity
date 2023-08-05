using Eternity.DTO.DTOs;

namespace Eternity.Logic.Interfaces
{
    public interface IWorkService
    {
        Task DeleteWork(int id);
        Task AddWork(WorkDTO work);
        Task<List<byte[]>> ShowWorks();
    }
}
