using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class MainRecruitmentViewModel
	{
		[DisplayName("Kierunek")]
		public string FieldOfStudy { get; set; }

		[DisplayName("Opis")]
		public string Description { get; set; }

		[DisplayName("Ilość miejsc")]
		public int Slots { get; set; }		

		[DisplayName("Tryb studiów")]
		public string StudyType { get; set; }
		public int StudyTypeId { get; set; }

		[DisplayName("Wymagane przedmioty na egzaminie maturalnym")]
		public List<Subject> RequiredSubjects { get; set; }

		

	}
}