using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class Address
	{
		public int Id { get; set; }

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
	}
}