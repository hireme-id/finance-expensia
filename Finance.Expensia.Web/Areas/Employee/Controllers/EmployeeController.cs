using Finance.Expensia.Core.Services.Employee;
using Finance.Expensia.Core.Services.Employee.Dtos;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public class EmployeeController(EmployeeService employeeService) : BaseController
    {
        private readonly EmployeeService _employeeService = employeeService;

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost("employee/paging")]
        public async Task<ResponsePaging<EmployeeDto>> RetrievePagingEmployee([FromBody] PagingSearchInputBase input) => await _employeeService.RetrievePagingEmployee(input);
	}
}
