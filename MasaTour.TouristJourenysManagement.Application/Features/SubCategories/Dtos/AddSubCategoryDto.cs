namespace MasaTour.TouristTripsManagement.Application.Features.SubCategories.Dtos;
public class AddSubCategoryDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledCanNotBeNull)]
    [MaxLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledLengthIsSmallerThanMinLength)]
    public string CategoryId { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledLengthIsSmallerThanMinLength)]
    public string NameAR { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledLengthIsSmallerThanMinLength)]
    public string NameEN { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(3, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.SubCategory.FiledLengthIsSmallerThanMinLength)]
    public string NameDE { get; set; }
}
