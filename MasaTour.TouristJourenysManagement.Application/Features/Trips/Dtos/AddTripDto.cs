﻿using MasaTour.TouristTripsManagement.Application.Features.TripPhases.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Dtos;
public class AddTripDto
{
    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    [MinLength(36, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsSmallerThanMinLength)]
    public string SubCategoryId { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public double Rate { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string Code { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string NameAR { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string NameEN { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string NameDE { get; set; }

    [MaxLength(3000, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string? LongDescriptionAR { get; set; }

    [MaxLength(3000, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string? LongDescriptionEN { get; set; }

    [MaxLength(3000, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string? LongDescriptionDE { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]

    public string MiniDescriptionAR { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string MiniDescriptionEN { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(1500, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string MiniDescriptionDE { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string FromAR { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string FromEN { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string FromDE { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string ToAR { get; set; }


    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string ToEN { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    [MaxLength(255, ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledLengthIsBiggerThanMaxLength)]
    public string ToDE { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public DateTime StartDate { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public DateTime EndDate { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public decimal PriceEGP { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public decimal PriceUSD { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public decimal PriceGBP { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public decimal PriceEUR { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public bool IsFamous { get; set; }

    [Required(ErrorMessageResourceType = typeof(SharedResources), ErrorMessageResourceName = ResourcesKeys.Trip.FiledCanNotBeNull)]
    public bool IsActive { get; set; }

    public List<AddTripPhaseDto>? TripPhases { get; set; } = new(0);

    public List<AddTripImageDto>? TripImages { get; set; } = new(0);

    public List<string>? MandatoriesIds { get; set; } = new(0);
}
