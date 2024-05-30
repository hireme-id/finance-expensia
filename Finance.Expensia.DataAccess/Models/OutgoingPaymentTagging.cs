using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
	public class OutgoingPaymentTagging : EntityBase
	{
		public Guid OutgoingPaymentId { get; set; }
		public string TagValue { get; set; } = string.Empty;
		public virtual OutgoingPayment OutgoingPayment { get; set; } = null!;
	}
}
