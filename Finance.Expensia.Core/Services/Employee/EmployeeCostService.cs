using Finance.Expensia.Core.Services.Employee.Dtos;
using Finance.Expensia.Core.Services.Employee.Inputs;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Exceptions;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using NCalc;
using System.Reflection;
using System.Runtime.Serialization;

namespace Finance.Expensia.Core.Services.Employee
{
	public partial class EmployeeService
    {
        public async Task<ResponsePaging<EmployeeCostDto>> RetrievePagingEmployeeCost(PagingSearchInputBase input)
        {
            var retVal = new ResponsePaging<EmployeeCostDto>();

            var employeeCostDtos = _dbContext.EmployeeCosts.Include(d => d.Employee)
                                                           .Include(d => d.Company)
                                                           .Include(d => d.CostCenter)
                                                           .Where(d => 
                                                            EF.Functions.Like(d.Employee.EmployeeName, $"%{input.SearchKey}%")
                                                            || EF.Functions.Like(d.CostCenter.CostCenterName, $"%{input.SearchKey}%")
                                                            || EF.Functions.Like(d.Company.CompanyName, $"%{input.SearchKey}%")
                                                           )
                                                           .OrderByDescending(d => d.Modified ?? d.Created)
                                                           .Select(d => _mapper.Map<EmployeeCostDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, employeeCostDtos);

            return await Task.FromResult(retVal);
        }

		public async Task<ResponseObject<EmployeeCostDto>> RetrieveEmployeeCost(Guid employeeCostId)
		{
			var employeeCost = await _dbContext.EmployeeCosts
											   .Include(ec => ec.Employee)
											   .Include(ec => ec.Company)
											   .Include(ec => ec.CostCenter)
											   .Include(ec => ec.EmployeeCostComponents.OrderBy(d => d.CostComponentNo))
											   .FirstOrDefaultAsync(d => d.Id == employeeCostId);

			if (employeeCost == null)
				return new("Data employee cost tidak ditemukan", ResponseCode.NotFound);

			return new(responseCode: ResponseCode.Ok)
			{
				Obj = _mapper.Map<EmployeeCostDto>(employeeCost)
			};
		}

        public async Task<ResponseObject<List<EmployeeCostComponentDto>>> RetrieveInitialEmployeeCostComponents()
        {
            var employeeCostComponentDtos = await _dbContext.CostComponents.Where(d => d.IsActive).OrderBy(d => d.CostComponentNo).Select(d => _mapper.Map<EmployeeCostComponentDto>(d)).ToListAsync();

            if (employeeCostComponentDtos == null)
                return new ResponseObject<List<EmployeeCostComponentDto>>("Tidak ada data komponen ditemukan", responseCode: ResponseCode.NotFound);

            employeeCostComponentDtos
                .FindAll(d => d.CostComponentName.Contains("[NonTaxableIncome]"))
                .ForEach(d => d.CostComponentName = d.CostComponentName.Replace("[NonTaxableIncome]", "..."));
			employeeCostComponentDtos
                .FindAll(d => d.CostComponentName.Contains("[EffectiveTaxCategory]"))
                .ForEach(d => d.CostComponentName = d.CostComponentName.Replace("[EffectiveTaxCategory]", "..."));

			return new ResponseObject<List<EmployeeCostComponentDto>>(responseCode: ResponseCode.Ok)
			{
				Obj = employeeCostComponentDtos.Where(d => d.IsVisible).ToList()
			};
        }

