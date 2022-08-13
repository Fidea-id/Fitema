using System;
using System.ComponentModel.DataAnnotations;

namespace Fitema.Requests
{
	public class TransactionVerifyRequest
	{
		public TransactionVerifyRequest()
		{
		}
		public bool? AcceptAnyway { get; set; }
        [Required]
		public int? TransactionsId { get; set; }
		public string? InvoiceNumber { get; set; }
        [DataType(DataType.DateTime)]
		public DateTime? InvoiceDate { get; set; }
        [Required]		
        [DataType(DataType.Currency)]
		public decimal? InvoiceTotal { get; set; }
        [Required]
		public int? StatusId { get; set; }
		public string? StatusNote { get; set; }
		public bool IsStoreValid { get; set; }
		public ProductItemRequest[]? Products { get; set; }
	}
	public class ProductItemRequest 
    {
        public ProductItemRequest()
        {
        }
        [Required]
		public long? _12NC { get; set; }
        [Required]
		public string Name { get; set; }
        [Required]		
        [DataType(DataType.Currency)]
		public decimal? Price { get; set; }
        [Required]
		public int? Qty { get; set; }
        [Required]		
        [DataType(DataType.Currency)]
		public decimal? TotalPrice { get; set; }
	}

}

