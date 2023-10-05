namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Mappers;
public sealed class CommentProfile : Profile
{
    public CommentProfile()
    {
        Map();
    }

    void Map()
    {
        CreateMap<AddCommentDto, Comment>();
        CreateMap<Comment, GetCommentDto>()
                .ForMember(dist => dist.CommentId, cfg => cfg.MapFrom(src => src.Id));
    }
}
