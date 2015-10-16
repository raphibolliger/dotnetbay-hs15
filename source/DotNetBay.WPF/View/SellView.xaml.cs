using System.IO;
using System.Windows;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;
using Microsoft.Win32;

namespace DotNetBay.WPF.View
{
    /// <summary>
    ///     Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {

        public SellView()
        {
            this.InitializeComponent();

            var memberService = new SimpleMemberService(App.MainRepository);
            var auctionService = new AuctionService(App.MainRepository, memberService);

            DataContext = new SellViewModel(memberService, auctionService);
        }

    }
}