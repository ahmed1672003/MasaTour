using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts;
public interface IUnitOfWork : IAsyncDisposable, ITransientLifetime
{
    IIdentityRepository Identity { get; }
    IRoleClaimRepository RoleClaims { get; }
    IRoleRepository Roles { get; }
    IUserClaimRepository UserClaims { get; }
    IUserJWTRepository UserJWTs { get; }
    IUserLoginRepository UserLogins { get; }
    IUserRoleMapperRepository UserRoleMappers { get; }
    IUserTokenRepository UserTokens { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
