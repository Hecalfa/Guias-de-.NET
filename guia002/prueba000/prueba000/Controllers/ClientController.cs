using Microsoft.AspNetCore.Mvc;
using prueba000.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prueba000.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        static List<Client> clients = new List<Client>();

        [HttpGet]
        public IEnumerable<Client> Get()
        {
            return clients;
        }

        [HttpGet("{id}")]
        public Client Get(int id)
        {
            var client = clients.FirstOrDefault(c => c.Id == id);
            return client;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            clients.Add(client);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Client client)
        {
            var existingClient = clients.FirstOrDefault(c =>c.Id == id);
            if (existingClient != null)
            {
                existingClient.Name = client.Name;
                existingClient.LastName = client.LastName;
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
            var existingClient = clients.FirstOrDefault(c =>c.Id == id);
            if (existingClient != null)
            {
                clients.Remove(existingClient);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}