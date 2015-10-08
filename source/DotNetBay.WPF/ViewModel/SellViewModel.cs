using System;
using System.Globalization;
using System.IO;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Core.Helper;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.WPF.ViewModel
{
    public class SellViewModel : ViewModelBase
    {
        private readonly IMemberService memberService;
        private readonly IAuctionService auctionService;
        private readonly Auction auction = new Auction();

        public string Title
        {
            get { return this.auction.Title; }
            set
            {
                auction.Title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return auction.Description; }
            set
            {
                auction.Description = value;
                OnPropertyChanged();
            }
        }

        public string StartPrice
        {
            get { return auction.StartPrice.ToString(CultureInfo.InvariantCulture); }
            set
            {
                auction.StartPrice = double.Parse(value);
                OnPropertyChanged();
            }
        }

        public DateTime Start
        {
            get { return auction.StartDateTimeUtc; }
            set
            {
                auction.StartDateTimeUtc = value;
                OnPropertyChanged();
            }
        }

        public DateTime End
        {
            get { return auction.EndDateTimeUtc; }
            set
            {
                auction.EndDateTimeUtc = value;
                this.OnPropertyChanged();
            }
        }

        public string Image
        {
            get { return auction.Image == null ? "Bitte ein Bild auswählen..." : "Bild ausgewählt."; }
            set
            {
                auction.Image = File.ReadAllBytes(value);
                this.OnPropertyChanged();
            }
        }

        public SellViewModel()
        {
            
        }

        public SellViewModel(IMemberService memberService, IAuctionService auctionService)
        {
            this.memberService = memberService;
            this.auctionService = auctionService;
            auction.StartDateTimeUtc = DateTime.UtcNow;
            auction.EndDateTimeUtc = DateTime.UtcNow.AddDays(2);
            auction.Seller = memberService.GetCurrentMember();
        }

        public bool SaveAuction()
        {
            return auctionService.Save(auction) != null;
        }

    }
}