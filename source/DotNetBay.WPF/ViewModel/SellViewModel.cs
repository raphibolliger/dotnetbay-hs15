using System;
using System.Globalization;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Core.Helper;
using DotNetBay.Interfaces;
using DotNetBay.Model;
using DotNetBay.WPF.ViewModel.Common;
using Microsoft.Win32;

namespace DotNetBay.WPF.ViewModel
{
    public class SellViewModel : ViewModelBase
    {
        private readonly IMemberService memberService;
        private readonly IAuctionService auctionService;

        private byte[] imageBytes;

        public string Title { get; set; }

        public string Description { get; set; }

        public double StartPrice { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public string Image
        {
            get { return imageBytes == null ? "Bitte ein Bild auswählen..." : "Bild ausgewählt."; }
            set
            {
                imageBytes = File.ReadAllBytes(value);
            }
        }

        public ICommand SaveAuctionCommand { get; private set; }
        
        public ICommand CloseWindowCommand { get; private set; }

        public ICommand LoadImageCommand { get; private set; }

        public SellViewModel(IMemberService memberService, IAuctionService auctionService)
        {
            this.memberService = memberService;
            this.auctionService = auctionService;

            SaveAuctionCommand = new RelayCommand<Window>(this.SaveAuction);
            CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
            LoadImageCommand = new RelayCommand(this.LoadImage);

            // Default values
            Start = DateTime.UtcNow.AddMinutes(10);
            End = DateTime.UtcNow.AddDays(3);

        }

        public void SaveAuction(Window window)
        {
            var newAuction = new Auction
            {
                Title = this.Title,
                Description = this.Description,
                StartPrice = this.StartPrice,
                StartDateTimeUtc = this.Start,
                EndDateTimeUtc = this.End,
                Seller = memberService.GetCurrentMember(),
                Image = imageBytes
            };

            auctionService.Save(newAuction);
            window.Close();
        }

        public void CloseWindow(Window window)
        {
            window.Close();
        }

        public void LoadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                this.Image = openFileDialog.FileName;
            }
        }

    }
}