
namespace MasaTour.TouristTripsManagement.Domain.Base;

[NotMapped]
public class BaseEntity
{
    [Required]
    [MaxLength(36)]
    public string Id { get; set; }
    public BaseEntity() => Id = Guid.NewGuid().ToString();
}
