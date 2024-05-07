using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class CoaService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CoaService> logger)
        : BaseService<CoaService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<CoaDto>>> RetrieveCoa(Guid companyId)
        {
            var dataCoas = await _dbContext.ChartOfAccounts
                                           .Where(d => d.CompanyId.Equals(companyId) && d.IsActive)
                                           .OrderBy(d => d.AccountCode)
                                           .Select(d => _mapper.Map<CoaDto>(d))
                                           .ToListAsync();

            return new ResponseObject<List<CoaDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataCoas
            };
        }
    }
}
