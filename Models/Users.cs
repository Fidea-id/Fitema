using System;
namespace Fitema.Models
{
	public class Users : BaseModel
	{
		public Users()
		{
		}
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public int OrgId { get; set; }
	}
}

