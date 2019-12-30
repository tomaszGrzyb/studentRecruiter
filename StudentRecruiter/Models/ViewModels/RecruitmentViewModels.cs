using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class RecruitmentViewModel
	{
		[DisplayName("Kierunek")]
		public  string FieldOfStudy { get; set; }

		[DisplayName("Ilość miejsc")]
		public int Slots { get; set; }

		[DisplayName("Twoja pozycja na liście")]
		public int Rank { get; set; }

		[DisplayName("Uzyskane punkty")]
		public decimal Points { get; set; }

		public int StudyTypeId { get; set; }
		public int RecruitmentId { get; set; }

	}
}