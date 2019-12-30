namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CandidateDetails", "ExamId", c => c.Int(nullable: false));
            CreateIndex("dbo.CandidateDetails", "ExamId");
            AddForeignKey("dbo.CandidateDetails", "ExamId", "dbo.Exams", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateDetails", "ExamId", "dbo.Exams");
            DropIndex("dbo.CandidateDetails", new[] { "ExamId" });
            DropColumn("dbo.CandidateDetails", "ExamId");
        }
    }
}
