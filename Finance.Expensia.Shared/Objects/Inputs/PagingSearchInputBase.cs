using Finance.Expensia.Shared.Objects.Inputs.Interfaces;

namespace Finance.Expensia.Shared.Objects.Inputs
{
    public class PagingSearchInputBase : IPagingInput, ISearchInput
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchKey { get; set; }
    }
}
