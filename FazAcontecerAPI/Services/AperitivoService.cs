﻿using FazAcontecerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FazAcontecerAPI.Services
{
    public class AperitivoService
    {
        private readonly ConnectionDB _dbContext;

        public AperitivoService(ConnectionDB dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Aperitivo>> GetAperitivos(int idEvento)
        {
            return await _dbContext.TbAperitivo.Where(a => a.IdEvento == idEvento).ToListAsync();
        }

        public async Task<Aperitivo?> GetAperitivoById(int id)
        {
            return await _dbContext.TbAperitivo.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Aperitivo> CriarAperitivo(Aperitivo aperitivo)
        {
            _dbContext.TbAperitivo.Add(aperitivo);
            await _dbContext.SaveChangesAsync();

            return aperitivo;
        }

        public async Task AtualizarAperitivo(Aperitivo existingAperitivo, Aperitivo aperitivo)
        {
            existingAperitivo.Nome = aperitivo.Nome;
            existingAperitivo.PrecoUnidade = aperitivo.PrecoUnidade;
            existingAperitivo.Quantidade = aperitivo.Quantidade;
            existingAperitivo.Ativo = aperitivo.Ativo;
            existingAperitivo.DataModificacao = DateTime.Now;

            _dbContext.TbAperitivo.Update(existingAperitivo);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeletarAperitivo(Aperitivo aperitivo)
        {
            _dbContext.TbAperitivo.Remove(aperitivo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
