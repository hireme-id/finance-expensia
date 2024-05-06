using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Core.Services.MasterData.Inputs
{
    public class UpsertPartnerInput
    {
        public Guid? Id { get; set; }
        public string PartnerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
