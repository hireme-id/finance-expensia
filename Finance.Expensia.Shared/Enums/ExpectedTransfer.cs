using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Shared.Enums
{
    public enum ExpectedTransfer
    {
        [Description("Immediately")]
        Immediately,
        [Description("Approved + 1")]
        ApprovedPlusOne,
        [Description("Scheduled")]
        Scheduled
    }
}
