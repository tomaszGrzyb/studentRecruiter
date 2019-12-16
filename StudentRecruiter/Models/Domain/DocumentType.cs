using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class DocumentType
	{
		public int Id { get; set; }

	    [StringLength(30)]
        [Required]
        public string Name { get; set; }

	}
}