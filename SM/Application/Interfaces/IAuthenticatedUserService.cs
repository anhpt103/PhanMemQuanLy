namespace Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        string UnitCode { get; }
    }
}
