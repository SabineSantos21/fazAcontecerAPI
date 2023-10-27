using FazAcontecerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FazAcontecerAPI.Services
{
    public class DecoracaoService
    {
        private readonly ConnectionDB _dbContext;

        public DecoracaoService(ConnectionDB dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Decoracao>> GetDecoracoes(int idEvento)
        {
            return await _dbContext.TbDecoracao.Where(d => d.IdEvento == idEvento).ToListAsync();
        }

        public async Task<Decoracao?> GetDecoracaoById(int id)
        {
            return await _dbContext.TbDecoracao.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Decoracao> CriarDecoracao(Decoracao decoracao)
        {
            _dbContext.TbDecoracao.Add(decoracao);
            await _dbContext.SaveChangesAsync();

            return decoracao;
        }

        public async Task AtualizarDecoracao(Decoracao existingDecoracao, Decoracao decoracao)
        {
            existingDecoracao.Nome = decoracao.Nome;
            existingDecoracao.Preco_unidade = decoracao.Preco_unidade;
            existingDecoracao.Quantidade = decoracao.Quantidade;
            existingDecoracao.Ativo = decoracao.Ativo;
            existingDecoracao.Data_modificacao = DateTime.Now;
            existingDecoracao.Check = decoracao.Check;
            existingDecoracao.Ativo = decoracao.Ativo;

            _dbContext.TbDecoracao.Update(existingDecoracao);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletarDecoracao(Decoracao decoracao)
        {
            _dbContext.TbDecoracao.Remove(decoracao);
            await _dbContext.SaveChangesAsync();
        }
    }
}
