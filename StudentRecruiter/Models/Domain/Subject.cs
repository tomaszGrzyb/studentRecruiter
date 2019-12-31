﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class Subject
	{
		public int Id { get; set; }

        [Required]
        [StringLength(30)]
		[DisplayName("Przedmiot")]
        public string Name { get; set; }

		public virtual ICollection<Recruitment> Recruitments { get; set; }


	}
}