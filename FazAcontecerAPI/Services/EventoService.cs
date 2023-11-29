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

        public async Task<IEnumerable<Evento>> GetEventos(int idUsuario)
        {
            return await _dbContext.TbEvento.Where(e => e.id_usuario == idUsuario).ToListAsync();
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

        public async Task<Evento> AtualizarEvento(Evento existingEvento, Evento evento)
        {
            existingEvento.Nome = evento.Nome;
            existingEvento.Data_evento = Convert.ToDateTime(evento.Data_evento);
            existingEvento.Horario = Convert.ToDateTime(evento.Horario);
            existingEvento.Local_evento = evento.Local_evento;
            existingEvento.Observacao = evento.Observacao;
            existingEvento.Descricao = evento.Descricao;
            existingEvento.Orcamento = evento.Orcamento;
            existingEvento.Ativo = evento.Ativo;
            existingEvento.Data_modificacao = DateTime.Now;

            _dbContext.TbEvento.Update(existingEvento);
            await _dbContext.SaveChangesAsync();

            return evento;
        }

        public async Task DeletarEvento(Evento evento)
        {
            _dbContext.TbEvento.Remove(evento);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<RetornarExtratoEvento> CalcularSaldoEvento(int idEvento)
        {
            Evento? evento = await GetEventoById(idEvento);

            RetornarExtratoEvento ret = new RetornarExtratoEvento();

            if (evento != null)
            {

                var saldo = evento.Orcamento;
                ret.Itens = new List<ItemExtrato>();

                AperitivoService aperitivoService = new AperitivoService(_dbContext);
                List<Aperitivo> aperitivos = aperitivoService.GetAperitivos(idEvento).Result.Where(a => a.Check == true).ToList();

                foreach (var aperitivo in aperitivos)
                {
                    saldo -= (aperitivo.Preco_unidade * aperitivo.Quantidade);
                    ret.Itens.Add(new ItemExtrato
                    {
                        Descricao = aperitivo.Nome,
                        Preco = aperitivo.Preco_unidade * aperitivo.Quantidade,
                        Quantidade = aperitivo.Quantidade,
                    });
                }

                DecoracaoService decoracaoService = new DecoracaoService(_dbContext);
                List<Decoracao> decoracoes = decoracaoService.GetDecoracoes(idEvento).Result.Where(d => d.Check == true).ToList();

                foreach (var decoracao in decoracoes)
                {
                    saldo -= (decoracao.Preco_unidade * decoracao.Quantidade);
                    ret.Itens.Add(new ItemExtrato
                    {
                        Descricao = decoracao.Nome,
                        Preco = decoracao.Preco_unidade * decoracao.Quantidade,
                        Quantidade = decoracao.Quantidade,
                    });
                }

                ret.Saldo = saldo;

                return ret;
            }

            return ret;
        }
    }
}
