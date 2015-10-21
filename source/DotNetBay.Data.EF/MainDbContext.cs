﻿using System.Data.Entity;
using DotNetBay.Model;

namespace DotNetBay.Data.EF
{
    public class MainDbContext : DbContext
    {

        public MainDbContext() : base("DatabaseConnection")
        //public MainDbContext() : base("AppVeyorDatabase")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Auction> Auctions { get; set; }

        public DbSet<Bid> Bids { get; set; }

        public DbSet<Member> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Add(new DateTime2Convention());

            modelBuilder.Entity<Auction>().HasRequired(a => a.Seller).WithMany(member => member.Auctions);
            modelBuilder.Entity<Auction>().HasMany(a => a.Bids).WithRequired(b => b.Auction);
        }

    }
}