using Finance.Expensia.Core.Services.OutgoingPayment.Inputs;
using Finance.Expensia.DataAccess.Models;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Finance.Expensia.Core.Services.OutgoingPayment
{
    public partial class OutgoingPaymentService
    {
        private static (ResponseCode validateInputStatus, string validateInputMessage) ValidateUpsertOutgoingPaymentInput
            (BaseOutgoingPaymentInput? input, List<BaseOutgoingPaymentDetailInput> details)
        {
            if (input == null)
                return (ResponseCode.NotFound, "Tolong lengkapi informasi yang mandatory");

            if (input.ExpectedTransfer == ExpectedTransfer.Scheduled && !input.ScheduledDate.HasValue)
                return (ResponseCode.BadRequest, "Schedule date harus diisi");

            //if (input.ScheduledDate.HasValue && input.ScheduledDate.Value.Date < DateTime.Now.Date)
            //    return (ResponseCode.BadRequest, "Schedule date tidak boleh lebih kecil dari hari ini");

            input.Remark = string.Join(" ", input.Remark.Split(" ", StringSplitOptions.RemoveEmptyEntries));
            if (string.IsNullOrEmpty(input.Remark) || input.Remark.Length <= 10)
                return (ResponseCode.BadRequest, "Remark harus diisi dan minimal 10 huruf");

            if (details.Count == 0 && input.IsSubmit)
                return (ResponseCode.NotFound, "Belum ada data detail");

            return (ResponseCode.Ok, string.Empty);
        }

        private async Task<(
            ResponseCode validateDataStatus, 
            string validateDataMessage,
            Company dataCompany, 
            BankAlias dataFromBankAlias, 
            BankAlias dataToBankAlias, 
            TransactionType dataTransactionType)>
        ValidateUpsertOutgoingPaymentReferenceData(BaseOutgoingPaymentInput input)
        {
            var dataCompany = await _dbContext.Companies.FirstOrDefaultAsync(d => d.Id.Equals(input.CompanyId));
            var dataFromBankAlias = await _dbContext.BankAliases.FirstOrDefaultAsync(d => d.Id.Equals(input.FromBankAliasId) && d.CompanyId.Equals(input.CompanyId));
            var dataToBankAlias = await _dbContext.BankAliases.FirstOrDefaultAsync(d => d.Id.Equals(input.ToBankAliasId));
            var dataTransactionType = await _dbContext.TransactionTypes.FirstOrDefaultAsync(d => d.Id.Equals(input.TransactionTypeId));

            try
            {
                if (dataCompany == null)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data company tidak valid");

                if (dataFromBankAlias == null)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data from bank alias tidak valid");

                if (dataToBankAlias == null)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data to bank alias tidak valid");

                if (dataTransactionType == null)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data to transaction type tidak valid");
            }
            catch (CustomValidationException ex)
            {
                return (ex.Code, ex.Message, null!, null!, null!, null!);
            }

            return (ResponseCode.Ok, string.Empty, dataCompany, dataFromBankAlias, dataToBankAlias, dataTransactionType);
        }

        private async Task<(
            ResponseCode validateDetailDataStatus,
            string validateDetailDataMessage,
            Partner dataPartner,
            ChartOfAccount dataCoa,
            CostCenter? dataCostCenter,
            Company dataPostingAccount)>
        ValidateUpsertOutgoingPaymentReferenceDetailData(BaseOutgoingPaymentDetailInput input, Guid companyId)
        {
            var dataPartner = await _dbContext.Partners.FirstOrDefaultAsync(d => d.Id.Equals(input.PartnerId));
            var dataCoa = await _dbContext.ChartOfAccounts.FirstOrDefaultAsync(d => d.Id.Equals(input.ChartOfAccountId) && d.CompanyId.Equals(companyId));
            var dataCostCenter = await _dbContext.CostCenters.FirstOrDefaultAsync(d => d.Id.Equals(input.CostCenterId) && d.CompanyId.Equals(companyId));
            var dataPostingAccount = await _dbContext.Companies.FirstOrDefaultAsync(d => d.Id.Equals(input.PostingAccountId));

            try
            {
                if (input.InvoiceDate == DateTime.MinValue)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data date tidak valid");

                if (dataPartner == null)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data tenant tidak valid");

                if (string.IsNullOrEmpty(input.Description))
                    throw new CustomValidationException(ResponseCode.NotFound, "Data description tidak valid");

                if (dataCoa == null)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data chart of account tidak valid");

                if (dataPostingAccount == null)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data consumer account tidak valid");

                if (input.Amount <= 0)
                    throw new CustomValidationException(ResponseCode.NotFound, "Data amount tidak valid");
            }
            catch (CustomValidationException ex)
            {
                return (ex.Code, ex.Message, null!, null!, null!, null!);
            }

            return (ResponseCode.Ok, string.Empty, dataPartner, dataCoa, dataCostCenter, dataPostingAccount);
        }
    }
}
