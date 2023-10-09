﻿namespace MasaTour.TouristTripsManagement.Application.Features.Transportations.Queries;
public sealed record PaginateDeletedTransportationsQuery(int? PagNumber = 1, int? PageSize = 10, string KeyWords = "", TransportationOrderBy? OrderBy = TransportationOrderBy.CreatedAt) : IRequest<PaginationResponseModel<IEnumerable<GetTransportationDto>>>;
