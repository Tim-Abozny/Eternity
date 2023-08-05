namespace Eternity.Logic.Interfaces
{
    public interface IAboutService
    {
        Task EditAbout(string acceptedText);
        Task<string> ShowAbout();
    }
}
