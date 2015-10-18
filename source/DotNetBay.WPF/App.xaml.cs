using System;
using System.Linq;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.EF;
using DotNetBay.Data.FileStorage;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public static readonly IMainRepository MainRepository = new FileSystemMainRepository(@"C:\Users\raphi\Documents\GitHubVisualStudio\dotnetbay-hs15\source\DotNetBay.AuctionData/data.json");
        public static readonly IMainRepository MainRepository = new EFMainRepository();


        public static readonly IAuctionRunner AuctionRunner = new AuctionRunner(MainRepository);

        public App()
        {
            AuctionRunner.Start();
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}