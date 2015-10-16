using System;
using System.Windows.Input;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Core.Helper;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel.Common;

namespace DotNetBay.WPF.View
{

    public class AuctionViewModel : ViewModelBase
    {

        private readonly Auction auction;

        public ICommand PlaceBidCommand { get; private set; }

        public Auction Auction => this.auction;

        public string Title => this.auction.Title;

        public bool Status => this.auction.IsRunning;

        public double StartPrice => this.auction.StartPrice;

        public double CurrentPrice => this.auction.CurrentPrice;

        public int Bids => this.auction.Bids.Count;

        public DateTime Starts => this.auction.StartDateTimeUtc;

        public DateTime Ends => this.auction.EndDateTimeUtc;

        public string Seller => this.auction.Seller.DisplayName;

        public Member CurrentWinner => this.auction.Winner;

        public bool IsClosed => this.auction.IsClosed;

        public Member Winner => this.auction.Winner;

        public ImageSource Image => ImageHelper.ByteToImage(this.auction.Image);

        public AuctionViewModel(Auction auction)
        {
            this.auction = auction;
            PlaceBidCommand = new RelayCommand(this.PlaceBid);
        }

        public void PlaceBid()
        {
            var bidView = new BidView(this.auction);
            bidView.ShowDialog(); // Blocking
            this.OnPropertyChanged("Bids");
            this.OnPropertyChanged("CurrentPrice");
        }



    }
}