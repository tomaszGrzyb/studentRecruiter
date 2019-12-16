using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class School
	{
		public int Id { get; set; }
        [Required]
        [StringLength(100)]

        public string Name { get; set; }
	    public  int AddressId { get; set; }
	    public Address Address { get; set; }

    }
}