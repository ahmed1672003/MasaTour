﻿namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Commands;
public sealed record UpdateCategoryCommand(UpdateCategoryDto dto) : IRequest<ResponseModel<GetCategoryDto>>;