        public async Task<ResponseObject<List<EmployeeCostComponentDto>>> CalculateEmployeeCost(CalculateEmployeeCostInput input, bool showAll = false)
        {
			var employeeCostComponentDtos = await _dbContext.CostComponents.Where(d => d.IsActive)
                                                                           .OrderBy(d => d.CostComponentNo)
                                                                           .Select(d => _mapper.Map<EmployeeCostComponentDto>(d))
                                                                           .ToListAsync();

			if (employeeCostComponentDtos == null)
				return new ResponseObject<List<EmployeeCostComponentDto>>("Tidak ada data komponen ditemukan", responseCode: ResponseCode.NotFound);

            var effectiveTaxCategoryAssignmentData = await _dbContext.EffectiveTaxCategoryAssignments.FirstOrDefaultAsync(d => d.NonTaxableIncome == input.NonTaxableIncome);

            if (effectiveTaxCategoryAssignmentData == null)
                return new ResponseObject<List<EmployeeCostComponentDto>>("Tidak ada data ptkp ditemukan", responseCode: ResponseCode.NotFound);

			var memberInfo = typeof(NonTaxableIncome).GetMember(input.NonTaxableIncome.ToString()).FirstOrDefault();
			var enumMemberAttribute = memberInfo?.GetCustomAttribute<EnumMemberAttribute>();

			employeeCostComponentDtos
                .FindAll(d => d.CostComponentName.Contains("[NonTaxableIncome]"))
                .ForEach(d => d.CostComponentName = d.CostComponentName.Replace("[NonTaxableIncome]", enumMemberAttribute?.Value ?? input.NonTaxableIncome.GetDescription()));
			employeeCostComponentDtos
                .FindAll(d => d.CostComponentName.Contains("[EffectiveTaxCategory]"))
                .ForEach(d => d.CostComponentName = d.CostComponentName.Replace("[EffectiveTaxCategory]", effectiveTaxCategoryAssignmentData.EffectiveTaxCategory.GetDescription()));

            foreach (var employeeCostComponentInput in input.EmployeeCostComponents)
            {
                var employeeCostComponent = employeeCostComponentDtos.FirstOrDefault(d => d.CostComponentId == employeeCostComponentInput.CostComponentId);

                if (employeeCostComponent != null)
				    employeeCostComponent.CostComponentAmount = employeeCostComponentInput.CostComponentAmount;
            }

			foreach (var item in employeeCostComponentDtos)
			{
				if (item.IsCalculated)
				{
					var expression = new Expression(item.CalculateFormula);
					expression.EvaluateParameter += (name, args) =>
					{
						if (name == "EmployeeStatus")
						{
							args.Result = (int)input.EmployeeStatus;
						}
						else if (name == "TaxRate")
						{
							var takeHomePay = employeeCostComponentDtos.FirstOrDefault(d => d.
																			CostComponentCategory == CostComponentCategory.MonthlyEarningBenefit &&
																			d.CostComponentType == CostComponentType.SubTotal)?
																	   .CostComponentAmount ?? 0;

							var effectiveTaxRate = _dbContext.EffectiveTaxRates
															 .FirstOrDefault(d =>
																d.EffectiveTaxCategory == effectiveTaxCategoryAssignmentData.EffectiveTaxCategory &&
																d.IncomeLowerLimit <= takeHomePay && d.IncomeUpperLimit >= takeHomePay
															 );

							args.Result = effectiveTaxRate?.TaxRate ?? 0.0m;
						}
						else if (name == "NonTaxableIncome")
						{
                            args.Result = (int)input.NonTaxableIncome;
                        }
                        else if (name == "LaptopOwnership")
                        {
                            args.Result = (int)input.LaptopOwnership;
                        }
                        else if (int.TryParse(name, out var costComponentId))
						{
							if (employeeCostComponentDtos.Any(d => d.CostComponentNo == costComponentId))
							{
								var index = employeeCostComponentDtos.FindIndex(d => d.CostComponentNo == costComponentId);
								args.Result = employeeCostComponentDtos[index].CostComponentTotalAmount;
							}
							else
							{
								args.Result = 0;
							}
						}
					};

					var evalValue = expression.Evaluate();
					if (evalValue == null) item.CostComponentAmount = 0;
					else
					{
						if (evalValue.GetType() == typeof(double))
						{
							item.CostComponentAmount = (int)Math.Round((double)evalValue);
						}
						else if (evalValue.GetType() == typeof(decimal))
						{
							item.CostComponentAmount = (int)Math.Round((decimal)evalValue);
						}
						else if (evalValue.GetType() == typeof(int))
						{
							item.CostComponentAmount = (int)evalValue;
						}
						else
						{
							item.CostComponentAmount = 0;
						}						
					}
				}

				item.CostComponentTotalAmount = item.CostComponentType == CostComponentType.Daily ? item.CostComponentAmount * input.WorkingDay : item.CostComponentAmount;
			}

			return new(responseCode: ResponseCode.Ok)
			{
				Obj = employeeCostComponentDtos.Where(d => d.IsVisible || showAll).ToList()
			};
		}

