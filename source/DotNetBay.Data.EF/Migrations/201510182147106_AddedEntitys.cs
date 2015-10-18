namespace DotNetBay.Data.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntitys : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bids", "Auction_Id1", "dbo.Auctions");
            DropForeignKey("dbo.Auctions", "Seller_Id", "dbo.Members");
            DropForeignKey("dbo.Bids", "Auction_Id", "dbo.Auctions");
            DropForeignKey("dbo.Auctions", "Member_Id", "dbo.Members");
            DropIndex("dbo.Auctions", new[] { "Member_Id" });
            DropIndex("dbo.Auctions", new[] { "Seller_Id" });
            DropIndex("dbo.Bids", new[] { "Auction_Id" });
            DropIndex("dbo.Bids", new[] { "Auction_Id1" });
            DropColumn("dbo.Auctions", "Seller_Id");
            DropColumn("dbo.Bids", "Auction_Id");
            RenameColumn(table: "dbo.Bids", name: "Auction_Id1", newName: "Auction_Id");
            RenameColumn(table: "dbo.Auctions", name: "Member_Id", newName: "Seller_Id");
            AlterColumn("dbo.Auctions", "StartDateTimeUtc", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Auctions", "EndDateTimeUtc", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Auctions", "CloseDateTimeUtc", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Auctions", "Seller_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Auctions", "Seller_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Bids", "ReceivedOnUtc", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.Bids", "Auction_Id", c => c.Long(nullable: false));
            AlterColumn("dbo.Bids", "Auction_Id", c => c.Long(nullable: false));
            CreateIndex("dbo.Auctions", "Seller_Id");
            CreateIndex("dbo.Bids", "Auction_Id");
            AddForeignKey("dbo.Bids", "Auction_Id", "dbo.Auctions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Auctions", "Seller_Id", "dbo.Members", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Auctions", "Seller_Id", "dbo.Members");
            DropForeignKey("dbo.Bids", "Auction_Id", "dbo.Auctions");
            DropIndex("dbo.Bids", new[] { "Auction_Id" });
            DropIndex("dbo.Auctions", new[] { "Seller_Id" });
            AlterColumn("dbo.Bids", "Auction_Id", c => c.Long());
            AlterColumn("dbo.Bids", "Auction_Id", c => c.Long());
            AlterColumn("dbo.Bids", "ReceivedOnUtc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auctions", "Seller_Id", c => c.Long());
            AlterColumn("dbo.Auctions", "Seller_Id", c => c.Long());
            AlterColumn("dbo.Auctions", "CloseDateTimeUtc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auctions", "EndDateTimeUtc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Auctions", "StartDateTimeUtc", c => c.DateTime(nullable: false));
            RenameColumn(table: "dbo.Auctions", name: "Seller_Id", newName: "Member_Id");
            RenameColumn(table: "dbo.Bids", name: "Auction_Id", newName: "Auction_Id1");
            AddColumn("dbo.Bids", "Auction_Id", c => c.Long());
            AddColumn("dbo.Auctions", "Seller_Id", c => c.Long());
            CreateIndex("dbo.Bids", "Auction_Id1");
            CreateIndex("dbo.Bids", "Auction_Id");
            CreateIndex("dbo.Auctions", "Seller_Id");
            CreateIndex("dbo.Auctions", "Member_Id");
            AddForeignKey("dbo.Auctions", "Member_Id", "dbo.Members", "Id");
            AddForeignKey("dbo.Bids", "Auction_Id", "dbo.Auctions", "Id");
            AddForeignKey("dbo.Auctions", "Seller_Id", "dbo.Members", "Id");
            AddForeignKey("dbo.Bids", "Auction_Id1", "dbo.Auctions", "Id");
        }
    }
}
