using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Core.Services.Account.Inputs
{
    public class LoginInput
    {
        public required string Username { get; set; }
        public required string FullName { get; set; }
        public required string PhotoUrl { get; set; }
    }
}
