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
        public async Task<ActionResult<IEnumerable<Decoracao>>> GetDecoracoes(int idEvento)
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
            decoracao.IdEvento = novoDecoracao.IdEvento;
            decoracao.Preco_unidade = novoDecoracao.Preco_unidade;
            decoracao.Data_criacao = DateTime.Now;
            decoracao.Data_modificacao = DateTime.Now;
            decoracao.Ativo = true;
            decoracao.Check = false;

            Decoracao decoracaoNova = await decoracaoService.CriarDecoracao(decoracao);

            return Ok(decoracaoNova);
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
            decoracao.Check = atualizarDecoracao.Check;
            decoracao.Ativo = atualizarDecoracao.Ativo;

            var existingDecoracao = await decoracaoService.GetDecoracaoById(id);

            if (existingDecoracao == null)
            {
                return NotFound();
            }

            Decoracao decoracaoNova = await decoracaoService.AtualizarDecoracao(existingDecoracao, decoracao);

            return Ok(decoracaoNova);
        }

        [HttpPut("Check")]
        public async Task<IActionResult> CheckDecoracao(int decoracaoId)
        {
            DecoracaoService decoracaoService = new DecoracaoService(_dbContext);

            var existingDecoracao = await decoracaoService.GetDecoracaoById(decoracaoId);

            if (existingDecoracao == null)
            {
                return NotFound();
            }

            await decoracaoService.CheckDecoracao(existingDecoracao);

            return Ok();
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

            return Ok();
        }

    }
}