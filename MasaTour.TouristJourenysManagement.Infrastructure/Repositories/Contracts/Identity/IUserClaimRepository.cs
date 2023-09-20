using MasaTour.TouristJourenysManagement.Infrastructure.Liftimes;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;
public interface IUserClaimRepository : IRepository<UserClaim>, ITransientLifetime
{
}
