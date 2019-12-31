using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class SuccessViewModel
	{
		public int Id { get; set; }

		[DisplayName("Kierunek")]
		public  string FieldOfStudy { get; set; }	

		[DisplayName("Twoja pozycja na liście")]
		public int Rank { get; set; }

		[DisplayName("Uzyskane punkty")]
		public decimal Points { get; set; }

		[DisplayName("Numer rekrutacji")]
		public string RecrutationNumber { get; set; }

		[DisplayName("Status rekrutacji")]
		public string Status { get; set; }

		[DisplayName("Opis")]
		public string Description { get; set; }


		[DisplayName("Zamknięcie rekrutacji nastąpi")]
		public string ClosingDate { get; set; }
	}
}