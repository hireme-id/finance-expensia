using Finance.Expensia.Core.Services.Employee;
using Finance.Expensia.Core.Services.Employee.Dtos;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public partial class EmployeeController(EmployeeService employeeService) : BaseController
    {
        private readonly EmployeeService _employeeService = employeeService;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AppAuthorize(PermissionConstants.Employee.EmployeeView)]
        [HttpPost("employee/paging")]
        public async Task<ResponsePaging<EmployeeDto>> RetrievePagingEmployee([FromBody] PagingSearchInputBase input) => await _employeeService.RetrievePagingEmployee(input);

        [AppAuthorize(PermissionConstants.Employee.EmployeeView)]
        [HttpPost("employee/list")]
        public async Task<ResponseObject<List<EmployeeDto>>> RetrieveListEmployee([FromBody] SearchInputBase input) => await _employeeService.RetrieveListEmployee(input);

        [AppAuthorize(PermissionConstants.Employee.EmployeeView)]
        [HttpPost("employee/detail")]
        public async Task<ResponseObject<EmployeeDto>> RetrieveEmployee([FromQuery] Guid employeeId) => await _employeeService.RetrieveEmployee(employeeId);
	}
}
