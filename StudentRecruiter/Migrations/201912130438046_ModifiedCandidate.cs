namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCandidate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Candidates", "FirstName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Candidates", "SecondName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Candidates", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Candidates", "PlaceOfBirth", c => c.String(maxLength: 50));
            AlterColumn("dbo.Candidates", "PhoneNumber", c => c.String(maxLength: 25));
            AlterColumn("dbo.Documents", "SerialNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Documents", "SerialNumber", c => c.String());
            AlterColumn("dbo.Candidates", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Candidates", "PlaceOfBirth", c => c.String());
            AlterColumn("dbo.Candidates", "LastName", c => c.String());
            AlterColumn("dbo.Candidates", "SecondName", c => c.String());
            AlterColumn("dbo.Candidates", "FirstName", c => c.String());
        }
    }
}
