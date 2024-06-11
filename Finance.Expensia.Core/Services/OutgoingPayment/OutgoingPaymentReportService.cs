using Finance.Expensia.Core.Services.OutgoingPayment.Dtos;
using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Shared.Objects;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.Reflection;

namespace Finance.Expensia.Core.Services.OutgoingPayment
{
    public partial class OutgoingPaymentService
    {
        public async Task<ResponseObject<List<GetDownloadOutgoingPaymentDto>>> GetListDownloadOutgoingPayment(DownloadOutgoingPaymentInput input,
            CurrentUserAccessor currentUserAccessor)
        {
            var queryOutgoingPayments = _dbContext.OutgoingPayments
                                                  .Include(x => x.OutgoingPaymentDetails.OrderBy(d => d.Created))
                                                  .Where(d => d.RequestDate >= input.StartDate)
                                                  .Where(d => d.RequestDate <= input.EndDate);

            if (!currentUserAccessor.Permissions!.Any(d => d == PermissionConstants.OutgoingPayment.OutgoingPaymentView))
            {
                queryOutgoingPayments = queryOutgoingPayments.Where(d => EF.Functions.Like(d.CreatedBy, $"{currentUserAccessor.Id}"));
            }

            var dataOutgoingPayments = await queryOutgoingPayments.OrderByDescending(d => d.Modified ?? d.Created)
                                                                  .Select(d => _mapper.Map<DownloadOutgoingPaymentDto>(d))
                                                                  .ToListAsync();

            var processedData = dataOutgoingPayments.SelectMany(o => o.OutgoingPaymentDetails.DefaultIfEmpty(), (o, d) => new GetDownloadOutgoingPaymentDto
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
            var workbook = new XSSFWorkbook();
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
            string[] headers = ["No", .. propertyNames];

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
                        if (value.IsNullOrEmpty())
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

            using var exportData = new MemoryStream();
            workbook.Write(exportData);
            return exportData.ToArray();
        }
    }
}
