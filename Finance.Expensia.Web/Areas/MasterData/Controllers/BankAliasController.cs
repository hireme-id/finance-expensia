using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Areas.MasterData.Validators;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Finance.Expensia.Shared.Constants.PermissionConstants.MasterData;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
	public class BankAliasController(BankAliasService bankAliasService, CurrentUserAccessor currentUserAccessor) : BaseController
	{
		private readonly BankAliasService _bankAliasService = bankAliasService;
		private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

		[AllowAnonymous]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost("ddlbankaliases")]
		[AppAuthorize(BankAlias.BankAliasView)]
		public async Task<ResponseObject<List<BankAliasDto>>> RetrieveBankAlias(Guid? companyId)
		{
			return await _bankAliasService.RetrieveBankAlias(companyId);
		}

		[HttpPost("ddlfrombankaliases")]
		[AppAuthorize(BankAlias.BankAliasView)]
		public async Task<ResponseObject<List<BankAliasDto>>> RetrieveFromBankAlias(Guid? companyId)
		{
			return await _bankAliasService.RetrieveBankAlias(companyId, 0);
		}

		[HttpPost("bankalias/list")]
		[AppAuthorize(BankAlias.BankAliasView)]
		public async Task<ResponsePaging<BankAliasDto>> GetListBankAlias([FromBody] PagingSearchInputBase input)
		{
			return await _bankAliasService.GetListBankAlias(input, _currentUserAccessor.Id);
		}

		[AppAuthorize(BankAlias.BankAliasView)]
		[HttpPost("bankalias/detail")]
		public async Task<ResponseObject<BankAliasDto>> GetDetailBankAlias([FromQuery] Guid bankAliasId)
		{
			return await _bankAliasService.GetDetailBankAlias(bankAliasId);
		}

		[Mutation]
		[AppAuthorize(BankAlias.BankAliasUpsert)]
		[HttpPost("bankalias/upsert")]
		public async Task<ResponseBase> UpsertBankAlias([FromBody] UpsertBankAliasInput input)
		{
			UpsertBankAliasInputValidator validator = new();
			if (!validator.Validate(input).IsValid)
				return new ResponseBase("Mohon lengkapi informasi mandatory", ResponseCode.BadRequest);

			return await _bankAliasService.UpsertBankAlias(input);
		}

		[Mutation]
		[AppAuthorize(BankAlias.BankAliasDelete)]
		[HttpPost("bankalias/delete")]
		public async Task<ResponseBase> DeleteBankAlias([FromQuery] Guid bankAliasId)
		{
			return await _bankAliasService.DeleteBankAlias(bankAliasId);
		}
	}
}
