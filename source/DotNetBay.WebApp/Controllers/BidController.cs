using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetBay.Core;
using DotNetBay.Data.EF;
using DotNetBay.Interfaces;
using DotNetBay.Model;
using DotNetBay.WebApp.ViewModel;

namespace DotNetBay.WebApp.Controllers
{
    public class BidController : Controller
    {

        private readonly IMainRepository mainRepository;
        private readonly IAuctionService service;

        public BidController()
        {
            this.mainRepository = new EFMainRepository();
            this.service = new AuctionService(this.mainRepository, new SimpleMemberService(this.mainRepository));
        }

        // GET: Bid/Create
        public ActionResult Create(long auctionId)
        {
            var auction = service.GetAll().First(a => a.Id == auctionId);
            var currentPrice = auction.CurrentPrice < auction.StartPrice ? auction.StartPrice : auction.CurrentPrice;

            var newBid = new NewBidViewModel
            {
                AuctionId = auction.Id,
                Title = auction.Title,
                Description = auction.Description,
                StartPrice = auction.StartPrice,
                CurrentPrice = auction.CurrentPrice,
                YourBid = currentPrice+1
            };

            return View(newBid);
        }

        // POST: Bid/Create
        [HttpPost]
        public ActionResult Create(NewBidViewModel bid)
        {
            try
            {
                var auction = service.GetAll().First(a => a.Id == bid.AuctionId);
                service.PlaceBid(auction, bid.YourBid);
                return this.RedirectToAction("Index", "Auctions");
            }
            catch
            {
                return View(bid);
            }
        }
    }
}
