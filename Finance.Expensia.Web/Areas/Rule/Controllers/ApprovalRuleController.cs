using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.AspNetCore.Mvc;
using Finance.Expensia.Core.Services.Rule;
using Finance.Expensia.Core.Services.Rule.Dtos;
using Microsoft.AspNetCore.Authorization;
using Finance.Expensia.Core.Services.Rule.Inputs;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Web.Areas.Rule.Validators;

namespace Finance.Expensia.Web.Areas.Rule.Controllers
{
    public class ApprovalRuleController(ApprovalRuleService approvalRuleService) : Controller
    {
        private readonly ApprovalRuleService _approvalRuleService = approvalRuleService;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Detail()
        {
            return View();
        }

        [HttpPost("approvalRule/listgroup")]
        [AppAuthorize(PermissionConstants.Rule.ApprovalRuleView)]
        public async Task<ResponsePaging<ApprovalRuleDto>> GetListGroupApprovalRule([FromBody] PagingSearchInputBase input)
        {
            return await _approvalRuleService.GetListGroupApprovalRule(input);
        }

        [HttpPost("approvalRule/list")]
        [AppAuthorize(PermissionConstants.Rule.ApprovalRuleView)]
        public async Task<ResponsePaging<ApprovalRuleDto>> GetListApprovalRule([FromBody] ListApprovalRuleInputFIlter input)
        {
            return await _approvalRuleService.GetListApprovalRule(input);
        }

        [AppAuthorize(PermissionConstants.Rule.ApprovalRuleView)]
        [HttpPost("approvalRule/detail")]
        public async Task<ResponseObject<ApprovalRuleDto>> GetDetailApprovalRule([FromQuery] Guid id)
        {
            return await _approvalRuleService.GetDetailApprovalRule(id);
        }

        [Mutation]
        [AppAuthorize(PermissionConstants.Rule.ApprovalRuleUpsert)]
        [HttpPost("approvalRule/upsert")]
        public async Task<ResponseBase> UpsertApprovalRule([FromBody] UpsertApprovalRuleInput input)
        {
            UpsertApprovalRuleValidator validator = new();
            if (!validator.Validate(input).IsValid)
                return new ResponseBase("Mohon lengkapi informasi mandatory", ResponseCode.BadRequest);

            return await _approvalRuleService.UpsertApprovalRule(input);
        }

        [Mutation]
        [AppAuthorize(PermissionConstants.Rule.ApprovalRuleDelete)]
        [HttpPost("approvalRule/delete")]
        public async Task<ResponseBase> DeleteApprovalRule([FromQuery] Guid id)
        {
            return await _approvalRuleService.DeleteApprovalRule(id);
        }
    }
}
