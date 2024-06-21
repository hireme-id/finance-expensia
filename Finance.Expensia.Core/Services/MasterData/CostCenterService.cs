using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
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
                                                  .Include(cc => cc.Company)
                                                  .Where(d => d.CompanyId.Equals(companyId))
                                                  .OrderBy(d => d.CostCenterCode)
                                                  .Select(d => _mapper.Map<CostCenterDto>(d))
                                                  .ToListAsync();

            return new ResponseObject<List<CostCenterDto>>(responseCode: ResponseCode.Ok)
            {
                Obj = dataCostCenters
			};
        }

		public async Task<ResponsePaging<CostCenterDto>> GetListPartner(PagingSearchInputBase input, CurrentUserAccessor currentUserAccessor)
		{
			var retVal = new ResponsePaging<CostCenterDto>();

            var userCompanyIds = await _dbContext.UserCompanies.Where(d => d.UserId.Equals(currentUserAccessor.Id)).Select(d => d.CompanyId).ToListAsync();
            var dataCostCenters = _dbContext.CostCenters
                                            .Include(cc => cc.Company)
										    .OrderByDescending(d => d.Modified ?? d.Created)
                                            .Where(d => userCompanyIds.Contains(d.CompanyId))
                                            .Where(d =>
											    EF.Functions.Like(d.Company.CompanyName, $"%{input.SearchKey}%")
											    || EF.Functions.Like(d.CostCenterCode, $"%{input.SearchKey}%")
											    || EF.Functions.Like(d.CostCenterName, $"%{input.SearchKey}%"))
										    .Select(d => _mapper.Map<CostCenterDto>(d));

			retVal.ApplyPagination(input.Page, input.PageSize, dataCostCenters);

			return await Task.FromResult(retVal);
		}

        public async Task<ResponseObject<CostCenterDto>> GetDetailCostCenter(Guid costCenterId)
        {
            var dataCostCenter = await _dbContext.CostCenters
                                                 .Include(d => d.Company)
                                                 .FirstOrDefaultAsync(x => x.Id == costCenterId);

            if (dataCostCenter == null)
                return new ResponseObject<CostCenterDto>("Data customer tidak ditemukan", ResponseCode.NotFound);

            return new ResponseObject<CostCenterDto>(responseCode: ResponseCode.Ok)
            {
                Obj = _mapper.Map<CostCenterDto>(dataCostCenter),
            };
        }

        public async Task<ResponseBase> UpsertCostCenter(UpsertCostCenterInput input)
        {
            if (input.Id.Equals(null))
            {
                var dataCostCenter = _mapper.Map<CostCenter>(input);
                await _dbContext.AddAsync(dataCostCenter);
            }
            else
            {
                var dataCostCenter = await _dbContext.CostCenters.FirstOrDefaultAsync(v => v.Id.Equals(input.Id));
                if (dataCostCenter == null)
                    return new ResponseBase("Data customer tidak ditemukan", ResponseCode.NotFound);

                _mapper.Map(input, dataCostCenter);
                _dbContext.Update(dataCostCenter);
            }

            await _dbContext.SaveChangesAsync();
            return new ResponseBase($"Data customer berhasil {(input.Id.Equals(null) ? "dibuat" : "diedit")}", ResponseCode.Ok);
        }

        public async Task<ResponseBase> DeleteCostCenter(Guid costCenterId)
        {
            var dataCostCenter = await _dbContext.CostCenters.FirstOrDefaultAsync(v => v.Id.Equals(costCenterId));
            if (dataCostCenter == null)
                return new ResponseBase("Data customer tidak ditemukan", ResponseCode.NotFound);

            dataCostCenter.RowStatus = 1;

            _dbContext.Update(dataCostCenter);
            await _dbContext.SaveChangesAsync();

            return new ResponseBase("Data customer berasil dihapus", ResponseCode.Ok);
        }
    }
}
