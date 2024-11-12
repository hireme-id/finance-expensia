using AutoMapper;
using Finance.Expensia.Core.Services.Employee.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.Employee
{
    public class EmployeeService(ApplicationDbContext dbContext, IMapper mapper, ILogger<EmployeeService> logger)
        : BaseService<EmployeeService>(dbContext, mapper, logger)
    {
        public async Task<ResponsePaging<EmployeeDto>> RetrievePagingEmployee(PagingSearchInputBase input)
        {
            var retVal = new ResponsePaging<EmployeeDto>();

            var employeeDataDtos = _dbContext.Employees.Where(d => EF.Functions.Like(d.EmployeeNo, $"%{input.SearchKey}%") || EF.Functions.Like(d.EmployeeName, $"%{input.SearchKey}%"))
                                                       .OrderBy(d => d.Modified ?? d.Created)
                                                       .Select(d => _mapper.Map<EmployeeDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, employeeDataDtos);

            return await Task.FromResult(retVal);
        }
    }
}
