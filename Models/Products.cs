using System;
namespace Fitema.Models
{
	public class Products : BaseModel
	{
		public Products()
		{
		}
		public int Price { get; set; }
		public string Name { get; set; }
		public int Promo { get; set; }
		public string Period { get; set; }
	}
}

