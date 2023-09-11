using Eternity.DataProvider;
using Eternity.DataProvider.Models;
using Eternity.DTO.DTOs;
using Eternity.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eternity.Logic.Services
{
    public class PriceService : IPriceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PriceService> _logger;
        public PriceService(IUnitOfWork unitOfWork, ILogger<PriceService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task CreatePrice(PriceDTO price)
        {
            _logger.LogInformation("Called CreatePrice method");
            Price dbPrice = new Price();
            var tempEntity = await _unitOfWork.PriceRepository.GetAll().OrderBy(x => x.Id).LastOrDefaultAsync();
            dbPrice.Id = tempEntity.Id + 1;
            dbPrice.Title = price.Title;
            dbPrice.Description = price.Description;
            _unitOfWork.PriceRepository.Create(dbPrice);
            _unitOfWork.Commit();
            _logger.LogInformation("Price successfully created. Db saved");
        }

        public async Task DeletePrice(int id)
        {
            _logger.LogInformation("Called DeletePrice method");
            var tempEntity = await _unitOfWork.PriceRepository.GetAll().Where(x => x.Id == id).SingleAsync();
            _unitOfWork.PriceRepository.Delete(tempEntity);
            _unitOfWork.Commit();
            _logger.LogInformation($"Price with id = {id} deleted");
        }

        public async Task EditPrice(PriceDTO price, int id)
        {
            _logger.LogInformation("Called EditPrice method");
            var tempEntity = await _unitOfWork.PriceRepository.GetAll().Where(x => x.Id == id).SingleAsync();
            tempEntity.Title = price.Title;
            tempEntity.Description = price.Description;
            _unitOfWork.PriceRepository.Update(tempEntity);
            _unitOfWork.Commit();
            _logger.LogInformation($"Price with id = {tempEntity.Id} successfully edited");
        }

        public async Task<List<PriceDTO>> GetPrices()
        {
            _logger.LogInformation("Called GetPrices method");
            var entityList = await _unitOfWork.PriceRepository.GetAll().ToListAsync();
            List<PriceDTO> listToReturn = new List<PriceDTO>();
            PriceDTO tempDTO = new();
            foreach (var entity in entityList)
            {
                tempDTO.Title = entity.Title;
                tempDTO.Description = entity.Description;
                listToReturn.Add(tempDTO);
            }
            _logger.LogInformation("Returning data...");
            return listToReturn;
        }
    }
}
