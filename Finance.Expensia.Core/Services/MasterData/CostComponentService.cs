using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class CostComponentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<CostComponentService> logger)
        : BaseService<CostComponentService>(dbContext, mapper, logger)
    {
        public async Task<ResponsePaging<CostComponentDto>> RetrievePagingCostComponent(PagingSearchInputBase input)
        {
            var retVal = new ResponsePaging<CostComponentDto>();

            var costComponentTypes = EnumHelper.FilterEnumList<CostComponentType>(input.SearchKey);
            var costComponentCategories = EnumHelper.FilterEnumList<CostComponentCategory>(input.SearchKey);

            var costComponentDtoDatas = _dbContext.CostComponents
                                                  .Where(d =>
                                                    EF.Functions.Like(d.CostComponentNo.ToString(), $"%{input.SearchKey}%")
                                                    || EF.Functions.Like(d.CostComponentName, $"%{input.SearchKey}%")
                                                    || costComponentTypes.Contains(d.CostComponentType)
                                                    || costComponentCategories.Contains(d.CostComponentCategory)
                                                  )
                                                  .OrderBy(d => d.CostComponentNo)
                                                  .Select(d => _mapper.Map<CostComponentDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, costComponentDtoDatas);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponseObject<CostComponentDto>> RetrieveCostComponentById(Guid costComponentId)
        {
            var costComponentData = await _dbContext.CostComponents
                                                    .Include(cc => cc.CostComponentCompanies)
                                                        .ThenInclude(ccc => ccc.Company)
                                                    .FirstOrDefaultAsync(d => d.Id == costComponentId);

            if (costComponentData == null)
                return new ResponseObject<CostComponentDto>("Data cost component tidak ditemukan", ResponseCode.NotFound);


            return new ResponseObject<CostComponentDto>(responseCode: ResponseCode.Ok)
            {
                Obj = _mapper.Map<CostComponentDto>(costComponentData)
            };
        }

        public async Task<ResponseBase> CreateCostComponent(UpsertCostComponentInput input)
        {
            if (input.CostComponentId.HasValue)
                return new ResponseBase("Terdapat kesalahan pada sistem, silahkan hubungi administrator", ResponseCode.Error);

            var costComponentData = _mapper.Map<CostComponent>(input);
            costComponentData.CostComponentCompanies = input.CostComponentCompanies
                                                            .Select(d => _mapper.Map<CostComponentCompany>(
                                                                d,
                                                                opts => opts.Items["IsCreate"] = true)
                                                            )
                                                            .ToList();

            await _dbContext.AddAsync(costComponentData);
            await _dbContext.SaveChangesAsync();

            return new ResponseBase($"Setup budget untuk {costComponentData.CostComponentName} telah disimpan", ResponseCode.Ok);
        }

        public async Task<ResponseBase> UpdateCostComponent(UpsertCostComponentInput input)
        {
            if (!input.CostComponentId.HasValue)
                return new ResponseBase("Terdapat kesalahan pada sistem, silahkan hubungi administrator", ResponseCode.Error);

            var costComponentData = await _dbContext.CostComponents.Include(bc => bc.CostComponentCompanies).FirstOrDefaultAsync(d => d.Id == input.CostComponentId.Value);
            if (costComponentData == null)
                return new ResponseBase("Data setup budget tidak ditemukan", ResponseCode.NotFound);

            _mapper.Map(input, costComponentData);
            foreach (var iCostComponentCompany in input.CostComponentCompanies)
            {
                if (costComponentData.CostComponentCompanies.Any(d => d.Id == iCostComponentCompany.CostComponentCompanyId))
                {
                    _mapper.Map(iCostComponentCompany, costComponentData.CostComponentCompanies.First(d => d.Id == iCostComponentCompany.CostComponentCompanyId));
                }
                else
                {
                    var newBudgetComponentCompanyData = _mapper.Map<CostComponentCompany>(iCostComponentCompany, opts => opts.Items["IsCreate"] = true);
                    newBudgetComponentCompanyData.CostComponentId = costComponentData.Id;

                    await _dbContext.AddAsync(newBudgetComponentCompanyData);
                }
            }

            _dbContext.Update(costComponentData);
            await _dbContext.SaveChangesAsync();

            return new ResponseBase($"Setup budget untuk {costComponentData.CostComponentName} telah disimpan", ResponseCode.Ok);
        }
    }
}
