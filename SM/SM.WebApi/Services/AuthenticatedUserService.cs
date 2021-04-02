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
            UnitCode = httpContextAccessor.HttpContext?.User?.FindFirstValue("unit");
        }

        public string UserId { get; }

        public string UnitCode { get; }
    }
}
