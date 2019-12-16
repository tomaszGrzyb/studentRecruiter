using Microsoft.AspNet.Identity.EntityFramework;
using StudentRecruiter.Models.Domain;
using System.Data.Entity;

namespace StudentRecruiter.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<Address> Addresses { get; set; }
		public DbSet<Document> Documents { get; set; }
		public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<RecruitmentPhase> RecruitmentPhases { get; set; }
        public DbSet<RecruitmentStatus> RecruitmentStatuses { get; set; }
        public DbSet<FieldOfStudy> FieldsOfStudies { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<StudyLevel> StudyLevels { get; set; }
        public DbSet<StudyType> StudyTypes { get; set; }
        public DbSet<Appliance> Appliances { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}