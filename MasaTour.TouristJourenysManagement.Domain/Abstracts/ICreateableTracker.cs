namespace MasaTour.TouristTripsManagement.Domain.Abstracts;
public interface ICreateableTracker
{
    public DateTime CreatedAt { get; set; }

    public Task CreateAsync()
    {
        CreatedAt = DateTime.Now;
        return Task.CompletedTask;
    }
}
