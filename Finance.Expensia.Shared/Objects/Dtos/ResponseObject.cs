using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.Shared.Objects.Dtos
{
    public class ResponseObject<T>(string? message = null, ResponseCode responseCode = ResponseCode.BadRequest) : ResponseBase(message, responseCode)
        where T : class
    {
        public T? Obj { get; set; }
    }
}
