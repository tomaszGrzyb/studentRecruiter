namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class examId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CandidateDetails", "ExamId", "dbo.Exams");
            DropIndex("dbo.CandidateDetails", new[] { "ExamId" });
            AddColumn("dbo.Exams", "CandidateDetailsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Exams", "CandidateDetailsId");
            AddForeignKey("dbo.Exams", "CandidateDetailsId", "dbo.CandidateDetails", "Id");
            DropColumn("dbo.CandidateDetails", "ExamId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CandidateDetails", "ExamId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Exams", "CandidateDetailsId", "dbo.CandidateDetails");
            DropIndex("dbo.Exams", new[] { "CandidateDetailsId" });
            DropColumn("dbo.Exams", "CandidateDetailsId");
            CreateIndex("dbo.CandidateDetails", "ExamId");
            AddForeignKey("dbo.CandidateDetails", "ExamId", "dbo.Exams", "Id");
        }
    }
}
