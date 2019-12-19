using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class ExamViewModel
	{

		[DisplayName("Nazwa szkoły")]
		[Required]
		public string SchoolName { get; set; }

		[Required]
		[StringLength(50)]
		[DisplayName("Ulica")]
		public string Street { get; set; }

		[Required]
		[StringLength(30)]
		[DisplayName("Miasto")]
		public string City { get; set; }

		[Required]
		[DisplayName("Kod pocztowy")]
		public string ZipCode { get; set; }

		[Required]
		[StringLength(30)]
		[DisplayName("Kraj")]
		public string Country { get; set; }

		[Required]
		[DisplayName("Data egzaminu")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime ExamDate { get; set; }


		[DisplayName("Wyniki egzaminu")]
		public List<ExamResult> ExamResults { get; set; }

	}
}