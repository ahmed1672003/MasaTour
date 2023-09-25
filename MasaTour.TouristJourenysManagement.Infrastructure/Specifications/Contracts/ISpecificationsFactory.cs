namespace MasaTour.TouristJourenysManagement.Infrastructure.Specifications.Contracts;
public interface ISpecificationsFactory
{
    ISpecification<User> CreateUserSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Role> CreateRoleSpecifications(Type type, params dynamic[] parameters);
    ISpecification<UserJWT> CreateUserJWTSpecifications(Type type, params dynamic[] parameters);
    ISpecification<Category> CreatCategorySpecifications(Type type, params dynamic[] parameters);
    ISpecification<Journey> CreatJourneySpecifications(Type type, params dynamic[] parameters);
}