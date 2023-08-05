using Eternity.DataProvider.Data;
using Eternity.DataProvider.Interfaces;
using Eternity.DataProvider.Models;

namespace Eternity.DataProvider.Repository
{
    public class ServiceRepository : BaseRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
