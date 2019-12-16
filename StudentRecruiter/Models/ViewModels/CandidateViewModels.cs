using StudentRecruiter.Models.Domain;
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

	    [Required]
	    [StringLength(50)]
	    public string Street { get; set; }

	    [Required]
	    [StringLength(10)]
	    public string HouseNumber { get; set; }

	    public int? ApartmentNumber { get; set; }

	    [Required]
	    [StringLength(30)]
	    public string City { get; set; }

	    [Required]
	    public string ZipCode { get; set; }

	    [Required]
	    [StringLength(30)]
	    public string Country { get; set; }

        public int DocumentTypeId { get; set; }
        public List<DocumentType> DocumentTypes { get; set; }
    }
}