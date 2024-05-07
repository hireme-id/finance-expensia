namespace Finance.Expensia.Core.Services.Storage.Dtos
{
	public class UploadFileDto
	{
		public Guid FileId { get; set; }
		public string FileName { get; set; } = string.Empty;
		public long FileSize { get; set; }
		public string FileUrl { get; set; } = string.Empty;
		public string ContentType { get; set; } = string.Empty;
	}
}
