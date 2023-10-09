namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Queries;
public sealed record PginateUnDeletedTransportationClassesQuery
    (int? PageNumber = 1, int? PageSize = 10, string KeyWords = "", TransportationClassOrderBy? OrderBy = TransportationClassOrderBy.CreatedAt)
    : IRequest<PaginationResponseModel<IEnumerable<GetTransportationClassDto>>>;