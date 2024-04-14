using AutoMapper;
using Finance.Expensia.Core.Services.Storage.Dtos;
using Finance.Expensia.DataAccess;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Finance.Expensia.Core.Services.Storage
{
	public class StorageService(ApplicationDbContext dbContext, IMapper mapper, ILogger<StorageService> logger, IOptions<StorageConfig> storageConfig)
		: BaseService<StorageService>(dbContext, mapper, logger)
	{
		private readonly StorageConfig _storageConfig = storageConfig.Value;

		public async Task<ResponseObject<UploadFileDto>> UploadFileAsync(IFormFile file)
		{
			try
			{
				if (file.Length > 1000000)
					return new ResponseObject<UploadFileDto>("File yang diupload tidak boleh lebih dari 1MB", ResponseCode.Error);

				var uploadFileDto = new UploadFileDto
				{
					FileId = Guid.NewGuid(),
					FileName = file.FileName,
					ContentType = file.ContentType,
					FileSize = file.Length,
				};

				var uniqueFileName = uploadFileDto.FileId.ToString();

				if (!Directory.Exists(_storageConfig.UploadFileLocation))
				{
					Directory.CreateDirectory(_storageConfig.UploadFileLocation);
				}

				uploadFileDto.FileUrl = Path.Combine(_storageConfig.UploadFileLocation, uniqueFileName);

				// Save file to disk
				using (FileStream stream = new(uploadFileDto.FileUrl, FileMode.Create))
				{
					await file.CopyToAsync(stream);
				}

				return new ResponseObject<UploadFileDto>(responseCode: ResponseCode.Ok)
				{
					Obj = uploadFileDto
				};
			}
			catch
			{
				return new ResponseObject<UploadFileDto>("File tidak berhasil diupload", responseCode: ResponseCode.Error);
			}
		}
	}
}
