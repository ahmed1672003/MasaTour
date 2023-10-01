using MasaTour.TouristTripsManagement.Domain.Abstracts;
namespace MasaTour.TouristTripsManagement.Domain.Entities;

[PrimaryKey(nameof(Id))]
public class TripPhase : BaseEntity, ICreateableTracker, IDeleteableTracker, IUpdateableTracker
{
    [Required]
    public int PhaseNumber { get; set; }

    [Required]
    [MaxLength(255)]
    public string LocationNameAR { get; set; }

    [Required]
    [MaxLength(255)]
    public string LocationNameEN { get; set; }

    [Required]
    [MaxLength(255)]
    public string LocationNameDE { get; set; }


    [NotMapped]
    public int FromHours { private get; set; }

    [NotMapped]
    public int FromMinutes { private get; set; }

    [NotMapped]
    public int ToHours { private get; set; }

    [NotMapped]
    public int ToMinutes { private get; set; }

    [Required]
    public TimeSpan FromClock { get; set; } //  year     , days    ,  Hours    , Minutes   , seconds

    [Required]
    public TimeSpan ToClock { get; set; }

    [MaxLength(255)]
    public string FromTimeAR { get; set; }

    [MaxLength(255)]
    public string FromTimeEN { get; set; }

    [MaxLength(255)]
    public string FromTimeDE { get; set; }

    [MaxLength(255)]
    public string ToTimeAR { get; set; }

    [MaxLength(255)]
    public string ToTimeEN { get; set; }

    [MaxLength(255)]
    public string ToTimeDE { get; set; }

    [MaxLength(3000)]
    public string? DesceiptionAR { get; set; }

    [MaxLength(3000)]
    public string? DesceiptionEN { get; set; }

    [MaxLength(3000)]
    public string? DesceiptionDE { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    [MaxLength(36)]
    [MinLength(36)]
    public string TripId { get; set; }

    [ForeignKey(nameof(TripId))]
    public Trip Trip { get; set; }
    public TripPhase()
    {
        FromClock = new TimeSpan(FromHours, FromMinutes, 0);
        ToClock = new TimeSpan(ToHours, ToMinutes, 0);
    }
}
