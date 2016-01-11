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
    public class AuctionsController : Controller
    {

        private readonly IMainRepository mainRepository;
        private readonly IAuctionService service;

        public AuctionsController()
        {
            this.mainRepository = new EFMainRepository();
            this.service = new AuctionService(this.mainRepository, new SimpleMemberService(this.mainRepository));
        }

        // GET: Auctions
        public ActionResult Index()
        {
            ViewBag.Test = "bla";
            return View(service.GetAll().ToList());
        }

        // GET: Auctions/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Auctions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Auctions/Create
        [HttpPost]
        public ActionResult Create(NewAuctionViewModel auction)
        {
            try
            {
                var members = new SimpleMemberService(this.mainRepository);
                var seller = members.GetCurrentMember();

                var newAuction = new Auction
                {
                    Title = auction.Title,
                    Description = auction.Description,
                    StartPrice = auction.StartPrice,
                    StartDateTimeUtc = auction.StartDate,
                    EndDateTimeUtc = auction.EndDate,
                    Seller = seller
                };

                this.service.Save(newAuction);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return this.View();
            }
        }

    }
}
