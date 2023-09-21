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

        public async Task<IEnumerable<Decoracao>> GetDecoracoes()
        {
            return await _dbContext.TbDecoracao.ToListAsync();
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
            existingDecoracao.PrecoUnidade = decoracao.PrecoUnidade;
            existingDecoracao.Quantidade = decoracao.Quantidade;
            existingDecoracao.Ativo = decoracao.Ativo;
            existingDecoracao.DataModificacao = DateTime.Now;

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
