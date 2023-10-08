﻿using MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Dtos;

namespace MasaTour.TouristTripsManagement.Application.Features.TransportationClasses.Commands;
public sealed record UndoDeleteTransportationClassByIdCommand(string ClassId) : IRequest<ResponseModel<GetTransportationClassDto>>;