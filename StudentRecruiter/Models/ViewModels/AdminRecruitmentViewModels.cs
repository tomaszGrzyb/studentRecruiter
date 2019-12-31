using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class AdminRecruitmentViewModel
	{
		public int RecruitmentId { get; set; }

		[DisplayName("Kierunek")]
		public string FieldOfStudy { get; set; }

		[DisplayName("Ilość miejsc")]
		public int Slots { get; set; }		

		[DisplayName("Tryb studiów")]
		public string StudyType{ get; set; }

		[DisplayName("Stopień studiów")]
		public string StudyLevel { get; set; }

		[DisplayName("Etapy rekrutacji")]
		public string RecruitmentPhase { get; set; }

		[DisplayName("Wymagane przedmioty na egzaminie maturalnym")]
		public List<Subject> RequiredSubjects { get; set; }

		

	}
}