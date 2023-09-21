using FazAcontecerAPI.Models;
using FazAcontecerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FazAcontecerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ConnectionDB _dbContext;

        public CategoriaController(ConnectionDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            CategoriaService categoriaService = new CategoriaService(_dbContext);

            IEnumerable<Categoria> categorias = await categoriaService.GetCategorias();

            return Ok(categorias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            CategoriaService categoriaService = new CategoriaService(_dbContext);

            Categoria? categoria = await categoriaService.GetCategoriaById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        [HttpPost]
        public async Task<ActionResult> CriarCategoria(NovaCategoria novaCategoria)
        {
            CategoriaService categoriaService = new CategoriaService(_dbContext);

            Categoria categoria = new Categoria();
            categoria.Nome = novaCategoria.Nome;
            categoria.TipoCategoria = novaCategoria.TipoCategoria;
            categoria.DataCriacao = DateTime.Now;
            categoria.DataModificacao = DateTime.Now;
            categoria.Ativo = true;

            await categoriaService.CriarCategoria(categoria);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoria(int id, AtualizarCategoria atualizarCategoria)
        {
            CategoriaService categoriaService = new CategoriaService(_dbContext);

            Categoria categoria = new Categoria();
            categoria.Nome = atualizarCategoria.Nome;
            categoria.TipoCategoria = atualizarCategoria.TipoCategoria;
            categoria.Ativo = atualizarCategoria.Ativo;

            var existingCategoria = await categoriaService.GetCategoriaById(id);

            if (existingCategoria == null)
            {
                return NotFound();
            }

            await categoriaService.AtualizarCategoria(existingCategoria, categoria);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            CategoriaService categoriaService = new CategoriaService(_dbContext);

            var categoria = await categoriaService.GetCategoriaById(id);

            if (categoria == null)
            {
                return NotFound();
            }

            await categoriaService.DeletarCategoria(categoria);

            return NoContent();
        }

    }
}