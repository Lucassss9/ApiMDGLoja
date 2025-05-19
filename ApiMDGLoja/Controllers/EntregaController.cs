using ApiMDGLoja.Data;
using ApiMDGLoja.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMDGLoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EntregaController : ControllerBase
    {
        private readonly MDGContext _context;

        public EntregaController(MDGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var entregas = _context.Entregas
                .Include(e => e.Pedido)
                .ToList();

            return Ok(entregas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var entrega = _context.Entregas
                .Include(e => e.Pedido)
                .FirstOrDefault(e => e.Id == id);

            if (entrega == null) return NotFound();

            return Ok(entrega);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Entrega entrega)
        {
            if (entrega == null) return BadRequest();

            _context.Entregas.Add(entrega);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = entrega.Id }, entrega);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Entrega entrega)
        {
            if (id != entrega.Id) return BadRequest();

            _context.Entregas.Update(entrega);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entrega = _context.Entregas.Find(id);
            if (entrega == null) return NotFound();

            _context.Entregas.Remove(entrega);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
