using Eternity.DataProvider;
using Eternity.DataProvider.Models;
using Eternity.DTO.DTOs;
using Eternity.Logic.Interfaces;
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
            _logger.LogInformation("Called AddService method");
            Service dbService = new Service();
            var tempEntity = await _unitOfWork.ServiceRepository.GetAll().LastAsync();
            if (tempEntity == null)
            {
                dbService.Id = 0;
            }
            else
            {
                dbService.Id = tempEntity.Id + 1;
            }
            
            dbService.Name = service.Name;
            dbService.ServicePhoto = service.ServicePhoto;
            _unitOfWork.ServiceRepository.Create(dbService);
            _unitOfWork.Commit();
            _logger.LogInformation("Service added successfully");
        }

        public async Task DeleteService(int id)
        {
            _logger.LogInformation("Called DeleteService method");
            var tempEntity = await _unitOfWork.ServiceRepository.GetAll().Where(x => x.Id == id).SingleAsync();
            _unitOfWork.ServiceRepository.Delete(tempEntity);
            _unitOfWork.Commit();
            _logger.LogInformation($"Service with id = {id} deleted from db");
        }

        public async Task<ServiceDTO> ShowServices()
        {
            List<ServiceDTO> services = new List<ServiceDTO>();
            var tempList = await _unitOfWork.ServiceRepository.GetAll().ToListAsync();
            ServiceDTO serviceDTO= new ServiceDTO();
            foreach ( var temp in tempList ) 
            {
                serviceDTO.Name = temp.Name;
                serviceDTO.ServicePhoto = temp.ServicePhoto;
                services.Add(serviceDTO);
            }
            return serviceDTO;
        }
    }
}
