namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appliances", "RecruitmentNumber", c => c.Guid(nullable: false));
            DropColumn("dbo.Recruitments", "RecruitmentNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recruitments", "RecruitmentNumber", c => c.Guid(nullable: false));
            DropColumn("dbo.Appliances", "RecruitmentNumber");
        }
    }
}
