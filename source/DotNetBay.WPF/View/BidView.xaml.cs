using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Core.Helper;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {

        public BidView(Auction auction)
        {
            InitializeComponent();

            var memberService = new SimpleMemberService(App.MainRepository);
            var auctionService = new AuctionService(App.MainRepository, memberService);

            DataContext = new BidViewModel(auction, memberService, auctionService);
        }

    }
}
