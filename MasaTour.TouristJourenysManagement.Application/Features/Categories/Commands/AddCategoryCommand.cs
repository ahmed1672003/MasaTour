namespace MasaTour.TouristTripsManagement.Application.Features.Categories.Commands;
public sealed record AddCategoryCommand(AddCategoryDto dto) : IRequest<ResponseModel<GetCategoryDto>>;