		public async Task<ResponseBase> CreateEmployeeCost(EmployeeCostInput input)
		{
			var (validateInputStatus, validateInputMessage) = ValidateEmployeeCostInput(input);
			if (validateInputStatus != ResponseCode.Ok)
				return new(validateInputMessage, validateInputStatus);

			var (validateDataStatus, validateDataMessage, dataCompany, dataCostCenter, dataEffectiveTaxCategoryAssignment) = 
				await ValidateEmployeeCostReferenceData(input);
			if (validateDataStatus != ResponseCode.Ok)
				return new(validateDataMessage, validateDataStatus);

			if (!input.EmployeeId.HasValue)
			{
				var employeeData = await CreateEmployee(new() { EmployeeNo = input.EmployeeNo, EmployeeName = input.EmployeeName });
				input.EmployeeId = employeeData.Id;
			}
			
			var employeeCostData = _mapper.Map<EmployeeCost>(input);
			employeeCostData.EffectiveTaxCategory = dataEffectiveTaxCategoryAssignment.EffectiveTaxCategory;

			var employeeCostComponentDto = await CalculateEmployeeCost(new()
			{
				EmployeeStatus = input.EmployeeStatus,
				NonTaxableIncome = input.NonTaxableIncome,
				LaptopOwnership = input.LaptopOwnership,
				WorkingDay = input.WorkingDay,
				EmployeeCostComponents = input.EmployeeCostComponents
			}, true);
			if (!employeeCostComponentDto.Succeeded || employeeCostComponentDto.Obj == null)
				return new("Terjadi kesalahan pada proses kalkulasi", ResponseCode.Error);

			employeeCostData.EmployeeCostComponents = employeeCostComponentDto.Obj.Select(_mapper.Map<EmployeeCostComponent>).ToList();

			await _dbContext.AddAsync(employeeCostData);
			await _dbContext.SaveChangesAsync();

			return new("Data employee cost berhasil disimpan", ResponseCode.Ok);
		}

		public async Task<ResponseBase> UpdateEmployeeCost(EmployeeCostInput input)
		{
			var employeeCostData = await _dbContext.EmployeeCosts.Include(ec => ec.EmployeeCostComponents).FirstOrDefaultAsync(d => d.Id.Equals(input.EmployeeCostId));
			if (employeeCostData == null)
				return new("Data employee cost tidak ditemukan", ResponseCode.NotFound);

			var (validateInputStatus, validateInputMessage) = ValidateEmployeeCostInput(input);
			if (validateInputStatus != ResponseCode.Ok)
				return new(validateInputMessage, validateInputStatus);

			var (validateDataStatus, validateDataMessage, dataCompany, dataCostCenter, dataEffectiveTaxCategoryAssignment) =
				await ValidateEmployeeCostReferenceData(input);
			if (validateDataStatus != ResponseCode.Ok)
				return new(validateDataMessage, validateDataStatus);

			employeeCostData.EmployeeStatus = input.EmployeeStatus;
			employeeCostData.JobPosition = input.JobPosition;
			employeeCostData.NonTaxableIncome = input.NonTaxableIncome;
			employeeCostData.WorkingDay = input.WorkingDay;
			employeeCostData.LaptopOwnership = input.LaptopOwnership;
			employeeCostData.Remark = input.Remark;
			employeeCostData.EffectiveTaxCategory = dataEffectiveTaxCategoryAssignment.EffectiveTaxCategory;

			foreach (var employeeCostComponent in employeeCostData.EmployeeCostComponents)
			{
				employeeCostComponent.RowStatus = 1;
			}

			_dbContext.Update(employeeCostData);

			var employeeCostComponentDto = await CalculateEmployeeCost(new()
			{
				EmployeeStatus = input.EmployeeStatus,
				NonTaxableIncome = input.NonTaxableIncome,
                LaptopOwnership = input.LaptopOwnership,
                WorkingDay = input.WorkingDay,
				EmployeeCostComponents = input.EmployeeCostComponents
			}, true);
			if (!employeeCostComponentDto.Succeeded || employeeCostComponentDto.Obj == null)
				return new("Terjadi kesalahan pada proses kalkulasi", ResponseCode.Error);

			var employeeCostComponentDatas = employeeCostComponentDto.Obj.Select(_mapper.Map<EmployeeCostComponent>).ToList();
			foreach (var employeeCostComponentData in employeeCostComponentDatas)
			{
				employeeCostComponentData.EmployeeCostId = employeeCostData.Id;
			}
			await _dbContext.AddRangeAsync(employeeCostComponentDatas);
			
			await _dbContext.SaveChangesAsync();

			return new("Data employee cost berhasil disimpan", ResponseCode.Ok);
		}

