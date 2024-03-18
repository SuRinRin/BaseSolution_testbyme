using BaseSolution.Application.ValueObjects.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.DataTransferObjects.User
{
	public class ViewUserWithPaginationRequest : PaginationRequest
	{
		public string? UserName { get; set; }
	}
}
