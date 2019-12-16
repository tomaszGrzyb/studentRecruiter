using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.Domain
{
	public class CandidateDetails
	{
		[Key]
		public int Id { get; set; }

	    public ApplicationUser ApplicationUser { get; set; }
		[Required]
		public string ApplicationUserId { get; set; }

		[StringLength(50)]
		public string SecondName { get; set; }

		[Required]
		public DateTime DateOfBirth { get; set; }

		[StringLength(50)]
		public string PlaceOfBirth { get; set; }

		[StringLength(25)]
		public string PhoneNumber { get; set; }
		public string Pesel { get; set; }

		public int AddressId { get; set; }
		public Address Address { get; set; }

		public int DocumentId { get; set; }
		public Document Document { get; set; }


	}
}