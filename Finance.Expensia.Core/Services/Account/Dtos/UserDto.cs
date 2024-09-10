using Finance.Expensia.Core.Services.Account.BaseClasses;

namespace Finance.Expensia.Core.Services.Account.Dtos
{
    public class UserDto : UserBase
    {
        public string Username { get; set; } = string.Empty;
    }
}
