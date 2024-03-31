using Finance.Expensia.Shared.Enums;
using Finance.Expensia.Shared.Helpers;

namespace Finance.Expensia.Shared.Objects.Dtos
{
    public class ResponsePaging<T>(string? message = null, ResponseCode responseCode = ResponseCode.BadRequest) : ResponseBase(message, responseCode)
        where T : class
    {
        public IQueryable<T>? Data { get; set; }
        public int Page { get; internal set; }
        public int PageSize { get; internal set; }
        public int TotalPage { get; internal set; }
        public int RecordsFiltered { get; internal set; }
        public int RecordsTotal { get; internal set; }
        public bool HasNext => Page < TotalPage && TotalPage > 1;
        public bool HasPrevious => Page > 1;

        public void ApplyPagination(int page, int pageSize, IQueryable<T> obj, string? message = null)
        {
            Page = page;
            PageSize = pageSize;
            RecordsFiltered = obj.Count();
            RecordsTotal = obj.Count();
            TotalPage = PagingHelper.CalculateTotalPage(RecordsTotal, PageSize);
            Data = obj.PaginateQuery(Page, pageSize);

            OK(message);
        }
    }
}
