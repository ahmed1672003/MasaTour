﻿using Microsoft.EntityFrameworkCore.Storage;

namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class UnitOfWork : IUnitOfWork
{
    private readonly ITouristTripsManagementDbContext _context;
    public UnitOfWork(
        ITouristTripsManagementDbContext context,
        IIdentityRepository identity,
        IRoleClaimRepository roleClaims,
        IRoleRepository roles,
        IUserClaimRepository userClaims,
        IUserJWTRepository userJWTs,
        IUserLoginRepository userLogins,
        IUserRoleMapperRepository userRoleMappers,
        IUserTokenRepository userTokens,
        IUserRepository users,
        ICategoryRepository categories,
        ITripRepository trips,
        ISubCategoryRepository subCategories,
        ITripMandatoryMapperRepository tripsMandatoryMappers,
        IMandatoryRepository mandatories,
        IImageRepository images,
        ITripImageMapperRepository imagesImageMapper,
        ITripPhaseRepository tripPhases,
        ICommentRepository comments,
        ITransporationClassRepository transporationClasses,
        ITransporationRepository transporations)
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
        Users = users;
        Categories = categories;
        Trips = trips;
        SubCategories = subCategories;
        TripsMandatoryMappers = tripsMandatoryMappers;
        Mandatories = mandatories;
        Images = images;
        TripImageMappers = imagesImageMapper;
        TripPhases = tripPhases;
        Comments = comments;
        TransporationClasses = transporationClasses;
        Transporations = transporations;
    }

    public IIdentityRepository Identity { get; }
    public IRoleClaimRepository RoleClaims { get; }
    public IRoleRepository Roles { get; }
    public IUserClaimRepository UserClaims { get; }
    public IUserJWTRepository UserJWTs { get; }
    public IUserLoginRepository UserLogins { get; }
    public IUserRoleMapperRepository UserRoleMappers { get; }
    public IUserTokenRepository UserTokens { get; }
    public IUserRepository Users { get; }
    public ICategoryRepository Categories { get; }
    public ISubCategoryRepository SubCategories { get; }
    public ITripRepository Trips { get; }
    public ITripPhaseRepository TripPhases { get; }
    public ITripMandatoryMapperRepository TripsMandatoryMappers { get; }
    public IMandatoryRepository Mandatories { get; }
    public IImageRepository Images { get; }
    public ICommentRepository Comments { get; }
    public ITripImageMapperRepository TripImageMappers { get; }
    public ITransporationClassRepository TransporationClasses { get; }
    public ITransporationRepository Transporations { get; }
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
