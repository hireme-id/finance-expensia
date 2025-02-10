using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Finance.Expensia.Shared.Constants.PermissionConstants.MasterData;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
	public class RecruiterController(RecruiterService recruiterService) : BaseController
	{
		private readonly RecruiterService _recruiterService = recruiterService;

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost("recruiter/list")]
		[AppAuthorize(Recruiter.RecruiterView)]
		public async Task<ResponsePaging<RecruiterDto>> GetListRecruiter([FromBody] PagingSearchInputBase input)
		{
			return await _recruiterService.GetListRecruiter(input);
		}

		[AppAuthorize(Recruiter.RecruiterView)]
		[HttpPost("recruiter/detail")]
		public async Task<ResponseObject<RecruiterDto>> GetDetailRecruiter([FromQuery] Guid recruiterId)
		{
			return await _recruiterService.GetDetailRecruiter(recruiterId);
		}

		[Mutation]
		[AppAuthorize(Recruiter.RecruiterUpsert)]
		[HttpPost("recruiter/upsert")]
		public async Task<ResponseBase> UpsertRecruiter([FromBody] UpsertRecruiterInput input)
		{
			return await _recruiterService.UpsertRecruiter(input);
		}

		[Mutation]
		[AppAuthorize(Recruiter.RecruiterUpsert)]
		[HttpPost("recruiter/delete")]
		public async Task<ResponseBase> DeleteRecruiter([FromQuery] Guid recruiterId)
		{
			return await _recruiterService.DeleteRecruiter(recruiterId);
		}
	}
}
