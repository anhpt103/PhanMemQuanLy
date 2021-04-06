namespace Application.Interfaces
{
    public interface IAuthenticatedUserService
    {
        string UserId { get; }
        int UnitCode { get; }
    }
}
