using System.ComponentModel;
using System.Runtime.Serialization;

namespace Finance.Expensia.Shared.Enums
{
	public enum NonTaxableIncome
    {
        [EnumMember(Value = "TK/0")]
        [Description("Tidak kawin tanpa tanggungan")]
        TK0,
        [EnumMember(Value = "TK/1")]
        [Description("Tidak kawin dengan 1 tanggungan")]
        TK1,
        [EnumMember(Value = "TK/2")]
        [Description("Tidak kawin dengan 2 tanggungan")]
        TK2,
        [EnumMember(Value = "TK/3")]
        [Description("Tidak kawin dengan 3 tanggungan")]
        TK3,
        [EnumMember(Value = "K/0")]
        [Description("Kawin tanpa tanggungan")]
        K0,
        [EnumMember(Value = "K/1")]
        [Description("Kawin dengan 1 tanggungan")]
        K1,
        [EnumMember(Value = "K/2")]
        [Description("Kawin dengan 2 tanggungan")]
        K2,
        [EnumMember(Value = "K/3")]
        [Description("Kawin dengan 3 tanggungan")]
        K3
    }
}
