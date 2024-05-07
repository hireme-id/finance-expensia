using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Objects.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance.Expensia.Web.Middlewares
{
    public class TransactionFilter<TApplicationDbContext>(TApplicationDbContext dbContext, ILogger<TransactionFilter<TApplicationDbContext>> logger) : IAsyncActionFilter
        where TApplicationDbContext : DbContext
    {
        private readonly TApplicationDbContext _dbContext = dbContext;
        private readonly ILogger<TransactionFilter<TApplicationDbContext>> _logger = logger;
        private readonly string logPrefix = nameof(TransactionFilter<TApplicationDbContext>);

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // Check if the method has the MutationAttribute
            bool isMutation = context.ActionDescriptor.EndpointMetadata.OfType<MutationAttribute>().Any();
            bool isCustomResponse = context.ActionDescriptor.EndpointMetadata.OfType<CustomResponseAttribute>().Any();

            _logger.LogInformation("{Prefix}: Open transaction scope", logPrefix);
            using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                var resultContext = await next();

                if (resultContext.Result != null && resultContext.Exception == null)
                {
                    if (resultContext.Result is ObjectResult)
                    {
                        var objectResult = (ObjectResult)resultContext.Result;

                        if (objectResult.Value is not ResponseBase && !isCustomResponse)
                        {
                            string errorMessage = "Use ResponseBase or it's inheritance";

                            resultContext.Result = new JsonResult(new ResponseBase(errorMessage, ResponseCode.Error));
                            throw new InvalidOperationException(errorMessage);
                        }

                        if (isMutation && objectResult.Value != null)
                        {
                            if ((objectResult.Value is ResponseBase @base && @base.Succeeded) || objectResult.Value != null)
                            {
                                _logger.LogInformation("{Prefix}: Commit transaction scope", logPrefix);
                                await transaction.CommitAsync();
                            }
                            else
                            {
                                var statusCode = (objectResult.Value is ResponseBase base1) ? base1.Code.ToString() : "400";

                                _logger.LogInformation("{Prefix}: Rollback transaction scope: Status code {StatusCode}", logPrefix, statusCode);
                                await transaction.RollbackAsync();
                            }
                        }
                        else
                        {
                            _logger.LogInformation("{Prefix}: Rollback transaction scope: Because isn't use mutation", logPrefix);
                            await transaction.RollbackAsync();
                        }
                    }
                    else
                    {
                        _logger.LogInformation("{Prefix}: Rollback transaction scope: Because the result isn't ObjectResult", logPrefix);
                        await transaction.RollbackAsync();
                    }
                }
                else
                {
                    _logger.LogInformation("{logPrefix}: Rollback transaction scope: There is no result", logPrefix);
                    await transaction.RollbackAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("{Prefix}: Rollback transaction scope: {Message}", logPrefix, ex.Message);
                await transaction.RollbackAsync();
            }
        }
    }
}
