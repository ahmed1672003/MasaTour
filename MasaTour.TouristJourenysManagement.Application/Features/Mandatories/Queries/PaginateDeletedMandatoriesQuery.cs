﻿namespace MasaTour.TouristTripsManagement.Application.Features.Mandatories.Queries;
public sealed record PaginateDeletedMandatoriesQuery(int? PageNumber = 1, int? PageSize = 10, string KeyWords = "", MandatoryOrderBy? OrderBy = MandatoryOrderBy.CreatedAt) : IRequest<PaginationResponseModel<IEnumerable<GetMandatoryDto>>>;
