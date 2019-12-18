namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CandidateDetails", "Pesel", c => c.String(maxLength: 25));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CandidateDetails", "Pesel", c => c.String());
        }
    }
}
