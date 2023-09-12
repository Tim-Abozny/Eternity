using Eternity.DataProvider;
using Eternity.DataProvider.Models;
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
            var aboutEntity = await _unitOfWork.AboutRepository.GetAll().SingleOrDefaultAsync();
            if (aboutEntity == null)
            {
                CreateAbout(acceptedText);
            }
            else
            {
                aboutEntity.Text = acceptedText;
                UpdateAbout(aboutEntity);
            }
        }
        private void UpdateAbout(About about)
        {
            _unitOfWork.AboutRepository.Update(about);
            _logger.LogInformation("About text MODIFIED");
            _unitOfWork.Commit();
            _logger.LogInformation("About text in Database UPDATED successfully");
        }
        private void CreateAbout(string acceptedText)
        {
            About about = new();
            about.Id = 0;
            about.Text = acceptedText;
            _unitOfWork.AboutRepository.Create(about);
            _logger.LogInformation("About entity CREATED");
            _unitOfWork.Commit();
            _logger.LogInformation("About text in Database SAVED successfully");
        }
        public async Task<string> ShowAbout()
        {
            var EntityFromDb = await _unitOfWork.AboutRepository.GetAll().SingleAsync();
            return EntityFromDb.Text;
        }
    }
}
