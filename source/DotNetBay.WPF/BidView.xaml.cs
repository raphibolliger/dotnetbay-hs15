using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Core.Helper;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for BidView.xaml
    /// </summary>
    public partial class BidView : Window
    {

        private Auction _auction;
        private readonly SimpleMemberService memberService = new SimpleMemberService(App.MainRepository);

        public BidView(Auction auction)
        {
            InitializeComponent();
            _auction = auction;

            AuctionImage.Source = ImageHelper.ByteToImage(_auction.Image);
            TitelStatusLabel.Content = _auction.Title;
            DescriptionStatusLabel.Content = _auction.Description;
            StartPriceStatusLabel.Content = _auction.StartPrice;
            CurrentPriceStatusLabel.Content = _auction.CurrentPrice;
        }

        private void PlaceBidButton_Click(object sender, RoutedEventArgs e)
        {
            var amount = double.Parse(YourBidTextBox.Text, NumberStyles.Any, CultureInfo.CurrentCulture);
            if (amount <= _auction.CurrentPrice)
            {
                YourBidTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }

            var bid = new Bid();
            bid.Auction = _auction;
            bid.Amount = amount;
            bid.ReceivedOnUtc = DateTime.UtcNow;
            bid.Bidder = memberService.GetCurrentMember();

            _auction.CurrentPrice = bid.Amount;
            _auction.Bids.Add(bid);

            this.Close();
        }
    }
}
