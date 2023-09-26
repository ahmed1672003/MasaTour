using System.Net;

namespace MasaTour.TouristTripsManagement.Application.Response;
public class ResponseModel<TData>
{
    public ResponseModel(
        HttpStatusCode statusCode = default,
        bool isSucceeded = default,
        TData? data = default,
        object meta = default,
        string message = default,
        object errors = default)
    {
        StatusCode = statusCode;
        IsSucceeded = isSucceeded;
        Data = data;
        Meta = meta;
        Message = message;
        Errors = errors;
    }
    public HttpStatusCode StatusCode { get; set; }
    public bool IsSucceeded { get; set; }
    public string Message { get; set; }
    public object Errors { get; set; }
    public object Meta { get; set; }
    public TData? Data { get; set; }
}
