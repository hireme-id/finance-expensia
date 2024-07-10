using Finance.Expensia.DataAccess.Models;

namespace Finance.Expensia.Core.Services.MasterData.Dtos
{
    public class CoaDto
	{
        public Guid CoaId { get; set; }
		public string AccountCode { get; set; } = string.Empty;
		public string AccountName { get; set; } = string.Empty;
		public string AccountType { get; set; } = string.Empty;
		public Guid CompanyId { get; set; }
        public virtual CompanyDto Company { get; set; } = null!;
    }
}
