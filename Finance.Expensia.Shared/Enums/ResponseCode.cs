using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Expensia.Shared.Enums
{
    public enum ResponseCode
    {
        Ok = 200,
        BadRequest = 400,
        UnAuthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        TimeOut = 408,
        Error = 500
    }
}
