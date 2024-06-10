using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
	public partial class Company : EntityBase
	{
		public string CompanyCode { get; set; } = string.Empty;
		public string CompanyName { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Address { get; set; } = string.Empty;

		public virtual List<BankAlias> BankAliases { get; set; } = [];
		public virtual List<ChartOfAccount> ChartOfAccounts { get; set; } = [];
		public virtual List<CostCenter> CostCenters { get; set; } = [];
		public virtual List<OutgoingPaymentDetail> OutgoingPaymentDetails { get; set; } = [];
		public virtual List<UserCompany> UserCompanies { get; set; } = [];
	}
}
