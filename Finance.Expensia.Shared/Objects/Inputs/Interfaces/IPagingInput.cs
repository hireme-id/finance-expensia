namespace Finance.Expensia.Shared.Objects.Inputs.Interfaces
{
    public interface IPagingInput
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
