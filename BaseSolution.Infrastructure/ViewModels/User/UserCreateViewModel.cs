using AutoMapper;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Application.ValueObjects.Common;
using BaseSolution.Application.ViewModels;
using BaseSolution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseSolution.Infrastructure.ViewModels.User
{
	public class UserCreateViewModel : ViewModelBase<UserCreateRequest>
	{
		private readonly IUserReadWriteRepoisitory _userWrite;
		private readonly ILocalizationService _localizationService;
		private readonly IUserReadOnlyRepoisitory _userOnly;
		private readonly IMapper _mapper;

		public UserCreateViewModel(IUserReadWriteRepoisitory userWrite, ILocalizationService localizationService, IUserReadOnlyRepoisitory userOnly, IMapper mapper)
		{
			_userWrite = userWrite;
			_localizationService = localizationService;
			_userOnly = userOnly;
			_mapper = mapper;
		}

		public override async Task HandleAsync(UserCreateRequest request, CancellationToken cancellationToken)
		{
			try
			{
				var createResult = await _userWrite.AddUserAsync(_mapper.Map<UserEntity>(request), cancellationToken);
				if (createResult.Success)
				{
					var result = await _userOnly.GetUserByIdAsync(createResult.Data, cancellationToken);

					Data = result.Data!;
					Success = result.Success;
					ErrorItems = result.Errors;
					Message = result.Message;
					return;
				}
				Success = createResult.Success;
				ErrorItems = createResult.Errors;
				Message = createResult.Message;
			}
			catch(Exception)
			{
				Success = false;
				ErrorItems = new[]
					{
					new ErrorItem
					{
						Error = _localizationService["Error occurred while getting the User"],
						FieldName = string.Concat(LocalizationString.Common.FailedToGet, "User")
					}
				};
			}

		}
	}
}
