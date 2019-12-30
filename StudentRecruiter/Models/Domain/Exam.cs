using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Win32.SafeHandles;

namespace StudentRecruiter.Models.Domain
{
	public class Exam
	{
		public int Id { get; set; }
		public int CandidateDetailsId { get; set; }
		public int SchoolId { get; set; }
		public DateTime ExamDate { get; set; }
		public List<ExamResult> Results { get; set; }
		public School School { get; set; }
		public CandidateDetails CandidateDetails {get;set;}

    }
}