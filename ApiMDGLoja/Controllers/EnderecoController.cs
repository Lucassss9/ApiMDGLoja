using ApiMDGLoja.Data;
using ApiMDGLoja.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMDGLoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly MDGContext _context;

        public EnderecoController(MDGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Enderecos.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            return endereco == null ? NotFound() : Ok(endereco);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Endereco endereco)
        {
            if (endereco == null) return BadRequest();
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = endereco.Id }, endereco);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Endereco endereco)
        {
            if (id != endereco.Id) return BadRequest();
            _context.Enderecos.Update(endereco);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var endereco = _context.Enderecos.Find(id);
            if (endereco == null) return NotFound();
            _context.Enderecos.Remove(endereco);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
