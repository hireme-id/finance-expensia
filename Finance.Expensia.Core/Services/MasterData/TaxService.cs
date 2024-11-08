using AutoMapper;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NPOI.Util.Collections;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Finance.Expensia.Core.Services.MasterData
{
    public class TaxService(ApplicationDbContext dbContext, IMapper mapper, ILogger<TaxService> logger)
        : BaseService<TaxService>(dbContext, mapper, logger)
    {
        public async Task<ResponseObject<EffectiveTaxDto>> RetrieveEffectiveTaxData(EffectiveTaxCategory effectiveTaxCategory)
        {
            var effectiveTaxCategoryAssigmentDatas = await _dbContext.EffectiveTaxCategoryAssignments
                                                                     .Where(d => d.EffectiveTaxCategory == effectiveTaxCategory)
                                                                     .ToListAsync();

            var effectiveTaxRateDatas = await _dbContext.EffectiveTaxRates
                                                        .Where(d => d.EffectiveTaxCategory == effectiveTaxCategory)
                                                        .OrderBy(d => d.IncomeLowerLimit)
                                                        .ToListAsync();

            return new ResponseObject<EffectiveTaxDto>(responseCode: ResponseCode.Ok)
            {
                Obj = new EffectiveTaxDto
                {
                    NonTaxableIncomes = effectiveTaxCategoryAssigmentDatas.Select(d => d.NonTaxableIncome).ToList(),
                    EffectiveTaxRates = effectiveTaxRateDatas.Select(_mapper.Map<EffectiveTaxRateDto>).ToList()
                }
            };
        }

        public async Task<ResponseBase> UpdateEffectiveTaxData(UpdateEffectiveTaxInput input)
        {
            var effectiveTaxCategoryAssignmentDatas = await _dbContext.EffectiveTaxCategoryAssignments
                                                        .Where(d => d.EffectiveTaxCategory == input.EffectiveTaxCategory)
                                                        .ToListAsync();

            #region Delete Non Taxable Income that not exist on input
            var deleteEffectiveTaxCategoryAssignments = (from d in effectiveTaxCategoryAssignmentDatas
                                                         where !input.NonTaxableIncomes.Contains(d.NonTaxableIncome)
                                                         select d);

            if (deleteEffectiveTaxCategoryAssignments.Any())
            {
                foreach (var deleteEffectiveTaxCategoryAssignment in deleteEffectiveTaxCategoryAssignments)
                {
                    deleteEffectiveTaxCategoryAssignment.RowStatus = 1;
                    _dbContext.Update(deleteEffectiveTaxCategoryAssignment);
                }
            }
            #endregion

            #region Add Non Taxable Income that new on input
            var addNonTaxableIncomeDatas = (from i in input.NonTaxableIncomes
                                            where !effectiveTaxCategoryAssignmentDatas.Select(d => d.NonTaxableIncome).Contains(i)
                                            select i);

            if (addNonTaxableIncomeDatas.Any())
            {
                foreach (var addNonTaxableIncomeData in addNonTaxableIncomeDatas)
                {
                    var effectiveTaxCategoryAssignmentDataAlreadyMapped = await _dbContext.EffectiveTaxCategoryAssignments
                                                                                          .FirstOrDefaultAsync(d => 
                                                                                            d.EffectiveTaxCategory != input.EffectiveTaxCategory 
                                                                                            && d.NonTaxableIncome == addNonTaxableIncomeData
                                                                                          );

                    if (effectiveTaxCategoryAssignmentDataAlreadyMapped != null)
                        return new ResponseBase($"PTKP {addNonTaxableIncomeData.GetDescription()} telah terdaftar pada {effectiveTaxCategoryAssignmentDataAlreadyMapped.EffectiveTaxCategory.GetDescription()}", ResponseCode.BadRequest);

                    var updateEffectiveTaxCategoryAssignment = await _dbContext.EffectiveTaxCategoryAssignments
                                                                     .IgnoreQueryFilters()
                                                                     .FirstOrDefaultAsync(d => d.NonTaxableIncome == addNonTaxableIncomeData && d.RowStatus == 1);

                    if (updateEffectiveTaxCategoryAssignment != null)
                    {
                        updateEffectiveTaxCategoryAssignment.EffectiveTaxCategory = input.EffectiveTaxCategory;
                        updateEffectiveTaxCategoryAssignment.RowStatus = 0;
                        _dbContext.Update(updateEffectiveTaxCategoryAssignment);
                    }
                    else
                    {
                        await _dbContext.AddAsync(new EffectiveTaxCategoryAssignment
                        {
                            NonTaxableIncome = addNonTaxableIncomeData,
                            EffectiveTaxCategory = input.EffectiveTaxCategory
                        });
                    }
                }
            }
            #endregion


            var effectiveTaxRateDatas = await _dbContext.EffectiveTaxRates.Where(d => d.EffectiveTaxCategory == input.EffectiveTaxCategory).ToListAsync();

            #region Validation the lower & upper amount cannot be overlapped
            var effectiveTaxRateInputs = input.EffectiveTaxRates.OrderBy(d => d.IncomeLowerLimit).ToList();
            var errorMessage = "";
            for (int i = 0; i < effectiveTaxRateInputs.Count; i++)
            {
                if (i == 0)
                {
                    if (effectiveTaxRateInputs[i].IncomeLowerLimit != 0)
                    {
                        errorMessage += $"<br>Nilai nominal awal yang paling harus dimulai dari 0";
                    }
                }
                
                if (i == effectiveTaxRateInputs.Count - 1 && effectiveTaxRateInputs[i].IncomeUpperLimit.HasValue)
                {
                    errorMessage += $"<br>Nilai nominal akhir pada baris terakhir tidak boleh diisi.";
                }
                
                if (i > 0 && effectiveTaxRateInputs[i].IncomeLowerLimit != effectiveTaxRateInputs[i - 1].IncomeUpperLimit + 1)
                {
                    errorMessage += $"<br>Nilai nominal awal pada baris ke {i + 1} harus selisih 1 rupiah, dibandingkan nominal akhir pada baris sebelumnya.";
                }

                if (effectiveTaxRateInputs[i].IncomeLowerLimit > effectiveTaxRateInputs[i].IncomeUpperLimit)
                {
                    errorMessage += $"<br>Nilai nominal awal pada baris ke {i + 1} harus lebih kecil dibandingkan nominal akhir pada baris yang sama.";
                }
            }

            if (!string.IsNullOrEmpty(errorMessage))
                return new ResponseBase(errorMessage[4..], ResponseCode.Error);

            #endregion

            #region Delete data effective tax rate if not found in input
            var deleteEffectiveTaxRates = (from d in effectiveTaxRateDatas
                                           join i in effectiveTaxRateInputs on d.Id equals i.EffectiveTaxRateId into iLeft
                                           from i in iLeft.DefaultIfEmpty()
                                           where i == null
                                           select d);

            if (deleteEffectiveTaxRates.Any())
            {
                foreach (var deleteEffectiveTaxRate in deleteEffectiveTaxRates)
                {
                    deleteEffectiveTaxRate.RowStatus = 1;
                    _dbContext.Update(deleteEffectiveTaxRate);
                }
            }
            #endregion

            #region Update data effective tax rate if found in input
            var updateEffectiveTaxRates = (from d in effectiveTaxRateDatas
                                           join i in effectiveTaxRateInputs on d.Id equals i.EffectiveTaxRateId
                                           select new { d, i });

            if (updateEffectiveTaxRates.Any())
            {
                foreach (var updateEffectiveTaxRate in updateEffectiveTaxRates)
                {
                    bool isDifference = false;

                    // Bandingkan properti menggunakan reflection
                    var dProperties = typeof(EffectiveTaxRate).GetProperties();
                    var iProperties = typeof(UpdateEffectiveTaxRateInput).GetProperties();
                    var iPropertiesDict = new Dictionary<string, PropertyInfo>();
                    foreach (var prop in iProperties)
                    {
                        iPropertiesDict[prop.Name] = prop;
                    }

                    foreach (var dProperty in dProperties)
                    {
                        if (iPropertiesDict.TryGetValue(dProperty.Name, out var iProperty))
                        {
                            var dValue = dProperty.GetValue(updateEffectiveTaxRate.d);
                            var iValue = iProperty.GetValue(updateEffectiveTaxRate.i);

                            // Bandingkan nilai properti, jika tidak sama kembalikan false
                            if (!object.Equals(dValue, iValue))
                            {
                                isDifference = true;
                            }
                        }
                    }

                    if (isDifference)
                    {
                        _mapper.Map(updateEffectiveTaxRate.i, updateEffectiveTaxRate.d);
                        _dbContext.Update(updateEffectiveTaxRate.d);
                    }
                }
            }
            #endregion

            #region Add data effective tax rate if new in input
            var addEffectiveTaxRates = (from i in effectiveTaxRateInputs
                                        join d in effectiveTaxRateDatas on i.EffectiveTaxRateId equals d.Id into dLeft
                                        from d in dLeft.DefaultIfEmpty()
                                        where d == null
                                        select i);

            if (addEffectiveTaxRates.Any())
            {
                foreach (var addEffectiveTaxRate in addEffectiveTaxRates)
                {
                    await _dbContext.AddAsync(_mapper.Map<EffectiveTaxRate>(addEffectiveTaxRate));
                }
            }
            #endregion

            await _dbContext.SaveChangesAsync();

            return new ResponseBase($"Tarif efektif rata-rata {input.EffectiveTaxCategory.GetDescription()} berhasil diperbaharui" ,ResponseCode.Ok);
        }
    }
}
