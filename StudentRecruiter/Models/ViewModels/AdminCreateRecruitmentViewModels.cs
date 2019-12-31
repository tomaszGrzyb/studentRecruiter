using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class AdminCreateRecruitmentViewModel
	{
		public int RecruitmentId { get; set; }

		[DisplayName("Kierunek")]
		public List<FieldOfStudy> FieldOfStudies { get; set; }
		public int FieldOfStudyId { get; set; }

		[DisplayName("Ilość miejsc")]
		public int Slots { get; set; }		

		[DisplayName("Tryb studiów")]
		public List<StudyType> StudyTypes { get; set; }
		public int StudyTypeId { get; set; }

		[DisplayName("Stopień studiów")]
		public List<StudyLevel> StudyLevels { get; set; }
		public int StudyLevelId { get; set; }

		[DisplayName("Etapy rekrutacji")]
		public List<RecruitmentPhase> RecruitmentPhases { get; set; }
		public int RecruitmentPhaseId { get; set; }

		[DisplayName("Wymagane przedmioty na egzaminie maturalnym")]
		public List<Subject> RequiredSubjects { get; set; }

		

	}
}