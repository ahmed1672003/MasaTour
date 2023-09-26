namespace MasaTour.TouristTripsManagement.Domain.Abstracts;
public interface IDeleteableTracker
{
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public Task DeleteAsync()
    {
        IsDeleted = true;
        DeletedAt = DateTime.Now;
        return Task.CompletedTask;
    }

    public Task UndoDeleteAsync()
    {
        IsDeleted = false;
        DeletedAt = null;
        return Task.CompletedTask;
    }
}

