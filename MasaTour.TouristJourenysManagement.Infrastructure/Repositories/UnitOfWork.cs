using MasaTour.TouristJourenysManagement.Infrastructure.Repositories.Contracts.Identity;
using Microsoft.EntityFrameworkCore.Storage;

namespace MasaTour.TouristJourenysManagement.Infrastructure.Repositories;
public class UnitOfWork : IUnitOfWork
{
    private readonly ITouristJourenysManagementDbContext _context;
    public UnitOfWork(
        ITouristJourenysManagementDbContext context,
        IIdentityRepository identity,
        IRoleClaimRepository roleClaims,
        IRoleRepository roles,
        IUserClaimRepository userClaims,
        IUserJWTRepository userJWTs,
        IUserLoginRepository userLogins,
        IUserRoleMapperRepository userRoleMappers,
        IUserTokenRepository userTokens)
    {
        _context = context;
        Identity = identity;
        RoleClaims = roleClaims;
        Roles = roles;
        UserClaims = userClaims;
        UserJWTs = userJWTs;
        UserLogins = userLogins;
        UserRoleMappers = userRoleMappers;
        UserTokens = userTokens;
    }

    public IIdentityRepository Identity { get; }
    public IRoleClaimRepository RoleClaims { get; }
    public IRoleRepository Roles { get; }
    public IUserClaimRepository UserClaims { get; }
    public IUserJWTRepository UserJWTs { get; }
    public IUserLoginRepository UserLogins { get; }
    public IUserRoleMapperRepository UserRoleMappers { get; }
    public IUserTokenRepository UserTokens { get; }

    public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default) =>
         await _context.Database.BeginTransactionAsync(cancellationToken);

    public async Task CommitTransactionAsync(CancellationToken cancellationToken = default) =>
        await _context.Database.CommitTransactionAsync(cancellationToken);

    public async ValueTask DisposeAsync() =>
        await _context.DisposeAsync();

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default) =>
        await _context.Database.RollbackTransactionAsync(cancellationToken);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
         await _context.SaveChangesAsync(cancellationToken);
}
