using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class ExamResultViewModel
	{

		[DisplayName("Nazwa szkoły")]
		[Required]
		public string SchoolName { get; set; }

		[DisplayName("Drugie Imię")]
		public string SecondName { get; set; }

		[Required]
		[DisplayName("Nazwisko")]
		public string LastName { get; set; }


		[Required]
		[DisplayName("Data egzaminu")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime ExamDate { get; set; }

		[Required]
		[DisplayName("Miejsce urodzenia")]
		public string PlaceOfBirth { get; set; }

		[DisplayName("Numer telefonu")]
		[Phone]
		[StringLength(25)]
		public string PhoneNumber { get; set; }

		[DisplayName("Pesel")]
		[StringLength(50)]
		public string Pesel { get; set; }

	    [Required]
	    [StringLength(50)]
		[DisplayName("Ulica")]
		public string Street { get; set; }

	    [Required]
	    [StringLength(10)]
		[DisplayName("Nr domu")]
		public string HouseNumber { get; set; }

		[DisplayName("Nr mieszkania")]
		public int? ApartmentNumber { get; set; }

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
		[StringLength(30)]
		[DisplayName("Nr seryjny")]
		public string SerialNumber { get; set; }
			
		[DisplayName("Typ dokumentu")]
		public List<DocumentType> DocumentTypes { get; set; }

		[Required]
		public short DocumentTypeId { get; set; }

		[Required]
		[DisplayName("Data ważności")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime ExpirationDate { get; set; }

	}
}