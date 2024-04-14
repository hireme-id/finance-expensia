namespace Finance.Expensia.Core.Services.Storage.Inputs
{
    public class DownloadFileInput
    {
        public string FileName { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
    }
}
