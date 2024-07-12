using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Core.Services.Rule.Inputs
{
    public class UpsertApprovalRuleInput
    {
        public Guid? Id { get; set; }
        public string TransactionTypeCode { get; set; } = string.Empty;
        public decimal MinAmount { get; set; }
        public decimal MaxAmount { get; set; }
        public int Level { get; set; }
        public string RoleCode { get; set; } = string.Empty;
    }
}
