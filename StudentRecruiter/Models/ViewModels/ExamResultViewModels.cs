﻿using StudentRecruiter.Models.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class ExamResultViewModel
	{
		public int ExamId { get; set; }
		public int ExamResultId { get; set; }

		public int SubjectId { get; set; }

		[DisplayName("Przedmioty szkolne")]
		public List<Subject> Subjects { get; set; }

		[Required]
		[DisplayName("Wynik")]
		public int Result { get; set; }

		[DisplayName("Czy rozszerzona?")]
		public bool IsAdvanced { get; set; }

	}
}