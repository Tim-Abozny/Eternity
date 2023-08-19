using Eternity.DataProvider;
using Eternity.DataProvider.Models;
using Eternity.DTO.DTOs;
using Eternity.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eternity.Logic.Services
{
    public class WorkService : IWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WorkService> _logger;
        public WorkService(IUnitOfWork unitOfWork, ILogger<WorkService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        public async Task AddWork(WorkDTO work)
        {
            _logger.LogInformation("AddWork method called");
            _logger.LogInformation("Creating new work...");
            var lastWork = await _unitOfWork.WorkRepository.GetAll().OrderBy(x => x.Id).LastOrDefaultAsync();
            MemoryStream target = new MemoryStream();
            work.Image.CopyTo(target);
            Work dbWork = new Work();
            
            if (lastWork != null)
            {

                dbWork.Id = lastWork.Id + 1;
            }
            else
            {
                dbWork.Id = 0;
            }
            dbWork.WorkImage = target.ToArray();
            _logger.LogInformation("New work created successfully");
            _unitOfWork.WorkRepository.Create(dbWork);
            _unitOfWork.Commit();
            _logger.LogInformation("Db updated successfully");
        }

        public async Task DeleteWork(int id)
        {
            _logger.LogInformation("DeleteWork method called");
            _logger.LogInformation("Finding work with current ID...");
            var tempWorkEntity = await _unitOfWork.WorkRepository.GetAll().Where(x => x.Id == id).SingleAsync();
            _unitOfWork.WorkRepository.Delete(tempWorkEntity);
            _logger.LogInformation("Work deleted");
            _unitOfWork.Commit();
            _logger.LogInformation($"work with id = {id} successfully deleted");
        }

        public async Task<List<byte[]>> ShowWorks()
        {
            _logger.LogInformation("ShowWork method called");
            var dbWorkList = await _unitOfWork.WorkRepository.GetAll().ToListAsync();
            List<byte[]> workList = new List<byte[]>();
            foreach (var work in dbWorkList)
            {
                workList.Add(work.WorkImage);
            }
            _logger.LogInformation("Returning data from Database...");
            return workList;
        }
    }
}
