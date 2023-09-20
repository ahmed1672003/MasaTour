using MasaTour.TouristJourenysManagement.Infrastructure.Liftimes;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;
public interface IUserRepository : IRepository<User>, ITransientLifetime
{
}
