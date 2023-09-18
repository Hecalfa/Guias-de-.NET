using _003_Materias.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _003_Materias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriasController : ControllerBase
    {
        static List<Materias> materias = new List<Materias>();

        [HttpGet]
        public IEnumerable<Materias> Get()
        {
            return materias;
        }
        [HttpPost]
        public IActionResult Put([FromBody] Materias materia)
        {
            materias.Add(materia);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingMaterias = materias.FirstOrDefault(c => c.Id == id);
            if (existingMaterias != null)
            {
                materias.Remove(existingMaterias);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
