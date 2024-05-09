using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class PartnerService(ApplicationDbContext dbContext, IMapper mapper, ILogger<PartnerService> logger)
        : BaseService<PartnerService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<List<PartnerDto>>> RetrievePartner()
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

        public async Task<ResponsePaging<PartnerDto>> GetListPartner(PagingSearchInputBase input)
        {
            var retVal = new ResponsePaging<PartnerDto>();
            var dataPartners = _dbContext.Partners
                                         .OrderBy(d => d.PartnerName)
                                         .Where(d =>
                                            EF.Functions.Like(d.PartnerName, $"%{input.SearchKey}%")
                                            || EF.Functions.Like(d.Description, $"%{input.SearchKey}%"))
                                         .Select(d => _mapper.Map<PartnerDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, dataPartners);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponseObject<PartnerDto>> GetDetailPartner(Guid partnerId)
		{
			var dataPartners = await _dbContext.Partners
											   .FirstOrDefaultAsync(x => x.Id == partnerId);

            if (dataPartners == null)
                return await Task.FromResult(new ResponseObject<PartnerDto>("Data partner tidak ditemukan", ResponseCode.NotFound));

            var dataPartnersDto = _mapper.Map<PartnerDto>(dataPartners);
            return await Task.FromResult(new ResponseObject<PartnerDto>(responseCode: ResponseCode.Ok)
            {
                Obj = dataPartnersDto,
            });
        }

        public async Task<ResponseBase> UpsertPartner(UpsertPartnerInput input)
        {
            if (input.Id.Equals(null))
            {
                var dataPartner = _mapper.Map<DataAccess.Models.Partner>(input);
                await _dbContext.Partners.AddAsync(dataPartner);
            }
            else
            {
                var dataPartner = await _dbContext.Partners.FirstOrDefaultAsync(v => v.Id.Equals(input.Id));
                if (dataPartner == null)
                    return new ResponseBase("Data partner tidak ditemukan", ResponseCode.NotFound);

                _mapper.Map(input, dataPartner);
                _dbContext.Update(dataPartner);
            }

            await _dbContext.SaveChangesAsync();
            return new ResponseBase($"Data partner berhasil {(input.Id.Equals(null) ? "dibuat" : "diedit")}", ResponseCode.Ok);
        }

        public async Task<ResponseBase> DeletePartner(Guid partnerId)
        {
            var dataPartner = await _dbContext.Partners.FirstOrDefaultAsync(v => v.Id.Equals(partnerId));
            if (dataPartner == null)
                return new ResponseBase("Data partner tidak ditemukan", ResponseCode.NotFound);

            dataPartner.RowStatus = 1;
            _dbContext.Update(dataPartner);
            await _dbContext.SaveChangesAsync();

            return new ResponseBase("Data partner berasil dihapus", ResponseCode.Ok);
        }
    }
}
