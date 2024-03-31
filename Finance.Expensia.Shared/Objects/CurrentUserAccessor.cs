namespace Finance.Expensia.Shared.Objects
{
    public class CurrentUserAccessor
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public IEnumerable<string>? Permissions { get; set; }
    }
}
