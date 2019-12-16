using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class RecruitmentStatus
	{
		public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
	    public string Description { get; set; }
    }
}