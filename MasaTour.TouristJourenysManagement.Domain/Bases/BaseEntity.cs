using System.ComponentModel.DataAnnotations;

namespace MasaTour.TouristJourenysManagement.Domain.Base;
public class BaseEntity
{
    [Required]
    [MaxLength(36)]
    public string Id { get; set; }
    public BaseEntity() => Id = Guid.NewGuid().ToString();
}
