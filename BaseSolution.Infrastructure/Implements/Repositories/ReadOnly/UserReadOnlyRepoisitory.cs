using AutoMapper;
using AutoMapper.QueryableExtensions;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Pagination;
using BaseSolution.Application.ValueObjects.Response;
using BaseSolution.Domain.Entities;
using BaseSolution.Infrastructure.Database.AppDbContext;
using BaseSolution.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.Implements.Repositories.ReadOnly
{
	public class UserReadOnlyRepoisitory : IUserReadOnlyRepoisitory
	{
		private readonly IMapper mapper;
		private readonly ILocalizationService localizationService;
		private readonly DbSet<UserEntity> userEntities;

		public UserReadOnlyRepoisitory(IMapper mapper, ILocalizationService localizationService, AppReadOnlyDbContext _context)
		{
			this.mapper = mapper;
			this.localizationService = localizationService;
			this.userEntities = _context.Set<UserEntity>();
		}

		public async Task<RequestResult<UserDTO?>> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
		{
			try
			{
				var user = await userEntities.AsNoTracking().Where(x=>x.Id == id && !x.Deleted).ProjectTo<UserDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(cancellationToken);
				return RequestResult<UserDTO?>.Succeed(user);
			}
			catch {
				throw new Exception();
			}
		}

		public async Task<RequestResult<PaginationResponse<UserDTO>>> GetUserWithPagingAsync(ViewUserWithPaginationRequest request,CancellationToken cancellationToken)
		{
			try
			{
				var queryable = userEntities.AsNoTracking();
				if (String.IsNullOrWhiteSpace(request.UserName))
				{
					queryable = queryable.Where(x=>x.UserName ==  request.UserName);
				}
				var result = await queryable.PaginateAsync<UserEntity,UserDTO>(request,mapper,cancellationToken);
				return RequestResult<PaginationResponse<UserDTO>>.Succeed(new PaginationResponse<UserDTO>()
				{
					Data = result.Data,
					HasNext = result.HasNext,
					PageNumber = request.PageNumber,
					PageSize = request.PageSize
				});
			}
			catch
			{
				throw new Exception();
			}
		}
	}
}
