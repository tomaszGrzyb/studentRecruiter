namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seed11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.StudyTypes", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.StudyTypes", "Name", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
