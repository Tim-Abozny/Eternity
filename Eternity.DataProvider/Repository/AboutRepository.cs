using Eternity.DataProvider.Data;
using Eternity.DataProvider.Interfaces;
using Eternity.DataProvider.Models;

namespace Eternity.DataProvider.Repository
{
    public class AboutRepository : BaseRepository<About>, IAboutRepository
    {
        public AboutRepository(ApplicationDbContext dbContext) : base(dbContext) 
        {
        }
    }
}
