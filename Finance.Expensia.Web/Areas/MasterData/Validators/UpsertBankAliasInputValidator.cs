using Finance.Expensia.Core.Services.MasterData.Inputs;
using FluentValidation;
using static Finance.Expensia.Shared.Constants.MessageConstants;

namespace Finance.Expensia.Web.Areas.MasterData.Validators
{
    public class UpsertBankAliasInputValidator : AbstractValidator<UpsertBankAliasInput>
    {
        public UpsertBankAliasInputValidator()
        {
            RuleFor(i => i.AliasName)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);

            RuleFor(i => i.BankName)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);

            RuleFor(i => i.AccountNo)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);

            RuleFor(i => i.AccountName)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);
        }
    }
}
