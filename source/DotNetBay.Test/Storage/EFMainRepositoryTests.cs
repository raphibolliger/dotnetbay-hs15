using DotNetBay.Data.EF;
using DotNetBay.Interfaces;

namespace DotNetBay.Test.Storage
{
    public class EFMainRepositoryTests : MainRepositoryTestBase
    {
        protected override IRepositoryFactory CreateFactory()
        {
            return new EFMainRepositoryFactory();
        }
    }
}