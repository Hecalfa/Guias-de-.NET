using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AutenticacionCookieControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class notaController : ControllerBase
    {
        static List<object> data = new List<object>();

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<object> Get()
        {
            return data;
        }
        [HttpPost]
        public IActionResult Post(string name, int nota)
        {
            data.Add(new {name, nota });
            return Ok();
        }
    }
}