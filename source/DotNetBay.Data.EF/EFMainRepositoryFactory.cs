using DotNetBay.Interfaces;

namespace DotNetBay.Data.EF
{
    public class EFMainRepositoryFactory : IRepositoryFactory
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public IMainRepository CreateMainRepository()
        {
            return new EFMainRepository();
        }
    }
}