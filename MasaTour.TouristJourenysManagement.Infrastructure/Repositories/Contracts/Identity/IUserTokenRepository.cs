using MasaTour.TouristJourenysManagement.Infrastructure.Liftimes;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;
public interface IUserTokenRepository : IRepository<UserToken>, ITransientLifetime
{
}
