using FazAcontecerAPI.Models;
using FazAcontecerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FazAcontecerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecoracaoController : ControllerBase
    {
        private readonly ConnectionDB _dbContext;

        public DecoracaoController(ConnectionDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetDecoracoes(int idEvento)
        {
            DecoracaoService decoracaoService = new DecoracaoService(_dbContext);

            IEnumerable<Decoracao> aperitivos = await decoracaoService.GetDecoracoes(idEvento);

            return Ok(aperitivos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Decoracao>> GetDecoracao(int id)
        {
            DecoracaoService aperitivoService = new DecoracaoService(_dbContext);

            Decoracao? decoracao = await aperitivoService.GetDecoracaoById(id);

            if (decoracao == null)
            {
                return NotFound();
            }

            return decoracao;
        }

        [HttpPost]
        public async Task<ActionResult> CriarDecoracao(NovaDecoracao novoDecoracao)
        {
            DecoracaoService decoracaoService = new DecoracaoService(_dbContext);

            Decoracao decoracao = new Decoracao();
            decoracao.Nome = novoDecoracao.Nome;
            decoracao.Quantidade = novoDecoracao.Quantidade;
            decoracao.IdCategoria = novoDecoracao.IdCategoria;
            decoracao.Data_criacao = DateTime.Now;
            decoracao.Data_modificacao = DateTime.Now;
            decoracao.Ativo = true;

            await decoracaoService.CriarDecoracao(decoracao);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDecoracao(int id, AtualizarDecoracao atualizarDecoracao)
        {
            DecoracaoService decoracaoService = new DecoracaoService(_dbContext);

            Decoracao decoracao = new Decoracao();
            decoracao.Nome = atualizarDecoracao.Nome;
            decoracao.Preco_unidade = atualizarDecoracao.Preco_unidade;
            decoracao.Quantidade = atualizarDecoracao.Quantidade;
            decoracao.IdCategoria = atualizarDecoracao.IdCategoria;

            var existingDecoracao = await decoracaoService.GetDecoracaoById(id);

            if (existingDecoracao == null)
            {
                return NotFound();
            }

            await decoracaoService.AtualizarDecoracao(existingDecoracao, decoracao);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDecoracao(int id)
        {
            DecoracaoService decoracaoService = new DecoracaoService(_dbContext);

            var decoracao = await decoracaoService.GetDecoracaoById(id);

            if (decoracao == null)
            {
                return NotFound();
            }

            await decoracaoService.DeletarDecoracao(decoracao);

            return NoContent();
        }

    }
}