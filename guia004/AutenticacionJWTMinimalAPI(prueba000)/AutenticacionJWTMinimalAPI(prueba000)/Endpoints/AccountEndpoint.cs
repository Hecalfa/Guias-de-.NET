using AutenticacionJWTMinimalAPI_prueba000_.Auth;
using System.Runtime.CompilerServices;

namespace AutenticacionJWTMinimalAPI_prueba000_.Endpoints
{
    public static class AccountEndpoint
    {
        public static void AddAccountEndpoints(this WebApplication app)
        {
            app.MapPost("/account/login", (string login, string password, IJwtAuthenticationService authService) =>
            {
                if(login == "admin" &&  password == "1234")
                {
                    var token = authService.Authenticate(login);
                    return Results.Ok(token);
                }
                else
                {
                    return Results.Unauthorized();
                }
            });
        }
    }
}
