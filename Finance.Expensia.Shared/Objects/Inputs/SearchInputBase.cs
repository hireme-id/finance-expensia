using Finance.Expensia.Shared.Objects.Inputs.Interfaces;

namespace Finance.Expensia.Shared.Objects.Inputs
{
    public class SearchInputBase : ISearchInput
    {
        public string? SearchKey { get; set; }
    }
}
