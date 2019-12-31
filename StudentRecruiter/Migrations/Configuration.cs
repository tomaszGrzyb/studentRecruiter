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
				context.FieldsOfStudies.Add(new Models.Domain.FieldOfStudy() { Name = "Rolnictwo", Description = "Dla tych, co lubi� ro�liny" });
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
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Nowa", Description = "Rekrutacja zosta�a utworzona" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Oczekiwanie na zap�at�", Description = "Zg�oszenie zosta�o wprowadzone do systemu. Aby zatwierdzi� kandydatur� nale�y op�aci� rezerwacj�." });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Zap�acono" ,Description ="Rezerwacja jest op�acona i oczekuje na zamkni�cie okresu rekrutacji i podliczenie wynik�w."});
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Zakwalifikowano", Description = "Kandydat zosta� przyj�ty na studia" });
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Odrzucono", Description = "Kandydat zosta� odrzucony"});
				context.RecruitmentStatuses.Add(new Models.Domain.RecruitmentStatus() { Name = "Anulowana", Description = "Rekrutacja zosta�a anulowana" });
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
				context.Subjects.Add(new Models.Domain.Subject() { Name = "Wiedza o spo�ecze�stwie" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "J�zyk polski" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "J�zyk angielski" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "J�zyk francuski" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "J�zyk niemiecki" });
				context.Subjects.Add(new Models.Domain.Subject() { Name = "J�zyk rosyjski" });
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
				var requiredSubjectsLaw = context.Subjects.Where(s => s.Name == "Wiedza o spo�ecze�stwie" || s.Name == "J�zyk polski" || s.Name == "Historia").ToList();
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
