namespace StudentRecruiter.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using StudentRecruiter.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
			AutomaticMigrationDataLossAllowed = true;
		}

        protected override void Seed(Models.ApplicationDbContext context)
        {
			SeedDocumentTypes(context);
			SeedFieldOfStudies(context);
			SeedRecruitmentStatuses(context);
			SeedStudyLevels(context);
			SeedStudyTypes(context);
			
        }

		private void SeedDocumentTypes(ApplicationDbContext context)
		{
			if (context.DocumentTypes.Count() == 0)
			{
				context.DocumentTypes.Add(new Models.Domain.DocumentType() { Name = "Paszport" });
				context.DocumentTypes.Add(new Models.Domain.DocumentType() { Name = "Dow�d osobisty" });
				context.SaveChanges();
			}

		}

		private void SeedStudyTypes(ApplicationDbContext context)
		{
			if (context.StudyTypes.Count() == 0)
			{
				context.StudyTypes.Add(new Models.Domain.StudyType() { Name = "Stacjonarne", Description = "Zaj�cia odbywaj� si� w tygodniu" });
				context.StudyTypes.Add(new Models.Domain.StudyType() { Name = "Niestacjonarne", Description = "Zaj�cia odbywaj� si� w co drugi weekend" });
				context.SaveChanges();
			}
		
		}

		private void SeedStudyLevels(ApplicationDbContext context)
		{
			if (context.StudyLevels.Count() == 0)
			{
				context.StudyLevels.Add(new Models.Domain.StudyLevel() { Name = "I Stopnia", Description = "W zale�no�ci od kierunku mog� to by� studia in�ynierskie b�d� licencjackie" });
				context.StudyLevels.Add(new Models.Domain.StudyLevel() { Name = "II Stopnia", Description = "Studia magisterskie" });
				context.SaveChanges();
			}
	
		}

		private void SeedFieldOfStudies(ApplicationDbContext context)
		{
			if (context.FieldsOfStudies.Count() == 0)
			{
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Informatyka", Description = "Dla tych, co lubi� technologi�" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Matematyka", Description = "Dla tych, co lubi� liczy�" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Administracja", Description = "Dla tych, co lubi� zarz�dza�" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Prawo", Description = "Dla tych, co lubi� zasady" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Rolnictwo", Description = "Dla tych, co lubi� sadzi�" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Bankowo��", Description = "Dla tych, co lubi� liczy� pieni�dze" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Budownictwo", Description = "Dla tych, co lubi� budowa�" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Architektura", Description = "Dla tych, co lubi� projektowa�" });
				context.SaveChanges();
			}

		}

		private void SeedRecruitmentStatuses(ApplicationDbContext context)
		{
			if (context.RecruitmentStatuses.Count() == 0)
			{
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Nowa" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Oczekiwanie na zap�at�" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Zap�acono" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Zakwalifikowano" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Odrzucono" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Anulowana" });
				context.SaveChanges();
			}
		
		}
	}
}
