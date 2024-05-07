using Finance.Expensia.Core.Services.Storage;
using Finance.Expensia.Core.Services.Storage.Dtos;
using Finance.Expensia.Core.Services.Storage.Inputs;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
	[Route("[controller]")]
	public class StorageController(StorageService storageService, IWebHostEnvironment webHostEnvironment) : BaseController
	{
		private readonly StorageService _storageService = storageService;
		private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

		[HttpPost("upload")]
		[AppAuthorize(PermissionConstants.Storage.StorageUpload)]
		public async Task<ResponseObject<UploadFileDto>> UploadFile([FromForm] IFormFile file)
		{
			return await _storageService.UploadFileAsync(file);
		}

		[HttpPost("download")]
		[AppAuthorize(PermissionConstants.Storage.StorageDownload)]
		public IActionResult DownloadFile([FromBody] DownloadFileInput input)
		{
			//_webHostEnvironment.Root

			return PhysicalFile(Path.Combine(_webHostEnvironment.ContentRootPath, input.FileUrl), input.ContentType, input.FileName);
		}
	}
}