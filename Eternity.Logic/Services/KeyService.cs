using Eternity.DataProvider;
using Eternity.DataProvider.Models;
using Eternity.Logic.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Security.Cryptography;
using System.Text;

namespace Eternity.Logic.Services
{
    public class KeyService : IKeyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<KeyService> _logger;
        const ushort passwordLength = 10;
        public KeyService(IUnitOfWork unitOfWork, ILogger<KeyService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task GenerateKey()
        {
            _logger.LogInformation("!!! Called GenerateKey method !!!");
            _logger.LogInformation("New key generating...");
            string randomPassword = GenerateRandomPassword(passwordLength);
            _logger.LogInformation("Key successfully generated");
            var id = await _unitOfWork.KeyRepository.GetAll().LastAsync();
            Key generatedKey = new Key();

            if (id != null)
            {
                generatedKey.Id = id.Id + 1;
            }
            else
            {
                generatedKey.Id = 0;
            }
            generatedKey.Text = randomPassword;
            _unitOfWork.KeyRepository.Create(generatedKey);
            _unitOfWork.Commit();
            _logger.LogInformation("Database wrote a new key");
        }

        private string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            var randomBytes = new byte[length];
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                rngCryptoServiceProvider.GetBytes(randomBytes);
            }

            StringBuilder sb = new StringBuilder(length);
            foreach (byte b in randomBytes)
            {
                sb.Append(validChars[b % (validChars.Length)]);
            }

            return sb.ToString();
        }

        public async Task<List<string>> ShowKeys()
        {
            _logger.LogInformation("Called ShowKeys method");
            var keys = await _unitOfWork.KeyRepository.GetAll().ToListAsync();
            var keysForReturn = new List<string>();
            foreach (var key in keys)
            {
                keysForReturn.Add(key.Text);
            }
            _logger.LogInformation("Data from GenerateKey method sended");
            return keysForReturn;
        }

        public async Task<string> GetKey()
        {
            _logger.LogInformation("Called GetKey method");
            var key = await _unitOfWork.KeyRepository.GetAll().LastAsync();
            return key.Text;
        }
    }
}
