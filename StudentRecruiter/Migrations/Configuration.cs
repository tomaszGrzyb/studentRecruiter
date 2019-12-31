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
			SeedPhases(context);
			SeedSubjects(context);
			SeedRecruitments(context);

		}

		private void SeedDocumentTypes(ApplicationDbContext context)
		{
			if (context.DocumentTypes.Count() == 0)
			{
				context.DocumentTypes.Add(new Models.Domain.DocumentType() { Name = "Paszport" });
				context.DocumentTypes.Add(new Models.Domain.DocumentType() { Name = "Dowód osobisty" });
				context.SaveChanges();
			}

		}

		private void SeedStudyTypes(ApplicationDbContext context)
		{
			if (context.StudyTypes.Count() == 0)
			{
				context.StudyTypes.Add(new Models.Domain.StudyType() { Name = "Stacjonarne", Description = "Zajêcia odbywaj¹ siê w tygodniu" });
				context.StudyTypes.Add(new Models.Domain.StudyType() { Name = "Niestacjonarne", Description = "Zajêcia odbywaj¹ siê w co drugi weekend" });
				context.SaveChanges();
			}
		
		}

		private void SeedStudyLevels(ApplicationDbContext context)
		{
			if (context.StudyLevels.Count() == 0)
			{
				context.StudyLevels.Add(new Models.Domain.StudyLevel() { Name = "I Stopnia", Description = "W zale¿noœci od kierunku mog¹ to byæ studia in¿ynierskie b¹dŸ licencjackie" });
				context.StudyLevels.Add(new Models.Domain.StudyLevel() { Name = "II Stopnia", Description = "Studia magisterskie" });
				context.SaveChanges();
			}
	
		}

		private void SeedFieldOfStudies(ApplicationDbContext context)
		{
			if (context.FieldsOfStudies.Count() == 0)
			{
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Informatyka", Description = "Dla tych, co lubi¹ technologiê" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Matematyka", Description = "Dla tych, co lubi¹ liczyæ" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Administracja", Description = "Dla tych, co lubi¹ zarz¹dzaæ" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Prawo", Description = "Dla tych, co lubi¹ zasady" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Rolnictwo", Description = "Dla tych, co lubi¹ roœliny" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Bankowoœæ", Description = "Dla tych, co lubi¹ liczyæ pieni¹dze" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Budownictwo", Description = "Dla tych, co lubi¹ budowaæ" });
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Architektura", Description = "Dla tych, co lubi¹ projektowaæ" });
				context.SaveChanges();
			}

		}

		private void SeedRecruitmentStatuses(ApplicationDbContext context)
		{
			if (context.RecruitmentStatuses.Count() == 0)
			{
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Nowa", Description = "Rekrutacja zosta³a utworzona" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Oczekiwanie na zap³atê", Description = "Zg³oszenie zosta³o wprowadzone do systemu. Aby zatwierdziæ kandydaturê nale¿y op³aciæ rezerwacjê." });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Zap³acono" ,Description ="Rezerwacja jest op³acona i oczekuje na zamkniêcie okresu rekrutacji i podliczenie wyników."});
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Zakwalifikowano", Description = "Kandydat zosta³ przyjêty na studia" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Odrzucono", Description = "Kandydat zosta³ odrzucony"});
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Anulowana", Description = "Rekrutacja zosta³a anulowana" });
				context.SaveChanges();
			}
		
		}


		private void SeedSubjects(ApplicationDbContext context)
		{
			if (context.Subjects.Count() == 0)
			{
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Matematyka" });	
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Fizyka" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Chemia" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Biologia" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Geografia" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Informatyka" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Historia" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Wiedza o spo³eczeñstwie" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Jêzyk polski" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Jêzyk angielski" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Jêzyk francuski" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Jêzyk niemiecki" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Jêzyk rosyjski" });
				context.SaveChanges();
			}

		}

		private void SeedPhases(ApplicationDbContext context)
		{
			if (context.RecruitmentPhases.Count() == 0)
			{
				context.RecruitmentPhases.Add(new Models.Domain.RecruitmentPhase() { Name = "Rekrutacja zimowa",DateFrom=new DateTime(2019,12,1),DateTo= new DateTime(2020,3,1) });
				context.RecruitmentPhases.Add(new Models.Domain.RecruitmentPhase() { Name = "Rekrutacja letnia", DateFrom = new DateTime(2020, 4, 1), DateTo = new DateTime(2020, 8, 1) });
				context.SaveChanges();				
			}

		}

		private void SeedRecruitments(ApplicationDbContext context)
		{
			if (context.Recruitments.Count() == 0)
			{
				var requiredSubjectsIT = context.Subjects.Where(s => s.Name == "Informatyka" || s.Name == "Matematyka" || s.Name == "Fizyka").ToList();
				var requiredSubjectsLaw = context.Subjects.Where(s => s.Name == "Wiedza o spo³eczeñstwie" || s.Name == "Jêzyk polski" || s.Name == "Historia").ToList();
				var requiredSubjectsFarm = context.Subjects.Where(s => s.Name == "Biologia" || s.Name == "Chemia" || s.Name == "Geografia").ToList();

				var fieldOfStudyIT = context.FieldsOfStudies.Where(f => f.Name == "Informatyka").FirstOrDefault();
				var fieldOfStudyLaw = context.FieldsOfStudies.Where(f => f.Name == "Prawo").FirstOrDefault();
				var fieldOfStudyFarm = context.FieldsOfStudies.Where(f => f.Name == "Rolnictwo").FirstOrDefault();

				var recruitmentPhase = context.RecruitmentPhases.Where(p => p.Name == "Rekrutacja zimowa").FirstOrDefault();

				context.Recruitments.Add(new Models.Domain.Recruitment()
				{					
					RequiredSubjects = requiredSubjectsIT,
					FieldOfStudyId = fieldOfStudyIT.Id,
					RecruitmentPhaseId = recruitmentPhase.Id,
					Slots = 5,
					StudyLevelId = 1,
					StudyTypeId = 1
				});
				
				context.Recruitments.Add(new Models.Domain.Recruitment()
				{
					RequiredSubjects = requiredSubjectsLaw,
					FieldOfStudyId = fieldOfStudyLaw.Id,
					RecruitmentPhaseId = recruitmentPhase.Id,
					Slots = 2,
					StudyLevelId = 1,
					StudyTypeId = 1
				});

				context.Recruitments.Add(new Models.Domain.Recruitment()
				{
					RequiredSubjects = requiredSubjectsFarm,
					FieldOfStudyId = fieldOfStudyFarm.Id,
					RecruitmentPhaseId = recruitmentPhase.Id,
					Slots = 10,
					StudyLevelId = 1,
					StudyTypeId = 2
				});

				context.SaveChanges();
			}

		}
	}
}
