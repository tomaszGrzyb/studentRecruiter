﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.Domain
{
    public class FieldOfStudy
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
		[DisplayName("Nazwa")]
        public string Name { get; set; }

		[DisplayName("Opis")]
		public string Description { get; set; }
       
    }
}