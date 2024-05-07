using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class CostCenterService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CostCenterService> logger)
        : BaseService<CostCenterService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<CostCenterDto>>> RetrieveCostCenter(Guid companyId)
        {
            var dataCostCenters = await _dbContext.CostCenters
                                                  .Where(d => d.CompanyId.Equals(companyId))
                                                  .OrderBy(d => d.CostCenterCode)
                                                  .Select(d => _mapper.Map<CostCenterDto>(d))
                                                  .ToListAsync();

            return new ResponseObject<List<CostCenterDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataCostCenters
			};
        }
    }
}
