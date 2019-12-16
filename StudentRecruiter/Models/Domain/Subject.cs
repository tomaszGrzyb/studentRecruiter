﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class Subject
	{
		public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }
	   
    }
}