namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candidateDetails3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CandidateDetails", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CandidateDetails", new[] { "UserId" });
            RenameColumn(table: "dbo.CandidateDetails", name: "UserId", newName: "ApplicationUserId");
            AlterColumn("dbo.CandidateDetails", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CandidateDetails", "ApplicationUserId");
            AddForeignKey("dbo.CandidateDetails", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateDetails", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.CandidateDetails", new[] { "ApplicationUserId" });
            AlterColumn("dbo.CandidateDetails", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            RenameColumn(table: "dbo.CandidateDetails", name: "ApplicationUserId", newName: "UserId");
            CreateIndex("dbo.CandidateDetails", "UserId");
            AddForeignKey("dbo.CandidateDetails", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
