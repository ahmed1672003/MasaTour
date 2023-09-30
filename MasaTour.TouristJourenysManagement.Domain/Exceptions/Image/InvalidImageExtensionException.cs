namespace MasaTour.TouristTripsManagement.Domain.Exceptions.Image;
public sealed class InvalidImageExtensionException : Exception
{
    public InvalidImageExtensionException() { }
    public InvalidImageExtensionException(string message = "Invalid Image Extension !") : base(message) { }
    public InvalidImageExtensionException(string message, Exception innerException) : base(message, innerException) { }
}