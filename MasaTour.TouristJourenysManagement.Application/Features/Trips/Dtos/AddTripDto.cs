namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
public class AddTripDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string Code { get; set; }

    [Required]
    [MaxLength(255)]
    public string NameAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string NameEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string NameDE { get; set; }

    [MaxLength(3000)]
    public string? LongDesceiptionAR { get; set; }

    [MaxLength(3000)]
    public string? LongDesceiptionEN { get; set; }

    [MaxLength(3000)]
    public string? LongDesceiptionDE { get; set; }

    [Required]
    [MaxLength(1500)]
    public string MiniDesceiptionAR { get; set; }

    [Required]
    [MaxLength(1500)]
    public string MiniDesceiptionEN { get; set; }

    [Required]
    [MaxLength(1500)]
    public string MiniDesceiptionDE { get; set; }

    [Required]
    [MaxLength(255)]
    public string FromAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string FromEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string FromDE { get; set; }

    [Required]
    [MaxLength(255)]
    public string ToAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string ToEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string ToDE { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }

    [Required]
    public decimal PriceEGP { get; set; }

    [Required]
    public decimal PriceUSD { get; set; }

    [Required]
    public decimal PriceGBP { get; set; }

    [Required]
    public decimal PriceEUR { get; set; }

    [Required]
    public bool IsFamous { get; set; }


    [Required]
    public bool IsActive { get; set; }


    [Required]
    public bool IsDeleted { get; set; }

}
