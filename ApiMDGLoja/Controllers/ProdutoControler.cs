using ApiMDGLoja.Data;
using ApiMDGLoja.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMDGLoja.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly MDGContext _context;

        public ProdutoController(MDGContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_context.Produtos.ToList());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var produto = _context.Produtos.Find(id);
            return produto == null ? NotFound() : Ok(produto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Produto produto)
        {
            if (produto == null) return BadRequest();
            _context.Produtos.Add(produto);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id) return BadRequest();
            _context.Produtos.Update(produto);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto == null) return NotFound();
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
