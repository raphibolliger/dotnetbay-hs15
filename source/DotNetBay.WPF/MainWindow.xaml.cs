using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Model;

namespace DotNetBay.WPF
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
    }
}
