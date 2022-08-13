using System;
namespace Fitema.Models
{
	public class Products : BaseModel
	{
		public Products()
		{
		}
		public int OrgId { get; set; }
		public int Price { get; set; }
		public string Name { get; set; }
		public int Promo { get; set; }
		public string Period { get; set; }
	}
}

