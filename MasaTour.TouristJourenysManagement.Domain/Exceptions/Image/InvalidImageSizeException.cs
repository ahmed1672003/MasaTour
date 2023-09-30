namespace MasaTour.TouristTripsManagement.Domain.Exceptions.Image;
public sealed class InvalidImageSizeException : Exception
{
    public InvalidImageSizeException() { }
    public InvalidImageSizeException(string message = "Invalid Image Size !") : base(message) { }
    public InvalidImageSizeException(string message, Exception innerException) : base(message, innerException) { }
}
