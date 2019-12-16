namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class candidateDetails5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Appliances", "CandidateId", "dbo.CandidateDetails");
            DropForeignKey("dbo.Appliances", "RecruitmentId", "dbo.Recruitments");
            DropForeignKey("dbo.Appliances", "RecruitmentStatusId", "dbo.RecruitmentStatus");
            DropForeignKey("dbo.CandidateDetails", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.CandidateDetails", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Recruitments", "FieldOfStudyId", "dbo.FieldOfStudies");
            DropForeignKey("dbo.Recruitments", "RecruitmentPhaseId", "dbo.RecruitmentPhases");
            DropForeignKey("dbo.Recruitments", "StudyLevelId", "dbo.StudyLevels");
            DropForeignKey("dbo.Recruitments", "StudyTypeId", "dbo.StudyTypes");
            DropForeignKey("dbo.ExamResults", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.ExamResults", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Schools", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.CandidateDetails", new[] { "ApplicationUserId" });
            AlterColumn("dbo.CandidateDetails", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CandidateDetails", "ApplicationUserId");
            AddForeignKey("dbo.Appliances", "CandidateId", "dbo.CandidateDetails", "Id");
            AddForeignKey("dbo.Appliances", "RecruitmentId", "dbo.Recruitments", "Id");
            AddForeignKey("dbo.Appliances", "RecruitmentStatusId", "dbo.RecruitmentStatus", "Id");
            AddForeignKey("dbo.CandidateDetails", "AddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.CandidateDetails", "DocumentId", "dbo.Documents", "Id");
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Recruitments", "FieldOfStudyId", "dbo.FieldOfStudies", "Id");
            AddForeignKey("dbo.Recruitments", "RecruitmentPhaseId", "dbo.RecruitmentPhases", "Id");
            AddForeignKey("dbo.Recruitments", "StudyLevelId", "dbo.StudyLevels", "Id");
            AddForeignKey("dbo.Recruitments", "StudyTypeId", "dbo.StudyTypes", "Id");
            AddForeignKey("dbo.ExamResults", "ExamId", "dbo.Exams", "Id");
            AddForeignKey("dbo.ExamResults", "SubjectId", "dbo.Subjects", "Id");
            AddForeignKey("dbo.Exams", "SchoolId", "dbo.Schools", "Id");
            AddForeignKey("dbo.Schools", "AddressId", "dbo.Addresses", "Id");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Schools", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Exams", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.ExamResults", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.ExamResults", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Recruitments", "StudyTypeId", "dbo.StudyTypes");
            DropForeignKey("dbo.Recruitments", "StudyLevelId", "dbo.StudyLevels");
            DropForeignKey("dbo.Recruitments", "RecruitmentPhaseId", "dbo.RecruitmentPhases");
            DropForeignKey("dbo.Recruitments", "FieldOfStudyId", "dbo.FieldOfStudies");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CandidateDetails", "DocumentId", "dbo.Documents");
            DropForeignKey("dbo.CandidateDetails", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.Appliances", "RecruitmentStatusId", "dbo.RecruitmentStatus");
            DropForeignKey("dbo.Appliances", "RecruitmentId", "dbo.Recruitments");
            DropForeignKey("dbo.Appliances", "CandidateId", "dbo.CandidateDetails");
            DropIndex("dbo.CandidateDetails", new[] { "ApplicationUserId" });
            AlterColumn("dbo.CandidateDetails", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CandidateDetails", "ApplicationUserId");
            AddForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Schools", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Exams", "SchoolId", "dbo.Schools", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExamResults", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ExamResults", "ExamId", "dbo.Exams", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recruitments", "StudyTypeId", "dbo.StudyTypes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recruitments", "StudyLevelId", "dbo.StudyLevels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recruitments", "RecruitmentPhaseId", "dbo.RecruitmentPhases", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Recruitments", "FieldOfStudyId", "dbo.FieldOfStudies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CandidateDetails", "DocumentId", "dbo.Documents", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CandidateDetails", "AddressId", "dbo.Addresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appliances", "RecruitmentStatusId", "dbo.RecruitmentStatus", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appliances", "RecruitmentId", "dbo.Recruitments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Appliances", "CandidateId", "dbo.CandidateDetails", "Id", cascadeDelete: true);
        }
    }
}
