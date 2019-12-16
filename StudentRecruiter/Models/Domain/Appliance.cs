using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class Appliance
	{
		public int Id { get; set; }

        [Required]
	    public int CandidateId { get; set; }

	    [Required]
        public int RecruitmentId { get; set; }

	    [Required]
        public int RecruitmentStatusId { get; set; }
	    public decimal Points { get; set; }

	    [Required]
        public DateTime CreationDate { get; set; }
        
        public CandidateDetails Candidate { get; set; }
	    public Recruitment Recruitment { get; set; }
	    public RecruitmentStatus RecruitmentStatus { get; set; }
    }
}