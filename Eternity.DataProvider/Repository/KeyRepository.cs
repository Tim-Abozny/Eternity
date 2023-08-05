using Eternity.DataProvider.Data;
using Eternity.DataProvider.Interfaces;
using Eternity.DataProvider.Models;

namespace Eternity.DataProvider.Repository
{
    public class KeyRepository : BaseRepository<Key>, IKeyRepository
    {
        public KeyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
