using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class BankAliasService(ApplicationDbContext dbContext, IMapper mapper, ILogger<BankAliasService> logger)
        : BaseService<BankAliasService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<BankAliasDto>>> RetrieveBankAlias(Guid? companyId)
        {
            var dataBankAliases = await _dbContext.BankAliases
                                                  .Where(d => companyId == null || d.CompanyId.Equals(companyId.Value))
                                                  .OrderBy(d => d.AliasName)
                                                  .Select(d => _mapper.Map<BankAliasDto>(d))
                                                  .ToListAsync();

            return new ResponseObject<List<BankAliasDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataBankAliases
            };
        }
    }
}
