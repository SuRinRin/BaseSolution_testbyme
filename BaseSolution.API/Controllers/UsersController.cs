using AutoMapper;
using BaseSolution.Application.DataTransferObjects.User;
using BaseSolution.Application.Interfaces.Repositories.ReadOnly;
using BaseSolution.Application.Interfaces.Repositories.ReadWrite;
using BaseSolution.Application.Interfaces.Services;
using BaseSolution.Infrastructure.ViewModels.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BaseSolution.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserReadOnlyRepoisitory _userOnly;
		private readonly IUserReadWriteRepoisitory _userWrite;
		private readonly ILocalizationService _localizationService;
		private readonly IMapper _mapper;

		public UsersController(IUserReadOnlyRepoisitory userOnly, IUserReadWriteRepoisitory userWrite, ILocalizationService localizationService, IMapper mapper)
		{
			this._userOnly = userOnly;
			this._userWrite = userWrite;
			this._localizationService = localizationService;
			this._mapper = mapper;
		}
		[HttpPost]
		public async Task<IActionResult> Post(UserCreateRequest request, CancellationToken cancellationToken)
		{
			UserCreateViewModel vm = new(_userWrite,_localizationService,_userOnly,_mapper);
			await vm.HandleAsync(request,cancellationToken);
			return Ok(vm);
		}
	}
}
