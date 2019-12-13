using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class CandidateViewModel
	{

		[DisplayName("Imię")]
		public string FirstName { get; set; }

		[DisplayName("Drugie Imię")]
		public string SecondName { get; set; }

		[DisplayName("Nazwisko")]
		public string LastName { get; set; }

		[DisplayName("Data urodzenia")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateOfBirth { get; set; }

		[DisplayName("Miejsce urodzenia")]
		public string PlaceOfBirth { get; set; }

		[DisplayName("Numer telefonu")]
		[Phone]
		public string PhoneNumber { get; set; }

		[DisplayName("Pesel")]
		public string Pesel { get; set; }

		//public int? AddressId { get; set; }
		//public Address Address { get; set; }

		//public int? DocumentId { get; set; }
		//public Document Document { get; set; }

		//[Required]
		//public string UserId { get; set; }
		//public ApplicationUser User { get; set; }
	}
}