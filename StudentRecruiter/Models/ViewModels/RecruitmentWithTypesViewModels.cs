using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class RecruitmentWithTypesViewModel
	{
		public List<RecruitmentViewModel> FullTimeStudies { get; set; }
		public List<RecruitmentViewModel> WeekendStudies { get; set; }
	}
}