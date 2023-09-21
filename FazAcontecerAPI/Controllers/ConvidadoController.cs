using FazAcontecerAPI.Models;
using FazAcontecerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FazAcontecerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvidadoController : ControllerBase
    {
        private readonly ConnectionDB _dbContext;

        public ConvidadoController(ConnectionDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Convidado>>> GetConvidados()
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            IEnumerable<Convidado> convidados = await convidadoService.GetConvidados();

            return Ok(convidados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Convidado>> GetConvidado(int id)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            Convidado? convidado = await convidadoService.GetConvidadoById(id);

            if (convidado == null)
            {
                return NotFound();
            }

            return convidado;
        }

        [HttpPost]
        public async Task<ActionResult> CriarConvidado(NovoConvidado novoConvidado)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            Convidado convidado = new Convidado();
            convidado.Nome = novoConvidado.Nome;
            convidado.Telefone = novoConvidado.Telefone;
            convidado.Email = novoConvidado.Email;
            convidado.DataCriacao = DateTime.Now;
            convidado.DataModificacao = DateTime.Now;
            convidado.Ativo = true;

            await convidadoService.CriarConvidado(convidado);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConvidado(int id, AtualizarConvidado atualizarConvidado)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            Convidado convidado = new Convidado();
            convidado.Nome = atualizarConvidado.Nome;
            convidado.Telefone = atualizarConvidado.Telefone;
            convidado.Email = atualizarConvidado.Email;
            convidado.Ativo = atualizarConvidado.Ativo;

            var existingConvidado = await convidadoService.GetConvidadoById(id);

            if (existingConvidado == null)
            {
                return NotFound();
            }

            await convidadoService.AtualizarConvidado(existingConvidado, convidado);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConvidado(int id)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            var convidado = await convidadoService.GetConvidadoById(id);

            if (convidado == null)
            {
                return NotFound();
            }

            await convidadoService.DeletarConvidado(convidado);

            return NoContent();
        }

    }
}