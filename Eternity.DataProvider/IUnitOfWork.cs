using Eternity.DataProvider.Interfaces;

namespace Eternity.DataProvider
{
    public interface IUnitOfWork
    {
        IAboutRepository AboutRepository { get; }
        IKeyRepository KeyRepository { get; }
        IPriceRepository PriceRepository { get; }
        IServiceRepository ServiceRepository { get; }
        IWorkRepository WorkRepository { get; }
        void Commit();
        void Rollback();
    }
}
