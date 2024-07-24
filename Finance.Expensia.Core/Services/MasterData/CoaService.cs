using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

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

        public async Task<ResponsePaging<CoaDto>> GetListCoa(PagingSearchInputBase input, CurrentUserAccessor currentUserAccessor)
        {
            var retVal = new ResponsePaging<CoaDto>();

			var userCompanyIds = await _dbContext.UserCompanies.Where(d => d.UserId.Equals(currentUserAccessor.Id)).Select(d => d.CompanyId).ToListAsync();
			var dataCoa = _dbContext.ChartOfAccounts
                                            .Include(ca => ca.Company)
											.Where(d => userCompanyIds.Contains(d.CompanyId))
											.Where(d =>
                                                (d.Company != null && EF.Functions.Like(d.Company.CompanyName, $"%{input.SearchKey}%"))
                                                || EF.Functions.Like(d.AccountCode, $"%{input.SearchKey}%")
                                                || EF.Functions.Like(d.AccountName, $"%{input.SearchKey}%"))
                                            .OrderByDescending(d => d.Modified ?? d.Created)
                                            .Select(d => _mapper.Map<CoaDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, dataCoa);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponseObject<CoaDto>> GetDetailCoa(Guid coaId)
        {
            var dataCoa = await _dbContext.ChartOfAccounts
                                          .Include(ca => ca.Company)
                                          .FirstOrDefaultAsync(x => x.Id == coaId);

            if (dataCoa == null)
                return await Task.FromResult(new ResponseObject<CoaDto>("Data chart of account tidak ditemukan", ResponseCode.NotFound));

            var dataCoaDto = _mapper.Map<CoaDto>(dataCoa);
            return await Task.FromResult(new ResponseObject<CoaDto>(responseCode: ResponseCode.Ok)
            {
                Obj = dataCoaDto,
            });
        }

        public async Task<ResponseBase> UpsertCoa(UpsertCoaInput input)
        {
            if (input.Id.Equals(null))
            {
                var dataCoa = _mapper.Map<DataAccess.Models.ChartOfAccount>(input);
                await _dbContext.ChartOfAccounts.AddAsync(dataCoa);
            }
            else
            {
                var dataCoa = await _dbContext.ChartOfAccounts.FirstOrDefaultAsync(v => v.Id.Equals(input.Id));
                if (dataCoa == null)
                    return new ResponseBase("Data chart of account tidak ditemukan", ResponseCode.NotFound);

                _mapper.Map(input, dataCoa);
                _dbContext.Update(dataCoa);
            }

            await _dbContext.SaveChangesAsync();
            return new ResponseBase($"Data chart of account berhasil {(input.Id.Equals(null) ? "dibuat" : "diedit")}", ResponseCode.Ok);
        }

        public async Task<ResponseBase> DeleteCoa(Guid coaId)
        {
            var dataCoa = await _dbContext.ChartOfAccounts.FirstOrDefaultAsync(v => v.Id.Equals(coaId));
            if (dataCoa == null)
                return new ResponseBase("Data chart of account tidak ditemukan", ResponseCode.NotFound);

            dataCoa.RowStatus = 1;

            _dbContext.Update(dataCoa);
            await _dbContext.SaveChangesAsync();

            return new ResponseBase("Data chart of account berasil dihapus", ResponseCode.Ok);
        }
    }
}
