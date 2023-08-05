using Eternity.DataProvider;
using Eternity.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Eternity.Logic.Services
{
    public class AboutService : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AboutService> _logger;
        public AboutService(IUnitOfWork unitOfWork, ILogger<AboutService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task EditAbout(string acceptedText)
        {
            var aboutEntity = await _unitOfWork.AboutRepository.GetAll().SingleAsync();
            aboutEntity.Text = acceptedText;
            _unitOfWork.AboutRepository.Update(aboutEntity);
            _logger.LogInformation("About text modified");
            _unitOfWork.Commit();
            _logger.LogInformation("About text in Database updated successfully");
        }

        public async Task<string> ShowAbout()
        {
            var EntityFromDb = await _unitOfWork.AboutRepository.GetAll().SingleAsync();
            return EntityFromDb.Text;
        }
    }
}
