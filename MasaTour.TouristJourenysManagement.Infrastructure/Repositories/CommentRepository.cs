namespace MasaTour.TouristTripsManagement.Infrastructure.Repositories;
public sealed class CommentRepository : Repository<Comment>, ICommentRepository
{
    public CommentRepository(ITouristTripsManagementDbContext context) : base(context) { }
}
