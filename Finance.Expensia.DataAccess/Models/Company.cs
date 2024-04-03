using Finance.Expensia.DataAccess.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class Company : EntityBase
    {
        public string CompanyName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string  Address { get; set; } = string.Empty;

        public virtual List<BankAlias> BankAliases { get; set; } = [];
        public virtual List<Partner> Partners { get; set; } = [];
        public virtual List<ChartOfAccount> ChartOfAccounts { get; set; } = [];
    }
}
