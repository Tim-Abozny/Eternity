using Eternity.DataProvider;
using Eternity.DataProvider.Models;
using Eternity.DTO.DTOs;
using Eternity.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eternity.Logic.Services
{
    public class ServiceService : IServiceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ServiceService> _logger;
        public ServiceService(IUnitOfWork unitOfWork, ILogger<ServiceService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task AddService(ServiceDTO service)
        {
            _logger.LogInformation("CALLED AddService method");
            Service dbService = new Service();
            var tempEntity = await _unitOfWork.ServiceRepository.GetAll().OrderBy(x => x.Id).LastOrDefaultAsync();

            if (tempEntity == null)
            {
                dbService.Id = 0;
            }
            else
            {
                dbService.Id = tempEntity.Id + 1;
            }
            dbService.Name = service.Name;
            MemoryStream target = new MemoryStream();
            service.ServicePhoto.CopyTo(target);
            dbService.ServicePhoto = target.ToArray();

            _unitOfWork.ServiceRepository.Create(dbService);
            _unitOfWork.Commit();
            _logger.LogInformation("Service ADDED successfully");
        }

        public async Task DeleteService(int id)
        {
            _logger.LogInformation("CALLED DeleteService method");
            var tempEntity = await _unitOfWork.ServiceRepository.GetAll().Where(x => x.Id == id).SingleAsync();
            _unitOfWork.ServiceRepository.Delete(tempEntity);
            _unitOfWork.Commit();
            _logger.LogInformation($"Service with id = {id} DELETED from db");
        }

        public async Task<List<Service>> ShowServices()
        {
            var tempList = await _unitOfWork.ServiceRepository.GetAll().ToListAsync();
            return tempList;
        }
    }
}
