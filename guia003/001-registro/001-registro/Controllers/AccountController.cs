using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AutenticacionCookieControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcoountController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(string login,string password)
        {
            if (login == "admin" &&  password == "1234")
            {
                var claim = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login),
                };
                var claimsIdentity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
                var authPropeties = new AuthenticationProperties
                {

                };
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authPropeties);
                return Ok("Inicio de sesion correctamente.");
            }
            else
            {
                return Unauthorized("Credenciales incorectas");
            }
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok("Cerro cesion correctamente.");
        }
    }
}