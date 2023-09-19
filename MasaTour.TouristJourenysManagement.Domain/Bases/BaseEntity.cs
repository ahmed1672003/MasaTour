namespace MasaTour.TouristJourenysManagement.Domain.Base;
public class BaseEntity
{
    public string Id { get; set; }
    public BaseEntity() => Id = Guid.NewGuid().ToString();
}
