using AutoMapper;
using Finance.Expensia.Core.Services.Inbox;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.DataAccess;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects.Inputs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Reflection;
using System.Xml.Linq;

namespace Finance.Expensia.Core.Services.OutgoingPayment
{
    public class OutgoingPaymentService(ApplicationDbContext dbContext, IMapper mapper, ILogger<OutgoingPaymentService> logger) 
        : BaseService<OutgoingPaymentService>(dbContext, mapper, logger)
    {
        #region Query
        public async Task<ResponsePaging<ListOutgoingPaymentDto>> GetListOfOutgoingPayment(ListOutgoingPaymentFilterInput input)
        {
            var retVal = new ResponsePaging<ListOutgoingPaymentDto>();

			var dataOutgoingPayments = _dbContext.OutgoingPayments
                        .Where(d => !input.CompanyId.HasValue || input.CompanyId.Equals(d.CompanyId))
                        .Where(d => !input.ApprovalStatus.HasValue || input.ApprovalStatus.Equals(d.ApprovalStatus))
                        .Where(d => !input.StartDate.HasValue || d.RequestDate >= input.StartDate)
                        .Where(d => !input.EndDate.HasValue || d.RequestDate <= input.EndDate)
                        .Where(d =>
                            EF.Functions.Like(d.TransactionNo, $"%{input.SearchKey}%")
                            || EF.Functions.Like(d.Requestor, $"%{input.SearchKey}%")
                            || EF.Functions.Like(d.Remark, $"%{input.SearchKey}%")
                            || d.OutgoingPaymentTaggings.Any(t => EF.Functions.Like(t.TagValue, $"%{input.SearchKey}%")))
                        .Include(x => x.OutgoingPaymentTaggings.OrderBy(d => d.Created))
                        .OrderByDescending(d => d.Modified ?? d.Created)
                        .Select(d => _mapper.Map<ListOutgoingPaymentDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, dataOutgoingPayments);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponsePaging<ListOutgoingPaymentDto>> GetListOfOutgoingPaymentMyDocument(ListOutgoingPaymentFilterInput input, CurrentUserAccessor currentUserAccessor)
        {
            var retVal = new ResponsePaging<ListOutgoingPaymentDto>();

            var dataOutgoingPayments = _dbContext.OutgoingPayments
                .Where(d => !input.CompanyId.HasValue || input.CompanyId.Equals(d.CompanyId))
                .Where(d => !input.ApprovalStatus.HasValue || input.ApprovalStatus.Equals(d.ApprovalStatus))
                .Where(d => !input.StartDate.HasValue || d.RequestDate >= input.StartDate)
                .Where(d => !input.EndDate.HasValue || d.RequestDate <= input.EndDate)
                .Where(d =>
                    EF.Functions.Like(d.TransactionNo, $"%{input.SearchKey}%")
                    || EF.Functions.Like(d.Requestor, $"%{input.SearchKey}%")
                    || EF.Functions.Like(d.Remark, $"%{input.SearchKey}%")
                    || d.OutgoingPaymentTaggings.Any(t => EF.Functions.Like(t.TagValue, $"%{input.SearchKey}%")))
				.Where(d => EF.Functions.Like(d.CreatedBy, $"{currentUserAccessor.Id}"))
				.Include(x => x.OutgoingPaymentTaggings.OrderBy(d => d.Created))
				.OrderByDescending(d => d.Modified ?? d.Created)
                .Select(d => _mapper.Map<ListOutgoingPaymentDto>(d));

            retVal.ApplyPagination(input.Page, input.PageSize, dataOutgoingPayments);

            return await Task.FromResult(retVal);
        }

        public async Task<ResponseObject<OutgoingPaymentDto>> GetDetailOutgoingPayment(Guid outgoingPaymentId, CurrentUserAccessor currentUserAccessor)
		{
			var result = new ResponseObject<OutgoingPaymentDto>();
			var dataOutgoingPay = await _dbContext.OutgoingPayments
												  .Include(x => x.OutgoingPaymentTaggings.OrderBy(d => d.Created))
												  .Include(x => x.OutgoingPaymentDetails.OrderBy(d => d.Created))
												  .ThenInclude(x => x.OutgoingPaymentDetailAttachments)
												  .FirstOrDefaultAsync(x => x.Id == outgoingPaymentId);

			if (dataOutgoingPay != null)
			{
				var dataOutgoingPayDto = _mapper.Map<OutgoingPaymentDto>(dataOutgoingPay);
				if (dataOutgoingPayDto.CreatedBy != currentUserAccessor.Id.ToString())
					dataOutgoingPayDto.IsBtnCancelHidden = true;

                return await Task.FromResult(new ResponseObject<OutgoingPaymentDto>(responseCode: ResponseCode.Ok)
                {
                    Obj = dataOutgoingPayDto,
                });

            }

            return await Task.FromResult(new ResponseObject<OutgoingPaymentDto>("Data outgoing payment tidak ditemukan", ResponseCode.NotFound));
        }

		public async Task<ResponseObject<List<OutgoingPaymentTaggingDto>>> RetrieveOutgoingPaymentTagging(PagingSearchInputBase input)
		{
			var dataOutgoingPayments = await _dbContext.OutgoingPaymentTaggings
				.Where(d => EF.Functions.Like(d.TagValue, $"%{input.SearchKey}%"))
				.GroupBy(opt => opt.TagValue)
				.Select(g => g.Key)
				.OrderBy(tagValue => tagValue)
				.Skip((input.Page - 1) * input.PageSize)
				.Take(input.PageSize)
				.ToListAsync();

			var dataOutgoingPaymentsDto = dataOutgoingPayments
				.Select(tagValue => _mapper.Map<OutgoingPaymentTaggingDto>(new OutgoingPaymentTagging { TagValue = tagValue }))
				.ToList();

			return new ResponseObject<List<OutgoingPaymentTaggingDto>>(responseCode: ResponseCode.Ok)
			{
				Obj = dataOutgoingPaymentsDto
			};
		}

		public async Task<ResponseObject<List<GetDownloadOutgoingPaymentDto>>> GetListDownloadOutgoingPayment(DownloadOutgoingPaymentInput input, CurrentUserAccessor currentUserAccessor)
		{
			List<DownloadOutgoingPaymentDto> dataOutgoingPayments = new List<DownloadOutgoingPaymentDto>();
			if (currentUserAccessor.Permissions!.Any(d => d == PermissionConstants.OutgoingPayment.OutgoingPaymentView))
			{
				dataOutgoingPayments = await _dbContext.OutgoingPayments
									.Include(x => x.OutgoingPaymentDetails.OrderBy(d => d.Created))
									.Where(d => d.RequestDate >= input.StartDate)
									.Where(d => d.RequestDate <= input.EndDate)
									.OrderByDescending(d => d.Modified ?? d.Created)
									.Select(d => _mapper.Map<DownloadOutgoingPaymentDto>(d))
									.ToListAsync();
			}
			else
			{
				dataOutgoingPayments = await _dbContext.OutgoingPayments
									.Include(x => x.OutgoingPaymentDetails.OrderBy(d => d.Created))
									.Where(d => d.RequestDate >= input.StartDate)
									.Where(d => d.RequestDate <= input.EndDate)
									.Where(d => EF.Functions.Like(d.CreatedBy, $"{currentUserAccessor.Id}"))
									.OrderByDescending(d => d.Modified ?? d.Created)
									.Select(d => _mapper.Map<DownloadOutgoingPaymentDto>(d))
									.ToListAsync();
			}

			var processedData = dataOutgoingPayments
							.SelectMany(o => o.OutgoingPaymentDetails.DefaultIfEmpty(), (o, d) => new GetDownloadOutgoingPaymentDto
							{
								TransactionNo = o.TransactionNo,
								RequestDate = o.RequestDate,
								Requestor = o.Requestor,
								CompanyName = o.CompanyName,
								Remark = o.Remark,
								FromBankAliasName = o.FromBankAliasName,
								ToBankAliasName = o.ToBankAliasName,
								BankPaymentType = o.BankPaymentType,
								ApprovalStatus = o.ApprovalStatus,
								ExpectedTransfer = o.ExpectedTransfer,
								ScheduledDate = o.ScheduledDate,
								// Parameter di detail outgoing payment
								InvoiceDate = d?.InvoiceDate,
								PartnerName = d?.PartnerName ?? string.Empty,
								Description = d?.Description ?? string.Empty,
								ChartOfAccountNo = d?.ChartOfAccountNo ?? string.Empty,
								ChartOfAccountName = d?.ChartOfAccountName ?? string.Empty,
								CostCenterCode = d?.CostCenterCode ?? string.Empty,
								CostCenterName = d?.CostCenterName ?? string.Empty,
								PostingAccountName = d?.PostingAccountName ?? string.Empty,
								Amount = d?.Amount ?? 0
							})
							.ToList();

			return new ResponseObject<List<GetDownloadOutgoingPaymentDto>>(responseCode: ResponseCode.Ok)
			{
				Obj = processedData
			};
		}

		public async Task<byte[]> GetFileExcelOutgoingPayment(DownloadOutgoingPaymentInput input, CurrentUserAccessor currentUserAccessor)
		{
			var data = await GetListDownloadOutgoingPayment(input, currentUserAccessor);
			IWorkbook workbook = new XSSFWorkbook();
			ISheet sheet = workbook.CreateSheet("Sheet1");

			#region styling row
			// Date Style
			ICellStyle dateStyle = workbook.CreateCellStyle();
			dateStyle.DataFormat = workbook.CreateDataFormat().GetFormat("dd/MM/yyyy");

			// Number Style
			ICellStyle numberStyle = workbook.CreateCellStyle();
			numberStyle.DataFormat = workbook.CreateDataFormat().GetFormat("#,##0.00");

			ICellStyle headerStyle = workbook.CreateCellStyle();
			headerStyle.Alignment = HorizontalAlignment.Center;
			headerStyle.VerticalAlignment = VerticalAlignment.Center;
			headerStyle.FillForegroundColor = IndexedColors.Yellow.Index;
			headerStyle.FillPattern = FillPattern.SolidForeground;

			IFont headerFont = workbook.CreateFont();
			headerFont.IsBold = true;
			headerStyle.SetFont(headerFont);

			#endregion

			#region header cell
			IRow headerRow = sheet.CreateRow(0);

			PropertyInfo[] properties = typeof(GetDownloadOutgoingPaymentDto).GetProperties();

			string[] propertyNames = typeof(GetDownloadOutgoingPaymentDto).GetProperties(BindingFlags.Public | BindingFlags.Instance)
																	  .Select(prop => prop.Name)
																	  .ToArray();

			// Tambahkan "No" di awal array menggunakan LINQ
			string[] headers = new[] { "No" }.Concat(propertyNames).ToArray();

			for (int i = 0; i < headers.Length; i++)
			{
				ICell cell = headerRow.CreateCell(i);
				cell.SetCellValue(headers[i]);
				cell.CellStyle = headerStyle;
			}

			#endregion

			#region data cell

			for (int i = 0; i < data.Obj?.Count; i++)
			{
				IRow row = sheet.CreateRow(i + 1);
				row.CreateCell(0).SetCellValue(i + 1);
				string value = string.Empty;

				for (int j = 0; j < properties.Length; j++)
				{
					value = properties[j].GetValue(data.Obj?[i])?.ToString() ?? "";
					if (properties[j].PropertyType == typeof(DateTime) || properties[j].PropertyType == typeof(DateTime?))
					{
						if(value.IsNullOrEmpty())
						{
							row.CreateCell(j + 1).SetCellValue(value);
						}
						else
						{
							DateTime dateTimeValue = Convert.ToDateTime(value);
							row.CreateCell(j + 1).SetCellValue(dateTimeValue);
						}
					}
					else if (properties[j].PropertyType == typeof(decimal))
					{
						double decimalValue = Convert.ToDouble(value);
						row.CreateCell(j + 1).SetCellValue(decimalValue);
					}
					else
					{
						row.CreateCell(j + 1).SetCellValue(value);
					}

					switch (j)
					{
						case 2:
							row.GetCell(j + 1).CellStyle = dateStyle;
							break;
						case 6:
							row.GetCell(j + 1).CellStyle = dateStyle;
							break;
						case 11:
							row.GetCell(j + 1).CellStyle = dateStyle;
							break;
						case 19:
							row.GetCell(j + 1).CellStyle = numberStyle;
							break;
					}

				}
			}

			#endregion

			for (int i = 0; i < headers.Length; i++)
			{
				sheet.AutoSizeColumn(i);
			}

			using (var exportData = new MemoryStream())
			{
				workbook.Write(exportData);
				return exportData.ToArray();
			}
		}
		#endregion

		#region Mutation
		public async Task<ResponseBase> CreateOutgoingPayment(CreateOutgoingPaymentInput input, CurrentUserAccessor currentUserAccessor)
        {
			if (input == null)
				return new ResponseBase("Tolong lengkapi informasi yang mandatory", ResponseCode.NotFound);

			if (input.ExpectedTransfer == ExpectedTransfer.Scheduled && !input.ScheduledDate.HasValue)
				return new ResponseBase("Schedule date harus diisi");

			if (input.ScheduledDate.HasValue && input.ScheduledDate.Value.Date < DateTime.Now.Date)
				return new ResponseBase("Schedule date tidak boleh lebih kecil dari hari ini");

			if (input.OutgoingPaymentDetails.Count == 0 && input.IsSubmit)
				return new ResponseBase("Belum ada data detail", ResponseCode.NotFound);

			var dataCompany = await _dbContext.Companies.FirstOrDefaultAsync(d => d.Id.Equals(input.CompanyId));
            var dataFromBankAlias = await _dbContext.BankAliases.FirstOrDefaultAsync(d => d.Id.Equals(input.FromBankAliasId) && d.CompanyId.Equals(input.CompanyId));
			var dataToBankAlias = await _dbContext.BankAliases.FirstOrDefaultAsync(d => d.Id.Equals(input.ToBankAliasId));
            var dataTransactionType = await _dbContext.TransactionTypes.FirstOrDefaultAsync(d => d.Id.Equals(input.TransactionTypeId));

            if (dataCompany == null)
                return new ResponseBase("Data company tidak valid", ResponseCode.NotFound);

			if (dataFromBankAlias == null)
				return new ResponseBase("Data from bank alias tidak valid", ResponseCode.NotFound);

			if (dataToBankAlias == null)
				return new ResponseBase("Data to bank alias tidak valid", ResponseCode.NotFound);

            if (dataTransactionType == null)
                return new ResponseBase("Data to transaction type tidak valid", ResponseCode.NotFound);

            var dateNow = DateTime.Now;

			var runningNumberConfig = await GetRunningNumberDocument(dataTransactionType.TransactionTypeCode, dataCompany.CompanyCode, dateNow);

			#region set data entity => OutgoingPayment
			var dataOutgoingPayment = _mapper.Map<DataAccess.Models.OutgoingPayment>(input);

			dataOutgoingPayment.TransactionNo = $"{dataCompany.CompanyCode}-{dataTransactionType.TransactionTypeCode}-{dateNow:ddMMyy}-{(runningNumberConfig.RunningNumber + 1).ToString().PadLeft(4, '0')}";
			dataOutgoingPayment.Requestor = currentUserAccessor.FullName;
			dataOutgoingPayment.RequestDate = dateNow.Date;
			dataOutgoingPayment.CompanyName = dataCompany.CompanyName;
			dataOutgoingPayment.TransactionTypeCode = dataTransactionType.TransactionTypeCode;
			dataOutgoingPayment.ApprovalStatus = input.IsSubmit ? ApprovalStatus.WaitingApproval : ApprovalStatus.Draft;

			dataOutgoingPayment.FromBankAliasName = dataFromBankAlias.AliasName;
			dataOutgoingPayment.FromBankName = dataFromBankAlias.BankName;
			dataOutgoingPayment.FromAccountNo = dataFromBankAlias.AccountNo;
			dataOutgoingPayment.FromAccountName = dataFromBankAlias.AccountName;

			dataOutgoingPayment.ToBankAliasName = dataToBankAlias.AliasName;
			dataOutgoingPayment.ToBankName = dataToBankAlias.BankName;
			dataOutgoingPayment.ToAccountNo = dataToBankAlias.AccountNo;
			dataOutgoingPayment.ToAccountName = dataToBankAlias.AccountName;


			dataOutgoingPayment.TotalAmount = input.OutgoingPaymentDetails.Sum(d => d.Amount);
			#endregion

			#region set data entity => OutgoingPaymentDetail & OutgoingPaymentDetailAttachment
			foreach (var outgoingPaymentDetailInput in input.OutgoingPaymentDetails)
			{
				var dataPartner = await _dbContext.Partners.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentDetailInput.PartnerId));
				var dataCoa = await _dbContext.ChartOfAccounts.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentDetailInput.ChartOfAccountId) && d.CompanyId.Equals(input.CompanyId));
				var dataCostCenter = await _dbContext.CostCenters.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentDetailInput.CostCenterId) && d.CompanyId.Equals(input.CompanyId));
				var dataPostingAccount = await _dbContext.Companies.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentDetailInput.PostingAccountId));

				if (dataPartner == null)
					return new ResponseBase("Data partner tidak valid", ResponseCode.NotFound);

				if (dataCoa == null)
					return new ResponseBase("Data chart of account tidak valid", ResponseCode.NotFound);

				if (dataPostingAccount == null)
					return new ResponseBase("Data posting account tidak valid", ResponseCode.NotFound);

				var dataOutgoingPaymentDetail = _mapper.Map<OutgoingPaymentDetail>(outgoingPaymentDetailInput);

				dataOutgoingPaymentDetail.PartnerName = dataPartner.PartnerName;
				dataOutgoingPaymentDetail.ChartOfAccountNo = dataCoa.AccountCode;
                dataOutgoingPaymentDetail.ChartOfAccountName = dataCoa.AccountName;
                dataOutgoingPaymentDetail.CostCenterCode = dataCostCenter?.CostCenterCode ?? string.Empty;
				dataOutgoingPaymentDetail.CostCenterName = dataCostCenter?.CostCenterName ?? string.Empty;
				dataOutgoingPaymentDetail.PostingAccountName = dataPostingAccount.CompanyName;
				dataOutgoingPaymentDetail.OutgoingPaymentDetailAttachments.AddRange(outgoingPaymentDetailInput.OutgoingPaymentDetailAttachments.Select(d => _mapper.Map<OutgoingPaymentDetailAttachment>(d)));

				dataOutgoingPayment.OutgoingPaymentDetails.Add(dataOutgoingPaymentDetail);
			}
			#endregion

			await _dbContext.AddAsync(dataOutgoingPayment);

            if (input.IsSubmit)
            {
                var isSuccessWorkflow = await CreateApprovalWorkflow(dataOutgoingPayment, currentUserAccessor);

                if (!isSuccessWorkflow)
                    return new ResponseBase("Gagal membuat workflow approval", ResponseCode.Error);
            }

            await _dbContext.SaveChangesAsync();

            _ = await UpdateRunningNumber(runningNumberConfig.Id);

            return new ResponseBase($"Data outgoing payment berhasil {(input.IsSubmit ? "disubmit" : "disimpan sebagai draft")}", ResponseCode.Ok);
		}
		
		public async Task<ResponseBase> EditOutgoingPayment(EditOutgoingPaymentInput input, CurrentUserAccessor currentUserAccessor)
		{
            if (input == null)
                return new ResponseBase("Tolong lengkapi informasi yang mandatory", ResponseCode.NotFound);

			if (input.ExpectedTransfer == ExpectedTransfer.Scheduled && !input.ScheduledDate.HasValue)
				return new ResponseBase("Schedule date harus diisi");

			if (input.ScheduledDate.HasValue && input.ScheduledDate.Value.Date < DateTime.Now.Date)
				return new ResponseBase("Schedule date tidak boleh lebih kecil dari hari ini");

			if (input.OutgoingPaymentDetails.Count == 0 && input.IsSubmit)
                return new ResponseBase("Belum ada data detail", ResponseCode.NotFound);

            var dataCompany = await _dbContext.Companies.FirstOrDefaultAsync(d => d.Id.Equals(input.CompanyId));
            var dataFromBankAlias = await _dbContext.BankAliases.FirstOrDefaultAsync(d => d.Id.Equals(input.FromBankAliasId) && d.CompanyId.Equals(input.CompanyId));
            var dataToBankAlias = await _dbContext.BankAliases.FirstOrDefaultAsync(d => d.Id.Equals(input.ToBankAliasId));
            var dataTransactionType = await _dbContext.TransactionTypes.FirstOrDefaultAsync(d => d.Id.Equals(input.TransactionTypeId));

            if (dataCompany == null)
                return new ResponseBase("Data company tidak valid", ResponseCode.NotFound);

            if (dataFromBankAlias == null)
                return new ResponseBase("Data from bank alias tidak valid", ResponseCode.NotFound);

            if (dataToBankAlias == null)
                return new ResponseBase("Data to bank alias tidak valid", ResponseCode.NotFound);
            if (dataTransactionType == null)
                return new ResponseBase("Data to transaction type tidak valid", ResponseCode.NotFound);

            var existOutgoing = await _dbContext.OutgoingPayments.Include(x => x.OutgoingPaymentDetails)
				.ThenInclude(x => x.OutgoingPaymentDetailAttachments)
				.FirstOrDefaultAsync(x => x.Id == input.Id);

			if (existOutgoing == null)
                return await Task.FromResult(new ResponseObject<OutgoingPaymentDto>("Data outgoing payment tidak ditemukan", ResponseCode.NotFound));

            #region edit data outgoing payment
            existOutgoing.CompanyName = dataCompany.CompanyName;
			existOutgoing.TransactionTypeId = dataTransactionType.Id;
			existOutgoing.TransactionTypeCode = dataTransactionType.TransactionTypeCode;
            existOutgoing.ApprovalStatus = input.IsSubmit ? ApprovalStatus.WaitingApproval : ApprovalStatus.Draft;

            existOutgoing.FromBankAliasName = dataFromBankAlias.AliasName;
            existOutgoing.FromBankName = dataFromBankAlias.BankName;
            existOutgoing.FromAccountNo = dataFromBankAlias.AccountNo;
            existOutgoing.FromAccountName = dataFromBankAlias.AccountName;

            existOutgoing.ToBankAliasName = dataToBankAlias.AliasName;
            existOutgoing.ToBankName = dataToBankAlias.BankName;
            existOutgoing.ToAccountNo = dataToBankAlias.AccountNo;
            existOutgoing.ToAccountName = dataToBankAlias.AccountName;
			existOutgoing.ExpectedTransfer = input.ExpectedTransfer;
			existOutgoing.BankPaymentType = input.BankPaymentType;
			existOutgoing.Remark = input.Remark;
			existOutgoing.ScheduledDate = input.ScheduledDate;

			existOutgoing.TotalAmount = input.OutgoingPaymentDetails.Sum(d => d.Amount);
			#endregion

			await _dbContext.SaveChangesAsync();

			#region edit data outgoing payment detail

			//delete outgoing detail
			var deleteOutgoingDetails = await _dbContext.OutgoingPaymentDetails
														.Include(x => x.OutgoingPaymentDetailAttachments)
														.Where(x => 
															x.OutgoingPaymentId == input.Id 
															&& !input.OutgoingPaymentDetails.Select(d => d.Id).Contains(x.Id))
														.ToListAsync();

			if (deleteOutgoingDetails.Count != 0)
			{
				foreach (var deleteOutgoingDetail in deleteOutgoingDetails)
				{
					deleteOutgoingDetail.RowStatus = 1;
					foreach (var attachment in deleteOutgoingDetail.OutgoingPaymentDetailAttachments)
					{
						attachment.RowStatus = 1;
					}
					_dbContext.Update(deleteOutgoingDetail);
				}
			}

			// add / edit outgoing payment detail
			foreach (var outgoingPaymentDetailInput in input.OutgoingPaymentDetails)
			{
                var dataPartner = await _dbContext.Partners.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentDetailInput.PartnerId));
                var dataCoa = await _dbContext.ChartOfAccounts.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentDetailInput.ChartOfAccountId) && d.CompanyId.Equals(input.CompanyId));
                var dataCostCenter = await _dbContext.CostCenters.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentDetailInput.CostCenterId) && d.CompanyId.Equals(input.CompanyId));
				var dataPostingAccount = await _dbContext.Companies.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentDetailInput.PostingAccountId));

				if (dataPartner == null)
                    return new ResponseBase("Data partner tidak valid", ResponseCode.NotFound);

                if (dataCoa == null)
                    return new ResponseBase("Data chart of account tidak valid", ResponseCode.NotFound);

				if (dataPostingAccount == null)
					return new ResponseBase("Data posting account tidak valid", ResponseCode.NotFound);

				var existOutgoingDetail = existOutgoing.OutgoingPaymentDetails.FirstOrDefault(x => x.Id == outgoingPaymentDetailInput.Id);
				if (existOutgoingDetail != null)
				{
					//Edit data yang sudah ada
					existOutgoingDetail.InvoiceDate = outgoingPaymentDetailInput.InvoiceDate;
					existOutgoingDetail.Description = outgoingPaymentDetailInput.Description;
					existOutgoingDetail.PartnerId = outgoingPaymentDetailInput.PartnerId;
					existOutgoingDetail.PartnerName = dataPartner.PartnerName;
					existOutgoingDetail.ChartOfAccountId = outgoingPaymentDetailInput.ChartOfAccountId ?? Guid.Empty;
                    existOutgoingDetail.ChartOfAccountNo = dataCoa.AccountCode;
                    existOutgoingDetail.ChartOfAccountName = dataCoa.AccountName;
					existOutgoingDetail.CostCenterId = outgoingPaymentDetailInput.CostCenterId;
					existOutgoingDetail.CostCenterCode = dataCostCenter?.CostCenterCode ?? string.Empty;
                    existOutgoingDetail.CostCenterName = dataCostCenter?.CostCenterName ?? string.Empty;
					existOutgoingDetail.PostingAccountId = outgoingPaymentDetailInput.PostingAccountId;
					existOutgoingDetail.PostingAccountName = dataPostingAccount.CompanyName;
					existOutgoingDetail.Amount = outgoingPaymentDetailInput.Amount;

					//delete attachment
					var deletedAttachments = existOutgoingDetail.OutgoingPaymentDetailAttachments
																.Where(x => 
																	!outgoingPaymentDetailInput.OutgoingPaymentDetailAttachments.Select(d => d.Id).Contains(x.Id));

					if (deletedAttachments.Any())
					{
						foreach (var deletedAttachment in deletedAttachments)
						{
							deletedAttachment.RowStatus = 1;
							_dbContext.Update(deletedAttachment);
						}
					}

					//add attachment
					foreach (var outgoingPaymentDetailAttachmentInput in outgoingPaymentDetailInput.OutgoingPaymentDetailAttachments.Where(d => !d.Id.HasValue))
					{
						var newOutgoingDetailAttachment = _mapper.Map<OutgoingPaymentDetailAttachment>(outgoingPaymentDetailAttachmentInput);
						newOutgoingDetailAttachment.OutgoingPaymentDetailId = existOutgoingDetail.Id;

						await _dbContext.AddAsync(newOutgoingDetailAttachment);
					}

					_dbContext.Update(existOutgoingDetail);
				}
				else
				{
					//Add data baru
                    var dataOutgoingPaymentDetail = _mapper.Map<OutgoingPaymentDetail>(outgoingPaymentDetailInput);

					dataOutgoingPaymentDetail.OutgoingPaymentId = existOutgoing.Id;
					dataOutgoingPaymentDetail.PartnerName = dataPartner.PartnerName;
                    dataOutgoingPaymentDetail.ChartOfAccountNo = dataCoa.AccountCode;
                    dataOutgoingPaymentDetail.ChartOfAccountName = dataCoa.AccountName;
                    dataOutgoingPaymentDetail.CostCenterCode = dataCostCenter?.CostCenterCode ?? string.Empty;
                    dataOutgoingPaymentDetail.CostCenterName = dataCostCenter?.CostCenterName ?? string.Empty;
					dataOutgoingPaymentDetail.PostingAccountName = dataPostingAccount.CompanyName;
                    dataOutgoingPaymentDetail.OutgoingPaymentDetailAttachments.AddRange(outgoingPaymentDetailInput.OutgoingPaymentDetailAttachments.Select(d => _mapper.Map<OutgoingPaymentDetailAttachment>(d)));

					await _dbContext.AddAsync(dataOutgoingPaymentDetail);
                }
			}

			//delete outgoing tagging
			var deleteOutgoingTaggings = await _dbContext.OutgoingPaymentTaggings
														.Where(x =>
															x.OutgoingPaymentId == input.Id
															&& !input.OutgoingPaymentTaggings.Select(d => d.Id).Contains(x.Id))
														.ToListAsync();

			if (deleteOutgoingTaggings.Count != 0)
			{
				foreach (var deleteOutgoingTagging in deleteOutgoingTaggings)
				{
					deleteOutgoingTagging.RowStatus = 1;
					_dbContext.Update(deleteOutgoingTagging);
				}
			}

			// add outgoing tagging
			foreach (var outgoingPaymentTaggingInput in input.OutgoingPaymentTaggings)
			{
				var existOutgoingTagging = existOutgoing.OutgoingPaymentTaggings.FirstOrDefault(x => x.Id == outgoingPaymentTaggingInput.Id);
				if (existOutgoingTagging == null)
				{
					//Add data baru
					var dataOutgoingPaymentTagging = _mapper.Map<OutgoingPaymentTagging>(outgoingPaymentTaggingInput);

					dataOutgoingPaymentTagging.OutgoingPaymentId = existOutgoing.Id;
					dataOutgoingPaymentTagging.TagValue = outgoingPaymentTaggingInput.TagValue;

					await _dbContext.AddAsync(dataOutgoingPaymentTagging);
				}
			}
			#endregion

				_dbContext.OutgoingPayments.Update(existOutgoing);

			if (input.IsSubmit)
			{
                var isSuccessWorkflow = await CreateApprovalWorkflow(existOutgoing, currentUserAccessor);

                if (!isSuccessWorkflow)
                    return new ResponseBase("Gagal membuat workflow approval", ResponseCode.Error);
            }

            await _dbContext.SaveChangesAsync();

            return new ResponseBase($"Data outgoing payment berhasil {(input.IsSubmit ? "disubmit" : "disimpan sebagai draft")}", ResponseCode.Ok);
        }

		public async Task<ResponseBase> DeleteOutgoingPayment(Guid outgoingPaymentId)
		{
			var outgoingPayment = await _dbContext.OutgoingPayments.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentId));
			if (outgoingPayment == null)
				return new ResponseBase("Gagal hapus data, karena data tidak ditemukan", ResponseCode.NotFound);

			if (outgoingPayment.ApprovalStatus != ApprovalStatus.Draft)
				return new ResponseBase("Gagal hapus data, dokumen yang dapat dihapus hanya dokumen berstatus draft", ResponseCode.Error);

			outgoingPayment.RowStatus = 1;
			_dbContext.Update(outgoingPayment);
			await _dbContext.SaveChangesAsync();

			return new ResponseBase("Berhasil menghapus data", ResponseCode.Ok);
		}

		public async Task<ResponseBase> CancelOutgoingPaymen(Guid outgoingPaymentId, CurrentUserAccessor currentUserAccessor)
		{
            var outgoingPayment = await _dbContext.OutgoingPayments.FirstOrDefaultAsync(d => d.Id.Equals(outgoingPaymentId));
            if (outgoingPayment == null)
                return new ResponseBase("Gagal membatalkan dokumen, karena dokumen tidak ditemukan", ResponseCode.NotFound);

            if (outgoingPayment.ApprovalStatus != ApprovalStatus.WaitingApproval)
                return new ResponseBase("Gagal membatalkan dokumen, dokumen yang dapat dibatalkan hanya dokumen berstatus waiting approval", ResponseCode.Error);

			if (outgoingPayment.CreatedBy != currentUserAccessor.Id.ToString())
                return new ResponseBase("Gagal membatalkan dokumen, dokumen yang dapat dibatalkan hanya bisa dibatalkan oleh requestor", ResponseCode.Error);

            outgoingPayment.ApprovalStatus = ApprovalStatus.Cancelled;
            _dbContext.Update(outgoingPayment);

			var cancelApproval = await CancelInboxApproval(outgoingPayment, currentUserAccessor);

			if (!cancelApproval)
				return new ResponseBase("Gagal membatalkan approval untuk dokumen ini");

            await _dbContext.SaveChangesAsync();

            return new ResponseBase("Berhasil membatalkan dokumen", ResponseCode.Ok);
        }
		#endregion

		public async Task<bool> UpdateApprovalStatusOutgoingPayment(string transactionNo, ApprovalStatus approvalStatus)
		{
			var outgoingPayment = await _dbContext.OutgoingPayments.FirstOrDefaultAsync(d => d.TransactionNo.Equals(transactionNo));
			if (outgoingPayment == null) return false;

			outgoingPayment.ApprovalStatus = approvalStatus;
			_dbContext.Update(outgoingPayment);
			await _dbContext.SaveChangesAsync();

			return true;
		}

        #region private service
        private async Task<bool> CreateApprovalWorkflow(DataAccess.Models.OutgoingPayment input, CurrentUserAccessor currentUserAccessor)
		{
			var dataRoleCodes = await _dbContext.UserRoles.Include(ur => ur.Role).Where(d => d.UserId.Equals(currentUserAccessor.Id)).Select(d => d.Role.RoleCode).ToListAsync();
			var workflowRule = await _dbContext.ApprovalRules.AsNoTracking()
				.FirstOrDefaultAsync(x =>
					x.MinAmount <= input.TotalAmount
					&& input.TotalAmount <= x.MaxAmount
					&& x.Level == 1);

			if (workflowRule == null)
				return false;

			var firstRoleApprover = await _dbContext.ApprovalRules.AsNoTracking()
				.FirstOrDefaultAsync(x => x.TransactionTypeCode == input.TransactionTypeCode && x.MinAmount == workflowRule.MinAmount && x.MaxAmount == workflowRule.MaxAmount && x.Level == 2);

			if (firstRoleApprover == null)
				return false;

			var dataInbox = new ApprovalInbox
			{
				ApprovalLevel = 2,
				ApprovalRoleCode = firstRoleApprover.RoleCode,
				ApprovalStatus = ApprovalStatus.WaitingApproval,
				TransactionTypeCode = input.TransactionTypeCode,
				TransactionNo = input.TransactionNo,
				MinAmount = workflowRule.MinAmount,
				MaxAmount = workflowRule.MaxAmount
			};

			await _dbContext.ApprovalInboxes.AddAsync(dataInbox);

			var dataHistory = new ApprovalHistory
			{
				ApprovalLevel = 1,
				ExecutorName = input.Requestor,
				ExecutorRoleCode = string.Empty,
				ExecutorRoleDesc = string.Empty,
				ApprovalStatus = ApprovalStatus.Submitted,
				ApprovalUserId = currentUserAccessor.Id,
				TransactionNo = input.TransactionNo,
				MinAmount = workflowRule.MinAmount,
				MaxAmount = workflowRule.MaxAmount
			};

			await _dbContext.ApprovalHistories.AddAsync(dataHistory);

			return true;
		}

		private async Task<DocNumberConfig> GetRunningNumberDocument(string transactionTypeCode, string companyCode, DateTime date)
		{
            DocNumberConfig? docNumberConfig = null;
			int month = date.Month;
			int year = date.Year;

            docNumberConfig = await _dbContext.DocNumberConfigs
                .FirstOrDefaultAsync(x => x.TransactionTypeCode == transactionTypeCode && x.CompanyCode == companyCode && x.Month == month && x.Year == year);


            if (docNumberConfig == null)
            {
                docNumberConfig = new DocNumberConfig
                {
                    TransactionTypeCode = transactionTypeCode,
                    CompanyCode = companyCode,
                    Month = month,
                    Year = year,
                    RunningNumber = 0
                };

                await _dbContext.DocNumberConfigs.AddAsync(docNumberConfig);
                await _dbContext.SaveChangesAsync();

                return docNumberConfig;
            }
            else
            {
                return docNumberConfig;
            }
        }

        private async Task<DocNumberConfig?> UpdateRunningNumber(Guid idData)
        {
            var docNumberConfig = await _dbContext.DocNumberConfigs
                .FirstOrDefaultAsync(x => x.Id == idData);

            if (docNumberConfig == null)
                return null;

            docNumberConfig.RunningNumber = docNumberConfig.RunningNumber + 1;
            _dbContext.DocNumberConfigs.Update(docNumberConfig);
            await _dbContext.SaveChangesAsync();

            return docNumberConfig;
        }

		private async Task<bool> CancelInboxApproval(DataAccess.Models.OutgoingPayment input, CurrentUserAccessor currentUserAccessor)
		{
			var dataInbox = await _dbContext.ApprovalInboxes.FirstOrDefaultAsync(x => x.TransactionNo == input.TransactionNo);

			if (dataInbox == null)
				return false;

			var dataRole = await _dbContext.UserRoles.Include(x => x.Role).AsNoTracking().FirstOrDefaultAsync(x => x.UserId == currentUserAccessor.Id);

			if (dataRole == null)
				return false;

			dataInbox.ApprovalStatus = ApprovalStatus.Cancelled;
			dataInbox.ApprovalRoleCode = string.Empty;

			_dbContext.Update(dataInbox);


			var dataHistory = new ApprovalHistory
			{
				ApprovalLevel = dataInbox.ApprovalLevel,
				ExecutorName = input.Requestor,
				ExecutorRoleCode = dataRole.Role.RoleCode,
				ExecutorRoleDesc = dataRole.Role.RoleDescription,
				ApprovalStatus = ApprovalStatus.Cancelled,
				ApprovalUserId = currentUserAccessor.Id,
				TransactionNo = input.TransactionNo,
				MinAmount = dataInbox.MinAmount,
				MaxAmount = dataInbox.MaxAmount
			};

			await _dbContext.ApprovalHistories.AddAsync(dataHistory);

			return true;
		}
        #endregion
    }
}
