namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Dtos;
public class GetCategoryDto
{
    public string Id { get; set; }
    public string NameAR { get; set; }
    public string NameEN { get; set; }
    public string NameDE { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
