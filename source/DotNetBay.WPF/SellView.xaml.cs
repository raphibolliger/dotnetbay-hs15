using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Model;
using Microsoft.Win32;

namespace DotNetBay.WPF
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
                ImageTextBox.Text = openFileDialog.FileName;
            }

        }

        private void AddAuctionButton_Click(object sender, RoutedEventArgs e)
        {
            var memberService = new SimpleMemberService(App.MainRepository);
            var service = new AuctionService(App.MainRepository, memberService);

            var redBorder = new SolidColorBrush(Colors.Red);

            if (TitleTextBox.Text.Equals(""))
            {
                TitleTextBox.BorderBrush = redBorder;
                return;
            }
            if (StartPriceTextBox.Text.Equals(""))
            {
                StartPriceTextBox.BorderBrush = redBorder;
                return;
            }
            if (ImageTextBox.Text.Equals(""))
            {
                ImageTextBox.BorderBrush = redBorder;
                return;
            }

            var imageBytes = File.ReadAllBytes(ImageTextBox.Text);

            var me = memberService.GetCurrentMember();
            var price = int.Parse(StartPriceTextBox.Text);

            service.Save(new Auction
            {
                Title = TitleTextBox.Text,
                Description = DescriptionTextBox.Text,
                StartDateTimeUtc = StartDatePicker.SelectedDate.Value,
                EndDateTimeUtc = EndDatePicker.SelectedDate.Value,
                StartPrice = price,
                CurrentPrice = price,
                Image = imageBytes,
                Seller = me
            });

            this.Close();
        }
    }
}