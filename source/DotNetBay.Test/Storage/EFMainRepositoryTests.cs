using System.Data.Entity;
using System.Data.Entity.SqlServer;
using DotNetBay.Data.EF;
using DotNetBay.Data.EF.Migrations;
using DotNetBay.Interfaces;

namespace DotNetBay.Test.Storage
{
    public class EFMainRepositoryTests : MainRepositoryTestBase
    {

        public EFMainRepositoryTests()
        {
            var ensureDLLIsCopied = SqlProviderServices.Instance;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MainDbContext, Configuration>());
        }

        protected override IRepositoryFactory CreateFactory()
        {
            return new EFMainRepositoryFactory();
        }

    }
}