using Finance.Expensia.Core.Services.Employee;
using Finance.Expensia.Core.Services.Employee.Dtos;
using Finance.Expensia.Core.Services.Employee.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public class EmployeeCostController(EmployeeService employeeService) : BaseController
    {
        private readonly EmployeeService _employeeService = employeeService;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Edit()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Detail()
        {
            return View();
        }

        [AppAuthorize(PermissionConstants.Employee.EmployeeCost.EmployeeCostView)]
        [HttpPost("employeecost/paging")]
        public async Task<ResponsePaging<EmployeeCostDto>> RetrievePagingEmployeeCost([FromBody] PagingSearchInputBase input) => await _employeeService.RetrievePagingEmployeeCost(input);

        [AppAuthorize(PermissionConstants.Employee.EmployeeCost.EmployeeCostCreate)]
        [HttpPost("employeecost/component/initial")]
		public async Task<ResponseObject<List<EmployeeCostComponentDto>>> RetrieveInitialEmployeeCostComponents() => await _employeeService.RetrieveInitialEmployeeCostComponents();

        [AppAuthorize([PermissionConstants.Employee.EmployeeCost.EmployeeCostCreate, PermissionConstants.Employee.EmployeeCost.EmployeeCostUpdate])]
        [HttpPost("employeecost/component/calculate")]
		public async Task<ResponseObject<List<EmployeeCostComponentDto>>> CalculateEmployeeCost([FromBody] CalculateEmployeeCostInput input) => await _employeeService.CalculateEmployeeCost(input);

        [AppAuthorize(PermissionConstants.Employee.EmployeeCost.EmployeeCostView)]
        [HttpPost("employeecost/detail")]
        public async Task<ResponseObject<EmployeeCostDto>> RetrieveEmployeeCost([FromQuery] Guid employeeCostId) => await _employeeService.RetrieveEmployeeCost(employeeCostId);

        [AppAuthorize(PermissionConstants.Employee.EmployeeCost.EmployeeCostCreate)]
        [Mutation]
        [HttpPost("employeecost/create")]
        public async Task<ResponseBase> CreateEmployeeCost([FromBody] EmployeeCostInput input) => await _employeeService.CreateEmployeeCost(input);

        [AppAuthorize(PermissionConstants.Employee.EmployeeCost.EmployeeCostUpdate)]
        [Mutation]
		[HttpPost("employeecost/update")]
		public async Task<ResponseBase> UpdateEmployeeCost([FromBody] EmployeeCostInput input) => await _employeeService.UpdateEmployeeCost(input);

        [AppAuthorize(PermissionConstants.Employee.EmployeeCost.EmployeeCostDelete)]
        [Mutation]
        [HttpPost("employeecost/delete")]
        public async Task<ResponseBase> DeleteEmployeeCost([FromQuery] Guid employeeCostId) => await _employeeService.DeleteEmployeeCost(employeeCostId);
	}
}
