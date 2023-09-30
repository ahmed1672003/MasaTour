namespace MasaTour.TouristTripsManagement.Domain.Exceptions.Image;
public class InvalidDeleteImageException : Exception
{
    public InvalidDeleteImageException() { }
    public InvalidDeleteImageException(string message = "Upload Image Failed !") : base(message) { }
    public InvalidDeleteImageException(string message, Exception innerException) : base(message, innerException) { }
}
