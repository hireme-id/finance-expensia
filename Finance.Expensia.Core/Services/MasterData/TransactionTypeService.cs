using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class TransactionTypeService(ApplicationDbContext dbContext, IMapper mapper, ILogger<TransactionTypeService> logger)
        : BaseService<TransactionTypeService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<TransactionTypeDto>>> RetrieveTransactionTypeDatas()
        {
            var dataTransactionTypes = await _dbContext.TransactionTypes
                                                .OrderBy(d => d.TransactionTypeCode)
                                                .Select(d => _mapper.Map<TransactionTypeDto>(d))
                                                .ToListAsync();

            return new ResponseObject<List<TransactionTypeDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataTransactionTypes
            };
        }
    }
}
