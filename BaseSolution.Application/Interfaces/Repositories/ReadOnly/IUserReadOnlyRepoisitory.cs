using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadOnly
{
	public interface IUserReadOnlyRepoisitory
	{
		Task<RequestResult<UserDTO?>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken);

		Task<RequestResult<PaginationResponse<UserDTO>>> GetUserWithPagingAsync(ViewUserWithPaginationRequest request,CancellationToken cancellationToken);
	}
}
