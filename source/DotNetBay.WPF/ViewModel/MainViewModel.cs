using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.View;
using DotNetBay.WPF.ViewModel.Common;

namespace DotNetBay.WPF.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        private readonly IMemberService memberService;
        private readonly IAuctionService auctionService;

        public ICommand NewAuctionCommand { get; private set; }


        public ObservableCollection<AuctionViewModel> Auctions { get; private set; }

        public MainViewModel(IMemberService memberService, IAuctionService auctionService)
        {
            this.memberService = memberService;
            this.auctionService = auctionService;

            // Intial add all auction
            Auctions = new ObservableCollection<AuctionViewModel>();
            var allAuctions = auctionService.GetAll();
            foreach (var auction in allAuctions)
            {
                Auctions.Add(new AuctionViewModel(auction));
            }

            NewAuctionCommand = new RelayCommand(this.NewAuction);

        }

        public void NewAuction()
        {
            var sellView = new SellView();
            sellView.ShowDialog(); //Blocking

            var allAuctions = auctionService.GetAll();
            var newAuctions = allAuctions.Where(a => Auctions.All(vm => vm.Auction != a));

            foreach (var auction in newAuctions)
            {
                Auctions.Add(new AuctionViewModel(auction));
            }
        }


    }
}