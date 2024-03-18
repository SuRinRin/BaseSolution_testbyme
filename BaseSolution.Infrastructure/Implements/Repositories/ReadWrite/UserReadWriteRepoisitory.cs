using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Shared;
namespace BaseSolution.Infrastructure.Implements.Repositories.ReadWrite
{
	public class UserReadWriteRepoisitory : IUserReadWriteRepoisitory
	{
		private readonly ILocalizationService _localizationService;
		private readonly AppReadWriteDbContext _context;


		public UserReadWriteRepoisitory(ILocalizationService localizationService, AppReadWriteDbContext context)
		{
			_localizationService = localizationService;
			_context = context;
		}

		public async Task<RequestResult<Guid>> AddUserAsync(UserEntity user, CancellationToken cancellationToken)
		{
			try
			{
				user.CreatedTime = DateTimeOffset.UtcNow;
				user.Status = Domain.Enums.UserStatus.Active;
				user.Password = Hash.EncryptPassword(user.Password);
				await _context.Users.AddAsync(user);
				await _context.SaveChangesAsync(cancellationToken);
				return RequestResult<Guid>.Succeed(user.Id);
			}
			catch (Exception ex)
			{
				return RequestResult<Guid>.Fail(_localizationService["Unable to create example"], new[]
			  {
					new ErrorItem
					{
						Error = ex.Message,
						FieldName = LocalizationString.Common.FailedToCreate + "example"
					}
				});
			}
		}

		public Task<RequestResult<int>> DeleteUserAsync(Guid id, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}

		public Task<RequestResult<int>> UpdateUserAsync(UserEntity user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
