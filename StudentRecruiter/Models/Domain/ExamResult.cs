using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class ExamResult
	{
		public int Id { get; set; }
	    public int ExamId { get; set; }
	    public int SubjectId { get; set; }
		[DisplayName("Uzyskane punkty")]
	    public int Result { get; set; }
		[DisplayName("Czy matura rozszerzona?")]
		public bool IsAdvanced { get; set; }
	    public Subject Subject { get; set; }
        public Exam Exam { get; set; }


    }
}