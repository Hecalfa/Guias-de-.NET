using _001_registro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;

namespace AutenticacionCookieControllers.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class TestController : ControllerBase
    {
        static List<Matricula> matriculas = new List<Matricula>();

        [HttpGet]
        [Authorize]
        public IEnumerable<Matricula> Get()
        {
            return matriculas;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Post([FromBody] Matricula matricula)
        {
            matriculas.Add(matricula);
            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existinMatricula = matriculas.FirstOrDefault(x => x.Id == id);
            if (existinMatricula != null)
            {
                matriculas.Remove(existinMatricula);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Matricula matricula)
        {
            var existinMatricula = matriculas.FirstOrDefault(x => x.Id == id);
            if (existinMatricula != null)
            {
                existinMatricula.Name = matricula.Name;
                existinMatricula.Grado = matricula.Grado;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}