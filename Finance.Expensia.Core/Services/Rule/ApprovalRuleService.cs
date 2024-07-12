using AutoMapper;
using Finance.Expensia.Core.Services.Rule.Dtos;
using Finance.Expensia.Core.Services.Rule.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace Finance.Expensia.Core.Services.Rule
{
    public class ApprovalRuleService(ApplicationDbContext dbContext, IMapper mapper, ILogger<ApprovalRuleService> logger)
        : BaseService<ApprovalRuleService>(dbContext, mapper, logger)
    {
        public async Task<ResponsePaging<ApprovalRuleDto>> GetListGroupApprovalRule(PagingSearchInputBase input)
        {
            var retVal = new ResponsePaging<ApprovalRuleDto>();

            var dataApprovalRule = _dbContext.ApprovalRules
                                    .GroupBy(ar => new { ar.TransactionTypeCode, ar.MinAmount, ar.MaxAmount })
                                    .Select(g => new ApprovalRuleDto
                                    {
                                        TransactionTypeCode = g.Key.TransactionTypeCode,
                                        MinAmount = g.Key.MinAmount,
                                        MaxAmount = g.Key.MaxAmount
                                    });

            retVal.ApplyPagination(input.Page, input.PageSize, dataApprovalRule);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponsePaging<ApprovalRuleDto>> GetListApprovalRule(ListApprovalRuleInputFIlter input)
        {
            var retVal = new ResponsePaging<ApprovalRuleDto>();

            var dataApprovalRule = _dbContext.ApprovalRules
                                    .Where(d => d.TransactionTypeCode == input.TransactionTypeCode
                                                && d.MinAmount == input.MinAmount
                                                && d.MaxAmount == input.MaxAmount)
                                    .Select(x => _mapper.Map<ApprovalRuleDto>(x));

            retVal.ApplyPagination(input.Page, input.PageSize, dataApprovalRule);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponseObject<ApprovalRuleDto>> GetDetailApprovalRule(Guid id)
        {
            var dataApprovalRule = await _dbContext.ApprovalRules
                                          .FirstOrDefaultAsync(x => x.Id == id);

            if (dataApprovalRule == null)
                return await Task.FromResult(new ResponseObject<ApprovalRuleDto>("Data chart of account tidak ditemukan", ResponseCode.NotFound));

            var dataApprovalRuleDto = _mapper.Map<ApprovalRuleDto>(dataApprovalRule);
            return await Task.FromResult(new ResponseObject<ApprovalRuleDto>(responseCode: ResponseCode.Ok)
            {
                Obj = dataApprovalRuleDto,
            });
        }

        public async Task<ResponseBase> UpsertApprovalRule(UpsertApprovalRuleInput input)
        {
            if (input.Id.Equals(null))
            {
                var dataApprovalRule = _mapper.Map<DataAccess.Models.ApprovalRule>(input);
                await _dbContext.ApprovalRules.AddAsync(dataApprovalRule);
            }
            else
            {
                var dataApprovalRule = await _dbContext.ApprovalRules.FirstOrDefaultAsync(v => v.Id.Equals(input.Id));
                if (dataApprovalRule == null)
                    return new ResponseBase("Data approval rule tidak ditemukan", ResponseCode.NotFound);

                _mapper.Map(input, dataApprovalRule);
                _dbContext.Update(dataApprovalRule);
            }

            await _dbContext.SaveChangesAsync();
            return new ResponseBase($"Data approval rule berhasil {(input.Id.Equals(null) ? "dibuat" : "diedit")}", ResponseCode.Ok);
        }

        public async Task<ResponseBase> DeleteApprovalRule(Guid id)
        {
            var dataApprovalRule = await _dbContext.ApprovalRules.FirstOrDefaultAsync(v => v.Id.Equals(id));
            if (dataApprovalRule == null)
                return new ResponseBase("Data approval rule tidak ditemukan", ResponseCode.NotFound);

            dataApprovalRule.RowStatus = 1;

            _dbContext.Update(dataApprovalRule);
            await _dbContext.SaveChangesAsync();

            return new ResponseBase("Data approval rule berasil dihapus", ResponseCode.Ok);
        }
    }
}
