using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class CompanyService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CompanyService> logger)
        : BaseService<CompanyService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<CompanyDto>>> RetrieveCompanyDatas()
        {
            var dataCompanies = await _dbContext.Companies
                                                .OrderBy(d => d.CompanyName)
                                                .Select(d => _mapper.Map<CompanyDto>(d))
                                                .ToListAsync();

            return new ResponseObject<List<CompanyDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataCompanies
            };
        }
    }
}
