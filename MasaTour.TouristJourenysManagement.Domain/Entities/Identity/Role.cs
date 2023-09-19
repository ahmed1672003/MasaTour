namespace MasaTour.TouristJourenysManagement.Domain.Entities.Identity;
public class Role : IdentityRole<string>
{
    public override string Id { get; set; } = Guid.NewGuid().ToString();
    public override string Name { get; set; }
}
