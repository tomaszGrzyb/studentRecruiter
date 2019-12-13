namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Candidate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Street = c.String(),
                        HouseNumber = c.Int(nullable: false),
                        ApartmentNumber = c.Int(nullable: false),
                        City = c.String(),
                        ZipCode = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(),
                        PhoneNumber = c.String(),
                        Pesel = c.String(),
                        AddressId = c.Int(),
                        DocumentId = c.Int(),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId)
                .ForeignKey("dbo.Documents", t => t.DocumentId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.AddressId)
                .Index(t => t.DocumentId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DocumentTypeId = c.Short(nullable: false),
                        SerialNumber = c.String(),
                        ExpirationDate = c.DateTime(nullable: false),
                        DocumentType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DocumentTypes", t => t.DocumentType_Id)
                .Index(t => t.DocumentType_Id);
            
            CreateTable(
                "dbo.DocumentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Candidates", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Candidates", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.Documents", "DocumentType_Id", "dbo.DocumentTypes");
            DropForeignKey("dbo.Candidates", "AddressId", "dbo.Addresses");
            DropIndex("dbo.Documents", new[] { "DocumentType_Id" });
            DropIndex("dbo.Candidates", new[] { "UserId" });
            DropIndex("dbo.Candidates", new[] { "DocumentId" });
            DropIndex("dbo.Candidates", new[] { "AddressId" });
            DropTable("dbo.DocumentTypes");
            DropTable("dbo.Documents");
            DropTable("dbo.Candidates");
            DropTable("dbo.Addresses");
        }
    }
}
