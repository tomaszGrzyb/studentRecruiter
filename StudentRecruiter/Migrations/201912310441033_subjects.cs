namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subjects : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Subjects", "Recruitment_Id", "dbo.Recruitments");
            DropIndex("dbo.Subjects", new[] { "Recruitment_Id" });
            CreateTable(
                "dbo.SubjectRecruitments",
                c => new
                    {
                        Subject_Id = c.Int(nullable: false),
                        Recruitment_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Subject_Id, t.Recruitment_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.Recruitments", t => t.Recruitment_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.Recruitment_Id);
            
            DropColumn("dbo.Subjects", "Recruitment_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Recruitment_Id", c => c.Int());
            DropForeignKey("dbo.SubjectRecruitments", "Recruitment_Id", "dbo.Recruitments");
            DropForeignKey("dbo.SubjectRecruitments", "Subject_Id", "dbo.Subjects");
            DropIndex("dbo.SubjectRecruitments", new[] { "Recruitment_Id" });
            DropIndex("dbo.SubjectRecruitments", new[] { "Subject_Id" });
            DropTable("dbo.SubjectRecruitments");
            CreateIndex("dbo.Subjects", "Recruitment_Id");
            AddForeignKey("dbo.Subjects", "Recruitment_Id", "dbo.Recruitments", "Id");
        }
    }
}
