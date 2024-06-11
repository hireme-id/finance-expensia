using AutoMapper;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Finance.Expensia.Core.Services.DocumentNumbering
{
    public class DocumentNumberingService(ApplicationDbContext dbContext, IMapper mapper, ILogger<DocumentNumberingService> logger) :
        BaseService<DocumentNumberingService>(dbContext, mapper, logger)
    {
        public async Task<DocNumberConfig> GetRunningNumberDocument(string transactionTypeCode, string companyCode, DateTime date)
        {
            var docNumberConfig = await _dbContext.DocNumberConfigs.FirstOrDefaultAsync(x =>
                                                                        x.TransactionTypeCode == transactionTypeCode
                                                                        && x.CompanyCode == companyCode
                                                                        && x.Month == date.Month
                                                                        && x.Year == date.Year);

            if (docNumberConfig == null)
            {
                docNumberConfig = new DocNumberConfig
                {
                    TransactionTypeCode = transactionTypeCode,
                    CompanyCode = companyCode,
                    Month = date.Month,
                    Year = date.Year,
                    RunningNumber = 0
                };

                await _dbContext.DocNumberConfigs.AddAsync(docNumberConfig);
                await _dbContext.SaveChangesAsync();
            }

            await UpdateRunningNumber(docNumberConfig.Id);

            return docNumberConfig;
        }

        private async Task UpdateRunningNumber(Guid idData)
        {
            var docNumberConfig = await _dbContext.DocNumberConfigs.FirstOrDefaultAsync(x => x.Id == idData) ?? 
                throw new DbUpdateException($"Gagal melakukan update running number dokumen");

            docNumberConfig.RunningNumber++;

            _dbContext.DocNumberConfigs.Update(docNumberConfig);
            await _dbContext.SaveChangesAsync();
        }
    }
}
