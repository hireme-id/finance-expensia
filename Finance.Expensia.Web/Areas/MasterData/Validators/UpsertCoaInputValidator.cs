using Finance.Expensia.Core.Services.MasterData.Inputs;
using FluentValidation;
using static Finance.Expensia.Shared.Constants.MessageConstants;

namespace Finance.Expensia.Web.Areas.MasterData.Validators
{
    public class UpsertCoaInputValidator : AbstractValidator<UpsertCoaInput>
    {
        public UpsertCoaInputValidator()
        {
            RuleFor(i => i.CompanyId)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);

            RuleFor(i => i.AccountCode)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);

            RuleFor(i => i.AccountName)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);

            RuleFor(i => i.AccountType)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);
        }
    }
}
