﻿using Finance.Expensia.DataAccess.Bases;

namespace Finance.Expensia.DataAccess.Models
{
    public partial class Partner : EntityBase
    {
        public string PartnerName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
