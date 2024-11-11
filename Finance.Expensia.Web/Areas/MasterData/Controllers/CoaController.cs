using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Areas.MasterData.Validators;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public class CoaController(CoaService coaService, CurrentUserAccessor currentUserAccessor) : BaseController
    {
        private readonly CoaService _coaService = coaService;
        private readonly CurrentUserAccessor _currentUserAccessor = currentUserAccessor;

		[AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("ddlallcoa")]
        [AppAuthorize(PermissionConstants.MasterData.Coa.CoaView)]
        public async Task<ResponseObject<List<CoaDto>>> RetrieveAllCoa()
        {
            return await _coaService.RetrieveAllCoa();
        }

        [HttpPost("ddlcoa")]
        [AppAuthorize(PermissionConstants.MasterData.Coa.CoaView)]
        public async Task<ResponseObject<List<CoaDto>>> RetrieveCoa(Guid companyId)
        {
            return await _coaService.RetrieveCoa(companyId);
        }

        [HttpPost("coa/list")]
        [AppAuthorize(PermissionConstants.MasterData.Coa.CoaView)]
        public async Task<ResponsePaging<CoaDto>> GetListCoa([FromBody] PagingSearchInputBase input)
        {
            return await _coaService.GetListCoa(input, _currentUserAccessor);
        }
        [AppAuthorize(PermissionConstants.MasterData.Coa.CoaView)]
        [HttpPost("coa/detail")]
        public async Task<ResponseObject<CoaDto>> GetDetailCoa([FromQuery] Guid coaId)
        {
            return await _coaService.GetDetailCoa(coaId);
        }

        [Mutation]
        [AppAuthorize(PermissionConstants.MasterData.Coa.CoaUpsert)]
        [HttpPost("coa/upsert")]
        public async Task<ResponseBase> UpsertCoa([FromBody] UpsertCoaInput input)
        {
            UpsertCoaInputValidator validator = new();
            if (!validator.Validate(input).IsValid)
                return new ResponseBase("Mohon lengkapi informasi mandatory", ResponseCode.BadRequest);

            return await _coaService.UpsertCoa(input);
        }

        [Mutation]
        [AppAuthorize(PermissionConstants.MasterData.Coa.CoaDelete)]
        [HttpPost("coa/delete")]
        public async Task<ResponseBase> DeleteCoa([FromQuery] Guid coaId)
        {
            return await _coaService.DeleteCoa(coaId);
        }

    }
}
