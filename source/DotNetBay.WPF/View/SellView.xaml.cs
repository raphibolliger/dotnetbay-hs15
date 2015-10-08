using System.IO;
using System.Windows;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel;
using Microsoft.Win32;

namespace DotNetBay.WPF.View
{
    /// <summary>
    ///     Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {

        private readonly SellViewModel viewModel;

        public SellView()
        {
            this.InitializeComponent();

            var memberService = new SimpleMemberService(App.MainRepository);
            var auctionService = new AuctionService(App.MainRepository, memberService);

            viewModel = new SellViewModel(memberService, auctionService);
            DataContext = viewModel;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                viewModel.Image = openFileDialog.FileName;
            }

        }

        private void AddAuctionButton_Click(object sender, RoutedEventArgs e)
        {
            if (viewModel.SaveAuction())
            {
                this.Close();
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}