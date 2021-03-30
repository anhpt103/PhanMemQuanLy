Install Nuget Microsoft.EntityFrameworkCore.Design project SM.WebApi

Step 1: cd to SM.Infrastructure.Identity and run
dotnet ef migrations add Initial --startup-project ../SM.WebApi/SM.WebApi.csproj -c "IdentityContext"
dotnet ef database update --startup-project ../SM.WebApi/SM.WebApi.csproj -c "IdentityContext"

Step 2: cd to SM.Infrastructure.Persistence and run
dotnet ef migrations add Initial --startup-project ../SM.WebApi/SM.WebApi.csproj -c "ApplicationDbContext"
dotnet ef database update --startup-project ../SM.WebApi/SM.WebApi.csproj -c "ApplicationDbContext"
