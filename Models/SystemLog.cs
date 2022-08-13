using System;
namespace Fitema.Models
{
	public class SystemLog : BaseModel
	{
		public SystemLog()
		{
		}
		public string Type { get; set; }
		public string Status { get; set; }
		public string Detail { get; set; }
	}
}

