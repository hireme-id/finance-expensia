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
        public async Task<ResponseObject<List<CompanyDto>>> RetrieveCompanyDatas(Guid userId)
        {
            var dataCompanies = await _dbContext.Companies
                                                .Include(c => c.UserCompanies.Where(d => d.UserId.Equals(userId)))
                                                .Where(d => d.UserCompanies.Count > 0)
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
