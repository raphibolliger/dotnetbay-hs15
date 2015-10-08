using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly SimpleMemberService MemberService = new SimpleMemberService(App.MainRepository);
        private static readonly AuctionService Service = new AuctionService(App.MainRepository, MemberService);
        private readonly ObservableCollection<Auction> auctions = new ObservableCollection<Auction>(Service.GetAll());

        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
        } 

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void NewAuction_Click(object sender, RoutedEventArgs e)
        {
            var sellView = new SellView();
            sellView.ShowDialog(); //Blocking

            var allAuctions = Service.GetAll();
            var newAuctions = allAuctions.Where(a => this.auctions.All(vm => vm != a));

            foreach (var auction in newAuctions)
            {
                this.auctions.Add(auction);
            }

        }

        private void BidButton_Click(object sender, RoutedEventArgs e)
        {
            var auction = this.dataGrid.SelectedItem as Auction;
            var bidView = new BidView(auction);
            bidView.ShowDialog();
            this.dataGrid.Items.Refresh();
        }
    }
}
