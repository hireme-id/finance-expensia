using AutoMapper;
using Finance.Expensia.Core.Services.DocumentNumbering;
using Finance.Expensia.Core.Services.Employee.Dtos;
using Finance.Expensia.Core.Services.Employee.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.Employee
{
    public partial class EmployeeService(
        ApplicationDbContext dbContext, 
        IMapper mapper, 
        ILogger<EmployeeService> logger, 
        DocumentNumberingService documentNumberingService
    ) : BaseService<EmployeeService>(dbContext, mapper, logger)
    {
        private DocumentNumberingService _documentNumberingService = documentNumberingService;

        public async Task<ResponsePaging<EmployeeDto>> RetrievePagingEmployee(PagingSearchInputBase input)
        {
            var retVal = new ResponsePaging<EmployeeDto>();

            var employeeDataDtos = _dbContext.Employees.Where(d => EF.Functions.Like(d.EmployeeNo, $"%{input.SearchKey}%") || EF.Functions.Like(d.EmployeeName, $"%{input.SearchKey}%"))
                                                       .OrderBy(d => d.Modified ?? d.Created)
                                                       .Select(d => _mapper.Map<EmployeeDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, employeeDataDtos);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponseObject<List<EmployeeDto>>> RetrieveListEmployee(SearchInputBase input)
        {
			var employeeDtos = await _dbContext.Employees
											   .Where(d =>
												    EF.Functions.Like(d.EmployeeNo, $"%{input.SearchKey}%")
												    || EF.Functions.Like(d.EmployeeName, $"%{input.SearchKey}%")
											   )
											   .OrderByDescending(d => d.Modified ?? d.Created)
											   .Select(d => _mapper.Map<EmployeeDto>(d))
											   .ToListAsync();

			return new ResponseObject<List<EmployeeDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = employeeDtos
            };
        }

        public async Task<DataAccess.Models.Employee> CreateEmployee(EmployeeInput input)
        {
            var existingEmployeeData = await _dbContext.Employees.FirstOrDefaultAsync(d => d.EmployeeNo == input.EmployeeNo);
            if (existingEmployeeData != null)
                return existingEmployeeData;

            var employeeData = _mapper.Map<DataAccess.Models.Employee>(input);

            await _dbContext.AddAsync(employeeData);
            await _dbContext.SaveChangesAsync();

            return employeeData;
        }

        public async Task<ResponseObject<EmployeeDto>> RetrieveEmployee(Guid employeeId)
        {
            var employeeData = await _dbContext.Employees.Include(e => e.EmployeeCosts).FirstOrDefaultAsync(d => d.Id == employeeId);
            if (employeeData == null)
                return new("Data employee tidak ditemukan", ResponseCode.NotFound);

            return new(responseCode: ResponseCode.Ok)
            {
                Obj = _mapper.Map<EmployeeDto>(employeeData)
            };
        }
    }
}
