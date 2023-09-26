using System.Net;

namespace MasaTour.TouristTripsManagement.Application.Response;
public sealed class PaginationResponseResult
{
    public static PaginationResponseModel<TData> Success<TData>(TData data = null, object meta = null, string message = null, object errors = null, int count = 0, int currentPage = 1, int pageSize = 10)
        where TData : class =>
        new(statusCode: HttpStatusCode.OK,
            isSucceeded: true, message: message, data: data,
            errors: errors, meta: meta, count: count, currentPage: currentPage, pageSize: pageSize);

    public static PaginationResponseModel<TData> NotFound<TData>(TData data = null, object meta = null, string message = null, object errors = null, int count = 0, int currentPage = 1, int pageSize = 10)
        where TData : class =>
        new(statusCode: HttpStatusCode.NotFound, isSucceeded: false, message: message, data: data, errors: errors, meta: meta, count: count, currentPage: currentPage, pageSize: pageSize);
    public static PaginationResponseModel<TData> Conflict<TData>(TData data = null, object meta = null, string message = null, object errors = null, int count = 0, int currentPage = 1, int pageSize = 10)
    where TData : class => new(statusCode: HttpStatusCode.Conflict, isSucceeded: false, message: message, data: data, errors: errors, meta: meta, count: count, currentPage: currentPage, pageSize: pageSize);

    public static PaginationResponseModel<TData> BadRequest<TData>(TData data = null, object meta = null, string message = null, object errors = null, int count = 0, int currentPage = 1, int pageSize = 10)
        where TData : class =>
        new(statusCode: HttpStatusCode.BadRequest, isSucceeded: false, message: message, data: data, errors: errors, meta: meta, count: count, currentPage: currentPage, pageSize: pageSize);
    public static PaginationResponseModel<TData> InternalServerError<TData>(TData data = null, object meta = null, string message = null, object errors = null, int count = 0, int currentPage = 1, int pageSize = 10)
        where TData : class =>
        new(statusCode: HttpStatusCode.InternalServerError, isSucceeded: false, message: message, data: data, errors: errors, meta: meta, count: count, currentPage: currentPage, pageSize: pageSize);

}
