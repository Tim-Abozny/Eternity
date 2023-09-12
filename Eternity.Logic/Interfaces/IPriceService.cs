using Eternity.DataProvider.Models;
using Eternity.DTO.DTOs;

namespace Eternity.Logic.Interfaces
{
    public interface IPriceService
    {
        Task CreatePrice(PriceDTO price);
        Task<List<Price>> GetPrices();
        Task EditPrice(PriceDTO price, int id);
        Task DeletePrice(int id);
    }
}
