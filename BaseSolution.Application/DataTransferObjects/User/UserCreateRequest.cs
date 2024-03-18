using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.User
{
	public class UserCreateRequest
	{
		public string UserName { get; set; }
		public string Password { get; set; }

		public string Email { get; set; }
	}
}
