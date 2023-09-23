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
        public async Task<ActionResult<IEnumerable<Evento>>> GetEventos()
        {
            EventoService eventoService = new EventoService(_dbContext);

            IEnumerable<Evento> eventos = await eventoService.GetEventos();

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
            evento.Data_evento = novoEvento.Data_evento;
            evento.Horario = novoEvento.Horario;
            evento.Local_evento = novoEvento.Local_evento;
            evento.Observacao = novoEvento.Observacao;
            evento.Orcamento = novoEvento.Orcamento;
            evento.Data_criacao = DateTime.Now;
            evento.Data_modificacao = DateTime.Now;
            evento.Ativo = true;

            await eventoService.CriarEvento(evento);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvento(int id, AtualizarEvento atualizarEvento)
        {
            EventoService eventoService = new EventoService(_dbContext);

            Evento evento = new Evento();
            evento.Nome = atualizarEvento.Nome;
            evento.Data_evento = atualizarEvento.Data_evento;
            evento.Horario = atualizarEvento.Horario;
            evento.Local_evento = atualizarEvento.Local_evento;
            evento.Observacao = atualizarEvento.Observacao;
            evento.Orcamento = atualizarEvento.Orcamento;
            evento.Ativo = atualizarEvento.Ativo;
            evento.Data_modificacao = DateTime.Now;

            var existingEvento = await _dbContext.TbEvento.FindAsync(id);

            if (existingEvento == null)
            {
                return NotFound();
            }

            await eventoService.AtualizarEvento(existingEvento, evento);

            return NoContent();
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
    }
}