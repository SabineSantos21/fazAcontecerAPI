using FazAcontecerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FazAcontecerAPI.Services
{
    public class EventoService
    {
        private readonly ConnectionDB _dbContext;

        public EventoService(ConnectionDB dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Evento>> GetEventos()
        {
            return await _dbContext.TbEvento.ToListAsync();
        }

        public async Task<Evento?> GetEventoById(int id)
        {
            return await _dbContext.TbEvento.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Evento> CriarEvento(Evento evento)
        {
            _dbContext.TbEvento.Add(evento);
            await _dbContext.SaveChangesAsync();

            return evento;
        }

        public async Task AtualizarEvento(Evento existingEvento, Evento evento)
        {
            existingEvento.Nome = evento.Nome;
            existingEvento.Ativo = evento.Ativo;
            existingEvento.Data_modificacao = DateTime.Now;

            _dbContext.TbEvento.Update(existingEvento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletarEvento(Evento evento)
        {
            _dbContext.TbEvento.Remove(evento);
            await _dbContext.SaveChangesAsync();
        }
    }
}
