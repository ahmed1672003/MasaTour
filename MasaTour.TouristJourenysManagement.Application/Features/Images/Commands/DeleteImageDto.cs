namespace MasaTour.TouristTripsManagement.Application.Features.Images.Commands;
public class DeleteImageDto
{
    [Required]
    [MaxLength(36)]
    [MinLength(36)]
    public string ImageId { get; set; }

    [Required]
    public string ImagePath { get; set; }
}
