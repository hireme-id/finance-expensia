using Finance.Expensia.Shared.Objects.Inputs.Interfaces;

namespace Finance.Expensia.Shared.Objects.Inputs
{
    public class PagingInputBase : IPagingInput
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
