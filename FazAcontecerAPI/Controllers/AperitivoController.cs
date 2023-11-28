using FazAcontecerAPI.Models;
using FazAcontecerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FazAcontecerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AperitivoController : ControllerBase
    {
        private readonly ConnectionDB _dbContext;

        public AperitivoController(ConnectionDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aperitivo>>> GetAperitivos(int idEvento)
        {
            AperitivoService aperitivoService = new AperitivoService(_dbContext);

            IEnumerable<Aperitivo> aperitivos = await aperitivoService.GetAperitivos(idEvento);

            return Ok(aperitivos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aperitivo>> GetAperitivo(int id)
        {
            AperitivoService aperitivoService = new AperitivoService(_dbContext);

            Aperitivo? aperitivo = await aperitivoService.GetAperitivoById(id);

            if (aperitivo == null)
            {
                return NotFound();
            }

            return aperitivo;
        }

        [HttpGet("categoria/{idCategoria}")]
        public async Task<ActionResult<Aperitivo>> GetAperitivoByCategoria(int idCategoria)
        {
            AperitivoService aperitivoService = new AperitivoService(_dbContext);

            IEnumerable<Aperitivo> aperitivos = await aperitivoService.GetAperitivosByCategoria(idCategoria);

            return Ok(aperitivos);
        }

        [HttpPost]
        public async Task<ActionResult> CriarAperitivo(NovoAperitivo novoAperitivo)
        {
            AperitivoService aperitivoService = new AperitivoService(_dbContext);

            Aperitivo aperitivo = new Aperitivo();
            aperitivo.Nome = novoAperitivo.Nome;
            aperitivo.Preco_unidade = novoAperitivo.Preco_unidade;
            aperitivo.Quantidade = novoAperitivo.Quantidade;
            aperitivo.IdCategoria = novoAperitivo.IdCategoria;
            aperitivo.IdEvento = novoAperitivo.IdEvento;
            aperitivo.Data_criacao = DateTime.Now;
            aperitivo.Data_modificacao = DateTime.Now;
            aperitivo.Ativo = true;
            aperitivo.Check = false;

            Aperitivo aperitivoResponse = await aperitivoService.CriarAperitivo(aperitivo);

            return Ok(aperitivoResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAperitivo(int id, AtualizarAperitivo atualizarAperitivo)
        {
            AperitivoService aperitivoService = new AperitivoService(_dbContext);

            Aperitivo aperitivo = new Aperitivo();
            aperitivo.Nome = atualizarAperitivo.Nome;
            aperitivo.Preco_unidade = atualizarAperitivo.Preco_unidade;
            aperitivo.Quantidade = atualizarAperitivo.Quantidade;
            aperitivo.IdCategoria = atualizarAperitivo.IdCategoria;
            aperitivo.Ativo = atualizarAperitivo.Ativo;
            aperitivo.Check = atualizarAperitivo.Check;

            var existingAperitivo = await aperitivoService.GetAperitivoById(id);

            if (existingAperitivo == null)
            {
                return NotFound();
            }

            Aperitivo aperitivoResponse = await aperitivoService.AtualizarAperitivo(existingAperitivo, aperitivo);

            return Ok(aperitivoResponse);
        }

        [HttpPut("Check")]
        public async Task<IActionResult> PutAperitivo(int aperitivoId)
        {
            AperitivoService aperitivoService = new AperitivoService(_dbContext);

            var existingAperitivo = await aperitivoService.GetAperitivoById(aperitivoId);

            if (existingAperitivo == null)
            {
                return NotFound();
            }
            
            Aperitivo aperitivoResponse = await aperitivoService.CheckAperitivo(existingAperitivo);

            return Ok(aperitivoResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAperitivo(int id)
        {
            AperitivoService aperitivoService = new AperitivoService(_dbContext);

            var aperitivo = await aperitivoService.GetAperitivoById(id);

            if (aperitivo == null)
            {
                return NotFound();
            }

            await aperitivoService.DeletarAperitivo(aperitivo);

            return Ok();
        }

    }
}