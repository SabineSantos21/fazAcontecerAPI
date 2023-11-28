using FazAcontecerAPI.Models;
using FazAcontecerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FazAcontecerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly ConnectionDB _dbContext;

        public EventoController(ConnectionDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos(int idUsuario)
        {
            EventoService eventoService = new EventoService(_dbContext);

            IEnumerable<Evento> eventos = await eventoService.GetEventos(idUsuario);

            return Ok(eventos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evento>> GetEvento(int id)
        {
            EventoService eventoService = new EventoService(_dbContext);

            Evento? evento = await eventoService.GetEventoById(id);

            if (evento == null)
            {
                return NotFound();
            }

            return evento;
        }

        [HttpPost]
        public async Task<ActionResult> CriarEvento(NovoEvento novoEvento)
        {
            EventoService eventoService = new EventoService(_dbContext);

            Evento evento = new Evento();
            evento.Nome = novoEvento.Nome;
            evento.Data_evento = Convert.ToDateTime(novoEvento.Data_evento);
            evento.Horario = Convert.ToDateTime(novoEvento.Horario);
            evento.Local_evento = novoEvento.Local_evento;
            evento.Observacao = novoEvento.Observacao;
            evento.Descricao = novoEvento.Descricao;
            evento.Orcamento = novoEvento.Orcamento;
            evento.Data_criacao = DateTime.Now;
            evento.Data_modificacao = DateTime.Now;
            evento.Ativo = true;
            evento.id_usuario = novoEvento.Id_usuario;

            Evento eventoCriado = await eventoService.CriarEvento(evento);

            return Ok(eventoCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, AtualizarEvento atualizarEvento)
        {
            EventoService eventoService = new EventoService(_dbContext);

            Evento evento = new Evento();
            evento.Nome = atualizarEvento.Nome;
            evento.Data_evento = Convert.ToDateTime(atualizarEvento.Data_evento);
            evento.Horario = Convert.ToDateTime(atualizarEvento.Horario);
            evento.Local_evento = atualizarEvento.Local_evento;
            evento.Observacao = atualizarEvento.Observacao;
            evento.Descricao = atualizarEvento.Descricao;
            evento.Orcamento = atualizarEvento.Orcamento;
            evento.Ativo = atualizarEvento.Ativo;
            evento.Data_modificacao = DateTime.Now;

            var existingEvento = await _dbContext.TbEvento.FindAsync(id);

            if (existingEvento == null)
            {
                return NotFound();
            }

            Evento eventoAtualizado = await eventoService.AtualizarEvento(existingEvento, evento);

            return Ok(eventoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvento(int id)
        {
            EventoService eventoService = new EventoService(_dbContext);

            var evento = await _dbContext.TbEvento.FindAsync(id);

            if (evento == null)
            {
                return NotFound();
            }

            await eventoService.DeletarEvento(evento);

            return NoContent();
        }

        [HttpGet("CalcularSaldo/{idEvento}")]
        public async Task<ActionResult<RetornarExtratoEvento>> CalcularSaldo(int idEvento)
        {
            EventoService eventoService = new EventoService(_dbContext);

            RetornarExtratoEvento retornarExtratoEvento = await eventoService.CalcularSaldoEvento(idEvento);

            return retornarExtratoEvento;
        }
    }
}