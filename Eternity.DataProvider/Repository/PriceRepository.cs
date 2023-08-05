using Eternity.DataProvider.Data;
using Eternity.DataProvider.Interfaces;
using Eternity.DataProvider.Models;

namespace Eternity.DataProvider.Repository
{
    public class PriceRepository : BaseRepository<Price>, IPriceRepository
    {
        public PriceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
