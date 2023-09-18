using _004_Aulas.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _004_Aulas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AulasController : ControllerBase
    {
        static List<Aulas> aulas = new List<Aulas>()
        {
            new Aulas { Id = 0,aulas = "informatica"},
            new Aulas { Id = 1,aulas = "electrica"},
            new Aulas { Id = 2,aulas = "direccion"}
        };

        [HttpGet]
        public IEnumerable<Aulas> Get()
        {
            return aulas;
        }
    }
}
