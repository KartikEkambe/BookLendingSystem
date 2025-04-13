namespace BookLendingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        BookId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Author = c.String(nullable: false),
                        ISBN = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.BookId);
            
            CreateTable(
                "dbo.Borrowers",
                c => new
                    {
                        BorrowerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BorrowerId);
            
            CreateTable(
                "dbo.LendingRecords",
                c => new
                    {
                        LendingRecordId = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        BorrowerId = c.Int(nullable: false),
                        DateBorrowed = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                    })
                .PrimaryKey(t => t.LendingRecordId)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Borrowers", t => t.BorrowerId, cascadeDelete: true)
                .Index(t => t.BookId)
                .Index(t => t.BorrowerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LendingRecords", "BorrowerId", "dbo.Borrowers");
            DropForeignKey("dbo.LendingRecords", "BookId", "dbo.Books");
            DropIndex("dbo.LendingRecords", new[] { "BorrowerId" });
            DropIndex("dbo.LendingRecords", new[] { "BookId" });
            DropTable("dbo.LendingRecords");
            DropTable("dbo.Borrowers");
            DropTable("dbo.Books");
        }
    }
}