		public async Task<ResponseBase> DeleteEmployeeCost(Guid employeeCostId)
		{
			var dataEmployeeCost = await _dbContext.EmployeeCosts.FirstOrDefaultAsync(d => d.Id.Equals(employeeCostId));
			if (dataEmployeeCost == null)
				return new("Data employee cost tidak ditemukan", ResponseCode.NotFound);

			dataEmployeeCost.RowStatus = 1;
			
			_dbContext.Update(dataEmployeeCost);
			await _dbContext.SaveChangesAsync();

			return new("Data employee cost berhasil dihapus", ResponseCode.Ok);
		}

		private static (ResponseCode validateInputStatus, string validateInputMessage) ValidateEmployeeCostInput(EmployeeCostInput input)
		{
			if (input == null)
				return (ResponseCode.NotFound, "Tolong lengkapi informasi yang mandatory");

			input.Remark = string.Join(" ", input.Remark.Split(" ", StringSplitOptions.RemoveEmptyEntries));
			if (string.IsNullOrEmpty(input.Remark) || input.Remark.Length <= 10)
				return (ResponseCode.BadRequest, "Remark harus diisi dan minimal 10 huruf");

			return (ResponseCode.Ok, string.Empty);
		}

		private async Task<(
			ResponseCode validateDataStatus,
			string validateDataMessage,
			Company dataCompany,
			CostCenter dataCostCenter,
			EffectiveTaxCategoryAssignment dataEffectiveTaxCategoryAssignment)>
		ValidateEmployeeCostReferenceData(EmployeeCostInput input)
		{
			var dataCompany = await _dbContext.Companies.FirstOrDefaultAsync(d => d.Id.Equals(input.CompanyId));
			var dataCostCenter = await _dbContext.CostCenters.FirstOrDefaultAsync(d => d.CompanyId.Equals(input.CompanyId) && d.Id.Equals(input.CostCenterId));
			var dataEffectiveTaxCategoryAssignment = await _dbContext.EffectiveTaxCategoryAssignments.FirstOrDefaultAsync(d => d.NonTaxableIncome == input.NonTaxableIncome);

			try
			{
				if (dataCompany == null)
					throw new CustomValidationException(ResponseCode.NotFound, "Data company tidak valid");

				if (dataCostCenter == null)
					throw new CustomValidationException(ResponseCode.NotFound, "Data cost center tidak valid");

				if (dataEffectiveTaxCategoryAssignment == null)
					throw new CustomValidationException(ResponseCode.NotFound, "Data TER tidak valid");
			}
			catch (CustomValidationException ex)
			{
				return (ex.Code, ex.Message, null!, null!, null!);
			}

			return (ResponseCode.Ok, string.Empty, dataCompany, dataCostCenter, dataEffectiveTaxCategoryAssignment);
		}
	}
}
