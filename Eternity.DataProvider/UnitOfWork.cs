using Eternity.DataProvider.Data;
using Eternity.DataProvider.Interfaces;
using Eternity.DataProvider.Repository;

namespace Eternity.DataProvider
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private IAboutRepository _aboutRepository;
        private IKeyRepository _keyRepository;
        private IPriceRepository _priceRepository;
        private IServiceRepository _serviceRepository;
        private IWorkRepository _workRepository;
        
        public UnitOfWork(ApplicationDbContext dbContext) 
        {
            _dbContext= dbContext;
        }

        public IAboutRepository AboutRepository => _aboutRepository ?? new AboutRepository(_dbContext);
        public IKeyRepository KeyRepository => _keyRepository ?? new KeyRepository(_dbContext);
        public IPriceRepository PriceRepository => _priceRepository?? new PriceRepository(_dbContext);
        public IServiceRepository ServiceRepository => _serviceRepository?? new ServiceRepository(_dbContext);
        public IWorkRepository WorkRepository => _workRepository?? new WorkRepository(_dbContext);


        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            _dbContext.Dispose(); // changes tracker
        }
    }
}
