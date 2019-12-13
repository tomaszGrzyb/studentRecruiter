using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentRecruiter.Models.ViewModels
{
	public class DocumentViewModel
	{
		public int Id { get; set; }
		public short DocumentTypeId { get; set; }
		[DisplayName("Typ dokumentu")]
		public string DocumentType { get; set; }
		[DisplayName("Numer serii")]
		public string SerialNumber { get; set; }
		[DisplayName("Data ważności")]
		public DateTime ExpirationDate { get; set; }
	}
}