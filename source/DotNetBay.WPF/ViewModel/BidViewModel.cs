using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Core.Helper;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel.Common;

namespace DotNetBay.WPF.ViewModel
{
    public class BidViewModel : ViewModelBase
    {
        private readonly IMemberService memberService;
        private readonly IAuctionService auctionService;
        private readonly Auction auction;

        public ICommand PlaceYourBidAction { get; private set; }

        public ICommand CloseAction { get; private set; }

        public string Title { get { return auction.Title; } }

        public string Description { get { return auction.Description; } }

        public double StartPrice { get { return auction.StartPrice; } }

        public double CurrentPrice { get { return auction.CurrentPrice; } }

        public ImageSource AuctionImage
        {
            get { return ImageHelper.ByteToImage(auction.Image); }
        }

        public double YourBid { get; set; }

        public BidViewModel(Auction auction, IMemberService memberService, IAuctionService auctionService)
        {
            this.memberService = memberService;
            this.auctionService = auctionService;
            this.auction = auction;

            this.CloseAction = new RelayCommand<Window>(this.Cancel);
            this.PlaceYourBidAction = new RelayCommand<Window>(this.PlaceNewBid);

            // Default values
            this.YourBid = Math.Max(StartPrice, CurrentPrice);
        }

        public void PlaceNewBid(Window window)
        {
            auctionService.PlaceBid(auction, YourBid);
            window.Close();
        }

        public void Cancel(Window window)
        {
            window.Close();
        }

    }
}