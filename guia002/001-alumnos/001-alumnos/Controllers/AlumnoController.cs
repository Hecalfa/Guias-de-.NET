using _001_alumnos.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _001_alumnos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        static List<Alumno> alumnos = new List<Alumno>();

        [HttpGet]
        public IEnumerable<Alumno> Get()
        {
            return alumnos;
        }

        [HttpGet("{id}")]
        public Alumno Get(int id)
        {
            var alumno = alumnos.FirstOrDefault(c => c.Id == id);
            return alumno;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Alumno alumno)
        {
            alumnos.Add(alumno);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Alumno alumno)
        {
            var existingAlumno = alumnos.FirstOrDefault(c =>c.Id == id);
            if (existingAlumno != null)
            {
                existingAlumno.Name = alumno.Name;
                existingAlumno.Note = alumno.Note;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingAlumno = alumnos.FirstOrDefault(c => c.Id == id);
            if (existingAlumno != null)
            {
                alumnos.Remove(existingAlumno);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
