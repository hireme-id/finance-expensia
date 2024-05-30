using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
	public class AppConfig : EntityBase
	{
		public string Key { get; set; } = string.Empty;
		public string Value { get; set; } = string.Empty;
		public string Modul { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
	}
}
