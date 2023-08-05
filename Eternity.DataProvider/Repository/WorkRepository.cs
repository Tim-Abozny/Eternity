using Eternity.DataProvider.Data;
using Eternity.DataProvider.Interfaces;
using Eternity.DataProvider.Models;

namespace Eternity.DataProvider.Repository
{
    public class WorkRepository : BaseRepository<Work>, IWorkRepository
    {
        public WorkRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
