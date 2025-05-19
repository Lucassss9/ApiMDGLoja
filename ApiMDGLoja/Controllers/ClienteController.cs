using ApiMDGLoja.Data;
using ApiMDGLoja.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMDGLoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly MDGContext _context;

        public ClienteController(MDGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Clientes.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = _context.Clientes.Find(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            if (cliente == null) return BadRequest();
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente == null) return NotFound();
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
