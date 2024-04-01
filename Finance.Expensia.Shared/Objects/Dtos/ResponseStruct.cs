using Finance.Expensia.Shared.Enums;

namespace Finance.Expensia.Shared.Objects.Dtos
{
    public class ResponseStruct<T>(string? message = null, ResponseCode responseCode = ResponseCode.BadRequest) : ResponseBase(message, responseCode)
        where T : struct
    {
        public T? Obj { get; set; }
    }
}
