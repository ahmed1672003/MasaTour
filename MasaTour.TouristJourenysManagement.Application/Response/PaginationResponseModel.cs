using System.Net;

namespace MasaTour.TouristJourenysManagement.Application.Response;
public sealed class PaginationResponseModel<TData> : ResponseModel<TData>
{
    public PaginationResponseModel(
       HttpStatusCode statusCode = default,
       bool isSucceeded = default,
       TData? data = default,
       object meta = default,
       string message = default,
       object errors = default,
       int count = 0,
       int currentPage = 1,
       int pageSize = 10
       ) : base(statusCode, isSucceeded, data, meta, message, errors)
    {
        PageSize = pageSize;
        TotalCount = count;
        CurrentPage = currentPage;
    }
    public int PageSize { get; set; }
    public int CurrentPage { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages => Convert.ToInt32(Math.Ceiling(TotalCount / Convert.ToDecimal(PageSize)));
    public bool MoveNext => CurrentPage < TotalPages;
    public bool MovePrevious => CurrentPage > 1;
}
