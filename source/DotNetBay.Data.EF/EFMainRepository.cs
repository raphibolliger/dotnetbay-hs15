using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.Data.EF
{
    public class EFMainRepository : IMainRepository
    {
        public EFMainRepository()
        {
            Context = new MainDbContext();
        }

        public MainDbContext Context { get; set; }

        public Database Database => this.Context.Database;

        public IQueryable<Auction> GetAuctions()
        {
            return
                this.Context.Auctions.Include(a => a.Bids)
                    .Include(m => m.Seller)
                    .Include(w => w.Winner)
                    .Include(a => a.ActiveBid);
        }

        public IQueryable<Member> GetMembers()
        {
            return 
                this.Context.Members
                    .Include(b => b.Bids)
                    .Include(a => a.Auctions);
        }

        public Auction Add(Auction auction)
        {
            return Context.Auctions.Add(auction);
        }

        public Auction Update(Auction auction)
        {
            Context.Auctions.AddOrUpdate(auction);
            return auction;
        }

        public Bid Add(Bid bid)
        {
            return Context.Bids.Add(bid);
        }

        public Bid GetBidByTransactionId(Guid transactionId)
        {
            return
                this.Context.Bids
                    .Include(b => b.Auction)
                    .Include(b => b.Bidder)
                    .FirstOrDefault(b => b.TransactionId == transactionId);
        }

        public Member Add(Member member)
        {
            return Context.Members.Add(member);
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }
    }
}