using _002_Docentes.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _002_Docentes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        static List<Docentes> docentes = new List<Docentes>();

        [HttpGet]
        public IEnumerable<Docentes> Get()
        {
            return docentes;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Docentes docente)
        {
            docentes.Add(docente);
            return Ok();
        }
    }
}