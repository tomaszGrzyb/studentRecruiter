namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candidateDetails : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Candidates", newName: "CandidateDetails");
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            DropColumn("dbo.CandidateDetails", "FirstName");
            DropColumn("dbo.CandidateDetails", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CandidateDetails", "LastName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.CandidateDetails", "FirstName", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            RenameTable(name: "dbo.CandidateDetails", newName: "Candidates");
        }
    }
}
