using Finance.Expensia.Core.Services.MasterData;
using Finance.Expensia.Core.Services.MasterData.Dtos;
using Finance.Expensia.Shared.Attributes;
using Finance.Expensia.Shared.Constants;
using Finance.Expensia.Shared.Objects.Dtos;
using Finance.Expensia.Web.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Expensia.Web.Areas.MasterData.Controllers
{
    public class TransactionTypeController(TransactionTypeService transactionTypeService) : BaseController
    {
        private readonly TransactionTypeService _transactionTypeService = transactionTypeService;

        [HttpPost("ddltransactiontype")]
        [AppAuthorize(PermissionConstants.MasterData.TransactionTypeView)]
        public async Task<ResponseObject<List<TransactionTypeDto>>> RetrieveTransactionTypeDatas()
        {
            return await _transactionTypeService.RetrieveTransactionTypeDatas();
        }
    }
}
