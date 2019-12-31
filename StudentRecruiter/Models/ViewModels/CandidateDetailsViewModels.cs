using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class CandidateDetailsViewModel
	{

		[DisplayName("Imię")]		
		public string FirstName { get; set; }

		[DisplayName("Drugie Imię")]
		public string SecondName { get; set; }

	
		[DisplayName("Nazwisko")]
		public string LastName { get; set; }


		[DisplayName("Data urodzenia")]
		public string DateOfBirth { get; set; }

		
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
		[RegularExpression("^\\d{2}(-\\d{3})?$", ErrorMessage = "Błędny kod pocztowy")]
		public string ZipCode { get; set; }

	    [Required]	    
		[DisplayName("Kraj")]
		public string Country { get; set; }

		[Required]
		[StringLength(30)]
		[DisplayName("Nr seryjny")]
		public string SerialNumber { get; set; }
			
		[DisplayName("Typ dokumentu")]
		public string DocumentType { get; set; }
	
		[DisplayName("Data ważności")]
		public string ExpirationDate { get; set; }

		[DisplayName("Nazwa szkoły")]
		public string SchoolName { get; set; }

		[DisplayName("Ulica")]
		public string SchoolStreet { get; set; }

		[DisplayName("Nr budynku")]
		public string SchoolNumber { get; set; }	

		[Required]
		[StringLength(30)]
		[DisplayName("Miasto")]
		public string SchoolCity { get; set; }

		[Required]
		[DisplayName("Kod pocztowy")]
		public string SchoolZipCode { get; set; }

		[Required]
		[DisplayName("Kraj")]
		public string SchoolCountry { get; set; }

		public List<ExamResultDetailsViewModel> ExamResults { get; set; }

	}
}