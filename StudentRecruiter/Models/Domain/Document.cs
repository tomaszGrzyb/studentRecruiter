using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StudentRecruiter.Models.Domain
{
	public class Document
	{
		public int Id { get; set; }

		[Required]
		public short DocumentTypeId { get; set; }		
		public DocumentType DocumentType { get; set; }

		[Required]
		[StringLength(30)]
        public string SerialNumber { get; set; }

		[Required]
		public DateTime ExpirationDate { get; set; }
	}
}