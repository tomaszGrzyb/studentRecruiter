using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class RecruitmentPhase
	{
		public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
	    [Required]
        public DateTime DateFrom { get; set; }
	    [Required]
        public DateTime DateTo { get; set; }

    }
}