namespace MasaTour.TouristTripsManagement.Application.Features.Comments.Dtos;
public class UpdateCommentDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Comment.FiledCanNotBeNull)]
    [MaxLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Comment.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Comment.FiledLengthIsSmallerThanMinLength)]
    public string CommentId { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Comment.FiledCanNotBeNull)]
    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Comment.FiledLengthIsBiggerThanMaxLength)]
    public string Content { get; set; }
}
