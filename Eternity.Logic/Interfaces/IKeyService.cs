namespace Eternity.Logic.Interfaces
{
    public interface IKeyService
    {
        Task GenerateKey();
        Task<List<string>> ShowKeys();
        Task<string> GetKey();
    }
}
