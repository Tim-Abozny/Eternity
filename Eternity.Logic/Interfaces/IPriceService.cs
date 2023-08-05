using Eternity.DataProvider.Models;
using Eternity.DTO.DTOs;

namespace Eternity.Logic.Interfaces
{
    public interface IPriceService
    {
        Task CreatePrice(PriceDTO price);
        Task<List<PriceDTO>> GetPrices();
        Task EditPrice(PriceDTO price);
        Task DeletePrice(int id);
    }
}
