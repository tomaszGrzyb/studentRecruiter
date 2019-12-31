using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class RequiredSubjectsViewModel
	{
		public int RecruitmentId { get; set; }

		public int SubjectId { get; set; }

		[DisplayName("Przedmioty maturalne")]
		public List<Subject> Subjects { get; set; }

	}
}