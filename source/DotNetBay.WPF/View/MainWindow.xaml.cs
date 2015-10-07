using System.Collections.ObjectModel;
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
        private static SimpleMemberService memberService = new SimpleMemberService(App.MainRepository);
        private static AuctionService service = new AuctionService(App.MainRepository, memberService);
        private readonly ObservableCollection<Auction> _auctions = new ObservableCollection<Auction>(service.GetAll());

        public ObservableCollection<Auction> Auctions
        {
            get { return this._auctions; }
        } 

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            var sellView = new SellView();
            sellView.ShowDialog();
            this.dataGrid.Items.Refresh();
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
