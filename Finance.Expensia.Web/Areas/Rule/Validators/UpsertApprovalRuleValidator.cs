using Finance.Expensia.Core.Services.MasterData.Inputs;
using Finance.Expensia.Core.Services.Rule.Inputs;
using FluentValidation;
using static Finance.Expensia.Shared.Constants.MessageConstants;

namespace Finance.Expensia.Web.Areas.Rule.Validators
{
    public class UpsertApprovalRuleValidator : AbstractValidator<UpsertApprovalRuleInput>
    {
        public UpsertApprovalRuleValidator()
        {
            RuleFor(i => i.TransactionTypeCode)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);

            RuleFor(i => i.MaxAmount)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);

            RuleFor(i => i.Level)
                .NotEmpty().WithMessage(ValidatorMessageConstant.FieldRequired);
        }
    }
}
