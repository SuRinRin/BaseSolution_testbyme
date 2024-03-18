using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Application.Interfaces.Repositories.ReadWrite
{
	public interface IUserReadWriteRepoisitory
	{
		Task<RequestResult<Guid>> AddUserAsync(UserEntity user,CancellationToken cancellationToken);
		Task<RequestResult<int>> UpdateUserAsync(UserEntity user, CancellationToken cancellationToken);

		Task<RequestResult<int>> DeleteUserAsync(Guid id,CancellationToken cancellationToken);
	}
}
