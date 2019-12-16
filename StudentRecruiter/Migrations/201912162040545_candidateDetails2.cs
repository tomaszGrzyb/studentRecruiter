namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candidateDetails2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CandidateDetails", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.CandidateDetails", "DocumentId", "dbo.Documents");
            DropIndex("dbo.CandidateDetails", new[] { "AddressId" });
            DropIndex("dbo.CandidateDetails", new[] { "DocumentId" });
            AlterColumn("dbo.CandidateDetails", "AddressId", c => c.Int(nullable: false));
            AlterColumn("dbo.CandidateDetails", "DocumentId", c => c.Int(nullable: false));
            CreateIndex("dbo.CandidateDetails", "AddressId");
            CreateIndex("dbo.CandidateDetails", "DocumentId");
            AddForeignKey("dbo.CandidateDetails", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CandidateDetails", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateDetails", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.CandidateDetails", "AddressId", "dbo.Addresses");
            DropIndex("dbo.CandidateDetails", new[] { "DocumentId" });
            DropIndex("dbo.CandidateDetails", new[] { "AddressId" });
            AlterColumn("dbo.CandidateDetails", "DocumentId", c => c.Int());
            AlterColumn("dbo.CandidateDetails", "AddressId", c => c.Int());
            CreateIndex("dbo.CandidateDetails", "DocumentId");
            CreateIndex("dbo.CandidateDetails", "AddressId");
            AddForeignKey("dbo.CandidateDetails", "DocumentId", "dbo.Documents", "Id");
            AddForeignKey("dbo.CandidateDetails", "AddressId", "dbo.Addresses", "Id");
        }
    }
}
