namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class guid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recruitments", "RecruitmentNumber", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recruitments", "RecruitmentNumber");
        }
    }
}
