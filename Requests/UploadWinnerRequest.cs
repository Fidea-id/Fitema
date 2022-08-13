using System;
using System.ComponentModel.DataAnnotations;
using Fitema.Utils.ValidationAttributes;

namespace Fitema.Requests
{
	public class UploadWinnerRequest
	{
		public UploadWinnerRequest()
		{
		}
        [Required]
		public string? Period { get; set; }
        [Required]
        [AllowedExtensions(new string[] {".xls", ".xlsx"})]
		public IFormFile? Spreadsheet { get; set; }
	}
}

