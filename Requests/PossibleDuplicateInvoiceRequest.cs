using System;
using System.ComponentModel.DataAnnotations;

namespace Fitema.Requests
{
	public class PossibleDuplicateInvoiceRequest
	{
		public PossibleDuplicateInvoiceRequest()
		{
		}
        [Required]
		public decimal? InvoiceTotal { get; set; }
        [Required]
		public DateTime? InvoiceDate { get; set; }
        [Required]
		public string? ARCode { get; set; }
	}
}

