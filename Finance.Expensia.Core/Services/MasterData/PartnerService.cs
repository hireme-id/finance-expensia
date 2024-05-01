using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class PartnerService(ApplicationDbContext dbContext, IMapper mapper, ILogger<PartnerService> logger)
        : BaseService<PartnerService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<PartnerDto>>> RetrievePartner(Guid companyId)
        {
            var dataPartners = await _dbContext.Partners
                                               .OrderBy(d => d.PartnerName)
                                               .Select(d => _mapper.Map<PartnerDto>(d))
                                               .ToListAsync();

            return new ResponseObject<List<PartnerDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataPartners
            };
        }
    }
}
