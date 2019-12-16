namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moreModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateId = c.Int(nullable: false),
                        RecruitmentId = c.Int(nullable: false),
                        RecruitmentStatusId = c.Int(nullable: false),
                        Points = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .ForeignKey("dbo.Recruitments", t => t.RecruitmentId, cascadeDelete: true)
                .ForeignKey("dbo.RecruitmentStatus", t => t.RecruitmentStatusId, cascadeDelete: true)
                .Index(t => t.CandidateId)
                .Index(t => t.RecruitmentId)
                .Index(t => t.RecruitmentStatusId);
            
            CreateTable(
                "dbo.Recruitments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Slots = c.Int(nullable: false),
                        FieldOfStudyId = c.Int(nullable: false),
                        StudyLevelId = c.Int(nullable: false),
                        StudyTypeId = c.Int(nullable: false),
                        RecruitmentPhaseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.FieldOfStudies", t => t.FieldOfStudyId, cascadeDelete: true)
                .ForeignKey("dbo.RecruitmentPhases", t => t.RecruitmentPhaseId, cascadeDelete: true)
                .ForeignKey("dbo.StudyLevels", t => t.StudyLevelId, cascadeDelete: true)
                .ForeignKey("dbo.StudyTypes", t => t.StudyTypeId, cascadeDelete: true)
                .Index(t => t.FieldOfStudyId)
                .Index(t => t.StudyLevelId)
                .Index(t => t.StudyTypeId)
                .Index(t => t.RecruitmentPhaseId);
            
            CreateTable(
                "dbo.FieldOfStudies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecruitmentPhases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Recruitment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Recruitments", t => t.Recruitment_Id)
                .Index(t => t.Recruitment_Id);
            
            CreateTable(
                "dbo.StudyLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudyTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecruitmentStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Result = c.Int(nullable: false),
                        IsAdvanced = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Exams", t => t.ExamId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.ExamId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SchoolId = c.Int(nullable: false),
                        ExamDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.SchoolId, cascadeDelete: true)
                .Index(t => t.SchoolId);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.AddressId, cascadeDelete: true)
                .Index(t => t.AddressId);
            
            AlterColumn("dbo.Addresses", "Street", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Addresses", "HouseNumber", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Addresses", "ApartmentNumber", c => c.Int());
            AlterColumn("dbo.Addresses", "City", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Country", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Documents", "SerialNumber", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.DocumentTypes", "Name", c => c.String(nullable: false, maxLength: 30));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ExamResults", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "SchoolId", "dbo.Schools");
            DropForeignKey("dbo.Schools", "AddressId", "dbo.Addresses");
            DropForeignKey("dbo.ExamResults", "ExamId", "dbo.Exams");
            DropForeignKey("dbo.Appliances", "RecruitmentStatusId", "dbo.RecruitmentStatus");
            DropForeignKey("dbo.Appliances", "RecruitmentId", "dbo.Recruitments");
            DropForeignKey("dbo.Recruitments", "StudyTypeId", "dbo.StudyTypes");
            DropForeignKey("dbo.Recruitments", "StudyLevelId", "dbo.StudyLevels");
            DropForeignKey("dbo.Subjects", "Recruitment_Id", "dbo.Recruitments");
            DropForeignKey("dbo.Recruitments", "RecruitmentPhaseId", "dbo.RecruitmentPhases");
            DropForeignKey("dbo.Recruitments", "FieldOfStudyId", "dbo.FieldOfStudies");
            DropForeignKey("dbo.Appliances", "CandidateId", "dbo.Candidates");
            DropIndex("dbo.Schools", new[] { "AddressId" });
            DropIndex("dbo.Exams", new[] { "SchoolId" });
            DropIndex("dbo.ExamResults", new[] { "SubjectId" });
            DropIndex("dbo.ExamResults", new[] { "ExamId" });
            DropIndex("dbo.Subjects", new[] { "Recruitment_Id" });
            DropIndex("dbo.Recruitments", new[] { "RecruitmentPhaseId" });
            DropIndex("dbo.Recruitments", new[] { "StudyTypeId" });
            DropIndex("dbo.Recruitments", new[] { "StudyLevelId" });
            DropIndex("dbo.Recruitments", new[] { "FieldOfStudyId" });
            DropIndex("dbo.Appliances", new[] { "RecruitmentStatusId" });
            DropIndex("dbo.Appliances", new[] { "RecruitmentId" });
            DropIndex("dbo.Appliances", new[] { "CandidateId" });
            AlterColumn("dbo.DocumentTypes", "Name", c => c.String());
            AlterColumn("dbo.Documents", "SerialNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Addresses", "Country", c => c.String());
            AlterColumn("dbo.Addresses", "ZipCode", c => c.String());
            AlterColumn("dbo.Addresses", "City", c => c.String());
            AlterColumn("dbo.Addresses", "ApartmentNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "HouseNumber", c => c.Int(nullable: false));
            AlterColumn("dbo.Addresses", "Street", c => c.String());
            DropTable("dbo.Schools");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamResults");
            DropTable("dbo.RecruitmentStatus");
            DropTable("dbo.StudyTypes");
            DropTable("dbo.StudyLevels");
            DropTable("dbo.Subjects");
            DropTable("dbo.RecruitmentPhases");
            DropTable("dbo.FieldOfStudies");
            DropTable("dbo.Recruitments");
            DropTable("dbo.Appliances");
        }
    }
}
