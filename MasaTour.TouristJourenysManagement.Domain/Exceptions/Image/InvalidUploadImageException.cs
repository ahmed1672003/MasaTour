namespace MasaTour.TouristTripsManagement.Domain.Exceptions.Image;
public sealed class InvalidUploadImageException : Exception
{
    public InvalidUploadImageException() { }
    public InvalidUploadImageException(string message = "Upload Image Failed !") : base(message) { }
    public InvalidUploadImageException(string message, Exception innerException) : base(message, innerException) { }
}
