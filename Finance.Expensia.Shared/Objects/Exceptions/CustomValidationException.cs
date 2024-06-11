using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.Shared.Objects.Exceptions
{
    public class CustomValidationException(ResponseCode code, string message) : Exception(message)
    {
        public ResponseCode Code { get; } = code;
    }
}
