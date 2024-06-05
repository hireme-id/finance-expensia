using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Core.Services.OutgoingPayment.Inputs
{
	public class DownloadOutgoingPaymentInput
	{
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
	}
}
