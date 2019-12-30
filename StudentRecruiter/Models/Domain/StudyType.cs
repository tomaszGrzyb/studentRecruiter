using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class StudyType
	{
		public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }

    }
}