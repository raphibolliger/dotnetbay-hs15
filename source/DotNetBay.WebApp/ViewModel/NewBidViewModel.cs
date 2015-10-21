using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DotNetBay.WebApp.ViewModel
{
    public class NewBidViewModel
    {

        public long AuctionId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public double StartPrice { get; set; }

        public double CurrentPrice { get; set; }

        public double YourBid { get; set; }

    }
}