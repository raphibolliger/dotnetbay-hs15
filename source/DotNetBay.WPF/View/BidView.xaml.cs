using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Core.Helper;
using DotNetBay.Model;

namespace DotNetBay.WPF.View
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
            this._auction = auction;

            this.AuctionImage.Source = ImageHelper.ByteToImage(this._auction.Image);
            this.TitelStatusLabel.Content = this._auction.Title;
            this.DescriptionStatusLabel.Content = this._auction.Description;
            this.StartPriceStatusLabel.Content = this._auction.StartPrice;
            this.CurrentPriceStatusLabel.Content = this._auction.CurrentPrice;
        }

        private void PlaceBidButton_Click(object sender, RoutedEventArgs e)
        {
            var amount = double.Parse(this.YourBidTextBox.Text, NumberStyles.Any, CultureInfo.CurrentCulture);
            if (amount <= this._auction.CurrentPrice)
            {
                this.YourBidTextBox.BorderBrush = new SolidColorBrush(Colors.Red);
                return;
            }

            var bid = new Bid();
            bid.Auction = this._auction;
            bid.Amount = amount;
            bid.ReceivedOnUtc = DateTime.UtcNow;
            bid.Bidder = this.memberService.GetCurrentMember();

            this._auction.CurrentPrice = bid.Amount;
            this._auction.Bids.Add(bid);

            this.Close();
        }
    }
}
