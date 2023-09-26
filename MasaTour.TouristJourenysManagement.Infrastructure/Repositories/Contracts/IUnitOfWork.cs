using Microsoft.EntityFrameworkCore.Storage;

namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories.Contracts;
public interface IUnitOfWork : IAsyncDisposable
{
    IIdentityRepository Identity { get; }
    IUserRepository Users { get; }
    IRoleClaimRepository RoleClaims { get; }
    IRoleRepository Roles { get; }
    IUserClaimRepository UserClaims { get; }
    IUserJWTRepository UserJWTs { get; }
    IUserLoginRepository UserLogins { get; }
    IUserRoleMapperRepository UserRoleMappers { get; }
    IUserTokenRepository UserTokens { get; }
    ICategoryRepository Categories { get; }
    ITripRepository Trips { get; }
    ICategoriesTripsMapperRepository CategoriesTripsMappers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task CommitTransactionAsync(CancellationToken cancellationToken = default);
    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
}
