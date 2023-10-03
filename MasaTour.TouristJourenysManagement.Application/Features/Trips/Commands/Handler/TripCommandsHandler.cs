using MasaTour.TouristTripsManagement.Infrastructure.Specifications.Images;
using MasaTour.TouristTripsManagement.Infrastructure.Specifications.SubCategories;
using MasaTour.TouristTripsManagement.Infrastructure.Specifications.TripImagesMappers;

namespace MasaTour.TouristTripsManagement.Application.Features.Trips.Commands.Handler;
public sealed class TripCommandsHandler :
    IRequestHandler<AddTripCommand, ResponseModel<GetTripDto>>,
    IRequestHandler<UpdateTripCommand, ResponseModel<GetTripDto>>,
    IRequestHandler<DeleteTripByIdCommand, ResponseModel<GetTripDto>>,
    IRequestHandler<UndoDeleteTripByIdCommand, ResponseModel<GetTripDto>>,
    IRequestHandler<DeleteImagesFromTripCommand, ResponseModel<GetTripDto>>
{
    #region Fields
    private readonly IUnitOfWork _context;
    private readonly ISpecificationsFactory _specificationsFactory;
    private readonly IStringLocalizer<SharedResources> _stringLocalizer;
    private readonly IMapper _mapper;
    #endregion

    #region Ctor
    public TripCommandsHandler(
    IUnitOfWork context,
    ISpecificationsFactory specificationsFactory,
    IStringLocalizer<SharedResources> stringLocalizer
,
    IMapper mapper)
    {
        _context = context;
        _specificationsFactory = specificationsFactory;
        _stringLocalizer = stringLocalizer;
        _mapper = mapper;
    }
    #endregion

    #region Add Trip
    public async Task<ResponseModel<GetTripDto>> Handle(AddTripCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetTripByCodeSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByCodeSpecification), request.dto.Code);
            if (await _context.Trips.AnyAsync(asNoTrackingGetTripByCodeSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingGetTripByNameARSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByNameARSpecification), request.dto.NameAR);
            if (await _context.Trips.AnyAsync(asNoTrackingGetTripByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingGetTripByNameENSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByNameENSpecification), request.dto.NameEN);
            if (await _context.Trips.AnyAsync(asNoTrackingGetTripByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingGetTripByNameDESpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByNameDESpecification), request.dto.NameDE);
            if (await _context.Trips.AnyAsync(asNoTrackingGetTripByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            // check sub category
            ISpecification<SubCategory> asNoTrackingGetCategoryByIdSpecification = _specificationsFactory.CreateSubCategorySpecifications(typeof(AsNoTrackingGetSubCategoryByIdSpecification), request.dto.SubCategoryId);
            if (!await _context.SubCategories.AnyAsync(asNoTrackingGetCategoryByIdSpecification, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            foreach (var img in request.dto.TripImages)
            {
                ISpecification<Image> asNoTrackingGetImageByIdSpec = _specificationsFactory.CreateImageSpecifications(typeof(AsNoTrackingGetImageByIdSpecification), img.ImageId);
                if (!await _context.Images.AnyAsync(asNoTrackingGetImageByIdSpec, cancellationToken))
                    return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);
            }


            Trip trip = _mapper.Map<Trip>(request.dto);


            // Add Mandatories to Trip
            request.dto.MandatoriesIds.ForEach(mandatoryId =>
            {
                trip.TripMandatoryMappers.Add(new TripMandatoryMapper()
                {
                    MandatoryId = mandatoryId,
                });
            });

            // Add Images to Trip
            request.dto.TripImages.ForEach(image =>
            {
                trip.TripImageMappers.Add(new()
                {
                    ImageId = image.ImageId,
                    IsCover = image.IsCover,
                });
            });

            // Add Trip
            await _context.Trips.CreateAsync(trip, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            return ResponseResult.Created(tripDto, message: _stringLocalizer[ResourcesKeys.Shared.Created]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Update Trip
    public async Task<ResponseModel<GetTripDto>> Handle(UpdateTripCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetTripByIdSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByIdSpecification), request.dto.TripId);
            if (!await _context.Trips.AnyAsync(asNoTrackingGetTripByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);


            ISpecification<Trip> asNoTrackingCheckDuplicatedTripByCodeSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingCheckDuplicatedTripByCodeSpecification), request.dto.TripId, request.dto.Code);
            if (await _context.Trips.AnyAsync(asNoTrackingCheckDuplicatedTripByCodeSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingCheckDuplicatedTripByNameARSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingCheckDuplicatedTripByNameARSpecification), request.dto.TripId, request.dto.NameAR);
            if (await _context.Trips.AnyAsync(asNoTrackingCheckDuplicatedTripByNameARSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<Trip> asNoTrackingCheckDuplicatedTripByNameENSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingCheckDuplicatedTripByNameENSpecification), request.dto.TripId, request.dto.NameEN);
            if (await _context.Trips.AnyAsync(asNoTrackingCheckDuplicatedTripByNameENSpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            ISpecification<Trip> asNoTrackingCheckDuplicatedTripByNameDESpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingCheckDuplicatedTripByNameDESpecification), request.dto.TripId, request.dto.NameDE);
            if (await _context.Trips.AnyAsync(asNoTrackingCheckDuplicatedTripByNameDESpec, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);


            // check category
            ISpecification<Category> asNoTrackingGetCategoryByIdSpecification = _specificationsFactory.CreateCategorySpecifications(typeof(AsNoTrackingGetCategoryByIdSpecification), request.dto.SubCategoryId);
            if (!await _context.Categories.AnyAsync(asNoTrackingGetCategoryByIdSpecification, cancellationToken))
                return ResponseResult.BadRequest<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.BadRequest]);

            ISpecification<Trip> asNoTrackingGetTripByIdSpecification = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByIdSpecification), request.dto.TripId);
            Trip trip = await _context.Trips.RetrieveAsync(asNoTrackingGetTripByIdSpecification, cancellationToken);
            trip.Code = request.dto.Code;
            trip.NameAR = request.dto.NameAR;
            trip.NameEN = request.dto.NameEN;
            trip.NameDE = request.dto.NameDE;
            trip.FromAR = request.dto.FromAR;
            trip.FromEN = request.dto.FromEN;
            trip.FromDE = request.dto.FromDE;
            trip.ToAR = request.dto.ToAR;
            trip.ToEN = request.dto.ToEN;
            trip.ToDE = request.dto.ToDE;
            trip.LongDescriptionAR = request.dto.LongDesceiptionAR;
            trip.LongDescriptionEN = request.dto.LongDesceiptionEN;
            trip.LongDesceiptionDE = request.dto.LongDesceiptionDE;
            trip.MiniDescriptionAR = request.dto.MiniDesceiptionAR;
            trip.MiniDescriptionEN = request.dto.MiniDesceiptionEN;
            trip.MiniDescriptionDE = request.dto.MiniDesceiptionDE;
            trip.IsFamous = request.dto.IsFamous;
            trip.IsActive = request.dto.IsActive;
            trip.StartDate = request.dto.StartDate;
            trip.EndDate = request.dto.EndDate;
            trip.PriceEGP = request.dto.PriceEGP;
            trip.PriceEUR = request.dto.PriceEUR;
            trip.PriceGBP = request.dto.PriceEGP;
            trip.PriceUSD = request.dto.PriceUSD;
            trip.SubCategoryId = request.dto.SubCategoryId;

            await _context.Trips.UpdateAsync(trip, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            return ResponseResult.Success(tripDto);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete Trip
    public async Task<ResponseModel<GetTripDto>> Handle(DeleteTripByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetTripByIdSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetTripByIdSpecification), request.Id);
            if (!await _context.Trips.AnyAsync(asNoTrackingGetTripByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            ISpecification<Trip> asTrackingGetTripByIdSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsTrackingGetTripByIdSpecification), request.Id);

            Trip trip = await _context.Trips.RetrieveAsync(asTrackingGetTripByIdSpec, cancellationToken);

            await _context.Trips.DeleteAsync(trip);
            await _context.SaveChangesAsync(cancellationToken);

            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            return ResponseResult.Success(tripDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Uudo Delete Trip
    public async Task<ResponseModel<GetTripDto>> Handle(UndoDeleteTripByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<Trip> asNoTrackingGetDeletedTripByIdSpec = _specificationsFactory.CreateTripSpecifications(typeof(AsNoTrackingGetDeletedTripByIdSpecification), request.Id);
            if (!await _context.Trips.AnyAsync(asNoTrackingGetDeletedTripByIdSpec, cancellationToken))
                return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            // ToDo: Get All Realted Data For This Trip To UndoDeleted Also

            ISpecification<Trip> asTrackingGetTripById_TripPhases_Spec = _specificationsFactory.CreateTripSpecifications(typeof(AsTrackingGetTripById_TripPhases_Specification), request.Id);
            Trip trip = await _context.Trips.RetrieveAsync(asTrackingGetTripById_TripPhases_Spec, cancellationToken);
            trip.TripPhases.ForEach(t => _context.UndoDeleted(ref t));
            _context.UndoDeleted(ref trip);
            await _context.SaveChangesAsync();

            GetTripDto tripDto = _mapper.Map<GetTripDto>(trip);
            return ResponseResult.Success(tripDto, message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion

    #region Delete Images From Trips
    public async Task<ResponseModel<GetTripDto>> Handle(DeleteImagesFromTripCommand request, CancellationToken cancellationToken)
    {
        try
        {
            ISpecification<TripImageMapper> asNoTrackingGetTripImagesMappersByCompositeKeySpec = _specificationsFactory.CreateTripImageMapperSpecifications(typeof(AsNoTrackingGetTripImagesMappersByCompositeKeySpecification), request.TripId, request.ImagesIds);
            if (!await _context.TripImageMappers.AnyAsync(asNoTrackingGetTripImagesMappersByCompositeKeySpec, cancellationToken))
                return ResponseResult.NotFound<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.NotFound]);

            await _context.TripImageMappers.ExecuteDeleteAsync(asNoTrackingGetTripImagesMappersByCompositeKeySpec, cancellationToken);
            return ResponseResult.Success<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.Success]);
        }
        catch (Exception ex)
        {
            return ResponseResult.InternalServerError<GetTripDto>(message: _stringLocalizer[ResourcesKeys.Shared.InternalServerError], errors: new string[] { ex.Message });
        }
    }
    #endregion
}
