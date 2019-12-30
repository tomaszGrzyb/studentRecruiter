using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class ExamResultDetailsViewModel
	{
		[DisplayName("Przedmiot szkolny")]
		public string Subject { get; set; }

		[Required]
		[DisplayName("Wynik")]
		public int Result { get; set; }

		[DisplayName("Czy rozszerzona?")]
		public bool IsAdvanced { get; set; }

	}
}