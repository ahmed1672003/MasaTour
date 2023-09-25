namespace MasaTour.TouristJourenysManagement.Domain.Abstracts;
public interface IUpdateableTracker
{
    public DateTime UpdatedAt { get; set; }

    public Task UpdateAsync()
    {
        UpdatedAt = DateTime.Now;
        return Task.CompletedTask;
    }
}
