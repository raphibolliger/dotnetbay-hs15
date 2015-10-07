using System.IO;
using System.Windows;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Model;
using Microsoft.Win32;

namespace DotNetBay.WPF.View
{
    /// <summary>
    ///     Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {

        public SellView()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.ImageTextBox.Text = openFileDialog.FileName;
            }

        }

        private void AddAuctionButton_Click(object sender, RoutedEventArgs e)
        {
            var memberService = new SimpleMemberService(App.MainRepository);
            var service = new AuctionService(App.MainRepository, memberService);

            var redBorder = new SolidColorBrush(Colors.Red);

            if (this.TitleTextBox.Text.Equals(""))
            {
                this.TitleTextBox.BorderBrush = redBorder;
                return;
            }
            if (this.StartPriceTextBox.Text.Equals(""))
            {
                this.StartPriceTextBox.BorderBrush = redBorder;
                return;
            }
            if (this.ImageTextBox.Text.Equals(""))
            {
                this.ImageTextBox.BorderBrush = redBorder;
                return;
            }

            var imageBytes = File.ReadAllBytes(this.ImageTextBox.Text);

            var me = memberService.GetCurrentMember();
            var price = int.Parse(this.StartPriceTextBox.Text);

            service.Save(new Auction
            {
                Title = this.TitleTextBox.Text,
                Description = this.DescriptionTextBox.Text,
                StartDateTimeUtc = this.StartDatePicker.SelectedDate.Value,
                EndDateTimeUtc = this.EndDatePicker.SelectedDate.Value,
                StartPrice = price,
                CurrentPrice = price,
                Image = imageBytes,
                Seller = me
            });

            this.Close();
        }
    }
}