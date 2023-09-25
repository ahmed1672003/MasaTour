using System.Net;

namespace MasaTour.TouristJourenysManagement.Application.Response;
public sealed class ResponseResult
{
    public static ResponseModel<TData> Success<TData>(TData data = null, object meta = null, string message = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.OK, isSucceeded: true, message: message, data: data, errors: errors, meta: meta);

    public static ResponseModel<TData> Created<TData>(TData data = null, object meta = null, string message = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.Created, isSucceeded: true, message: message, data: data, errors: errors, meta: meta);

    public static ResponseModel<TData> NotFound<TData>(TData data = null, object meta = null, string message = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.NotFound, isSucceeded: true, message: message, data: data, errors: errors, meta: meta);

    public static ResponseModel<TData> BadRequest<TData>(TData data = null, object meta = null, string message = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.BadRequest, isSucceeded: false, message: message, data: data, errors: errors, meta: meta);

    public static ResponseModel<TData> UnAuthorized<TData>(TData data = null, object meta = null, string message = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.Unauthorized, isSucceeded: false, message: message, data: data, errors: errors, meta: meta);

    public static ResponseModel<TData> InternalServerError<TData>(TData data = null, object meta = null, string message = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.InternalServerError, isSucceeded: false, message: message, data: data, errors: errors, meta: meta);

    public static ResponseModel<TData> Conflict<TData>(TData data = null, object meta = null, string message = null, object errors = null)
        where TData : class => new(statusCode: HttpStatusCode.Conflict, isSucceeded: false, message: message, data: data, errors: errors, meta: meta);
}
