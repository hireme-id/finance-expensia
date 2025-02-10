using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class RecruiterService(ApplicationDbContext dbContext, IMapper mapper, ILogger<RecruiterService> logger)
        : BaseService<RecruiterService>(dbContext, mapper, logger)
    {
        public async Task<ResponsePaging<RecruiterDto>> GetListRecruiter(PagingSearchInputBase input)
        {
            var retVal = new ResponsePaging<RecruiterDto>();
            var dataRecruiters = _dbContext.Recruiters
                                           .Include(r => r.User)
                                           .OrderBy(d => d.RecruiterCode)
                                           .Where(d =>
                                            EF.Functions.Like(d.RecruiterCode, $"%{input.SearchKey}%")
                                            || EF.Functions.Like(d.User.FullName, $"%{input.SearchKey}%"))
                                           .Select(d => _mapper.Map<RecruiterDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, dataRecruiters);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponseObject<RecruiterDto>> GetDetailRecruiter(Guid recruiterId)
		{
			var dataRecruiters = await _dbContext.Recruiters
                                                 .Include(d => d.User)
                                                 .FirstOrDefaultAsync(x => x.Id == recruiterId);

            if (dataRecruiters == null)
                return new("Data recruiter tidak ditemukan", ResponseCode.NotFound);

            return new(responseCode: ResponseCode.Ok)
            {
                Obj = _mapper.Map<RecruiterDto>(dataRecruiters)
            };
        }

        public async Task<ResponseBase> UpsertRecruiter(UpsertRecruiterInput input)
        {
            if (input.Id.Equals(null))
            {
                var dataRecruiter = _mapper.Map<Recruiter>(input);
                await _dbContext.AddAsync(dataRecruiter);
            }
            else
            {
                var dataRecruiter = await _dbContext.Recruiters.FirstOrDefaultAsync(v => v.Id.Equals(input.Id));
                if (dataRecruiter == null)
                    return new("Data recruiter tidak ditemukan", ResponseCode.NotFound);

                _mapper.Map(input, dataRecruiter);
                _dbContext.Update(dataRecruiter);
            }

            await _dbContext.SaveChangesAsync();
            return new($"Data recruiter berhasil {(input.Id.Equals(null) ? "dibuat" : "diedit")}", ResponseCode.Ok);
        }

        public async Task<ResponseBase> DeleteRecruiter(Guid recruiterId)
        {
            var dataRecruiter = await _dbContext.Recruiters.FirstOrDefaultAsync(v => v.Id.Equals(recruiterId));
            if (dataRecruiter == null)
                return new("Data recruiter tidak ditemukan", ResponseCode.NotFound);

			dataRecruiter.RowStatus = 1;

            _dbContext.Update(dataRecruiter);
            await _dbContext.SaveChangesAsync();

            return new("Data recruiter berasil dihapus", ResponseCode.Ok);
        }
    }
}
