using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace SM.WebApi.Services
{
    public class AuthenticatedUserService : IAuthenticatedUserService
    {
        public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue("uid");
            int.TryParse(httpContextAccessor.HttpContext?.User?.FindFirstValue("unit"), out int unit);
            UnitCode = unit;
        }

        public string UserId { get; }

        public int UnitCode { get; }
    }
}
