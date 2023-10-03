namespace MasaTour.TouristTripsManagement.Infrastructure.Specifications.Contracts;
public interface ISpecificationsFactory
{
    ISpecification<User> CreateUserSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Role> CreateRoleSpecifications(Type type, params dynamic[] parameters);
    ISpecification<UserJWT> CreateUserJWTSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Category> CreateCategorySpecifications(Type type, params dynamic[] parameters);
    ISpecification<SubCategory> CreateSubCategorySpecifications(Type type, params dynamic[] parameters);
    ISpecification<Trip> CreateTripSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Mandatory> CreateMandatorySpecifications(Type type, params dynamic[] parameters);
    ISpecification<Image> CreateImageSpecifications(Type type, params dynamic[] parameters);
    ISpecification<TripImageMapper> CreateTripImageMapperSpecifications(Type type, params dynamic[] parameters);
    ISpecification<TripPhase> CreateTripPhaseSpecifications(Type type, params dynamic[] parameters);
}