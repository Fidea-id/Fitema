using System;
using System.ComponentModel.DataAnnotations;
using Fitema.Utils.ValidationAttributes;

namespace Fitema.Requests
{
	public class TransactionSubmitRequest
	{
		public TransactionSubmitRequest()
		{
		}
		public string? PhoneNumber { get; set; }

        [Required]
		public string Name { get; set; }
        [Required]
        [EmailAddress]
		public string Email { get; set; }

        [Required]
        [AllowedExtensions(new string[] {".jpg", ".png", ".jpeg"})]
		[MaxFileSize(10)]
		public IFormFile InvoiceImage { get; set; }
        [Required]
        public string ARCode { get; set; }
        public string Region { get; set; }
		public string StoreName { get; set; }
        [Required]
        [MaxLength(150)]
        public string CustomerSlogan { get; set; }
	}
}

