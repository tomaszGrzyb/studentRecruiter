using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class MainRecruitmentWithTypesViewModel
	{
		[DisplayName("Etap rekrutacji")]
		public string PhaseName { get; set; }

		[DisplayName("Data rozpoczęcia")]
		public string DateFrom { get; set; }

		[DisplayName("Data zakończenia")]
		public string DateTo { get; set; }

		public List<MainRecruitmentViewModel> FullTimeStudies { get; set; }
		public List<MainRecruitmentViewModel> WeekendStudies { get; set; }
	}
}