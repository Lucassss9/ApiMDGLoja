using ApiMDGLoja.Data;
using ApiMDGLoja.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiMDGLoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly MDGContext _context;

        public PedidoController(MDGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pedidos = _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.ItensPedidos)
                .ThenInclude(ip => ip.Produto)
                .ToList();
            return Ok(pedidos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var pedido = _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.ItensPedidos)
                .ThenInclude(ip => ip.Produto)
                .FirstOrDefault(p => p.Id == id);

            if (pedido == null) return NotFound();
            return Ok(pedido);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Pedido pedido)
        {
            if (pedido == null) return BadRequest();

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = pedido.Id }, pedido);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Pedido pedido)
        {
            if (id != pedido.Id) return BadRequest();

            _context.Pedidos.Update(pedido);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pedido = _context.Pedidos.Find(id);
            if (pedido == null) return NotFound();

            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
