using ApiMDGLoja.Data;
using ApiMDGLoja.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMDGLoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItensPedidoController : ControllerBase
    {
        private readonly MDGContext _context;

        public ItensPedidoController(MDGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var itens = _context.ItensPedidos
                .Include(i => i.Produto)
                .Include(i => i.Pedido)
                .ToList();
            return Ok(itens);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _context.ItensPedidos
                .Include(i => i.Produto)
                .Include(i => i.Pedido)
                .FirstOrDefault(i => i.Id == id);

            if (item == null) return NotFound();
            return Ok(item);
        }

        [HttpPost]
        public IActionResult Create([FromBody] ItensPedido item)
        {
            if (item == null) return BadRequest();

            _context.ItensPedidos.Add(item);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] ItensPedido item)
        {
            if (id != item.Id) return BadRequest();

            _context.ItensPedidos.Update(item);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var item = _context.ItensPedidos.Find(id);
            if (item == null) return NotFound();

            _context.ItensPedidos.Remove(item);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
