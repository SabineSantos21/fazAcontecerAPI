﻿using FazAcontecerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Ocsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FazAcontecerAPI.Services
{
    public class ConvidadoService
    {
        private readonly ConnectionDB _dbContext;

        public ConvidadoService(ConnectionDB dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Convidado>> GetConvidados(int idEvento)
        {
            return await _dbContext.TbConvidado.Where(c => c.IdEvento == idEvento).ToListAsync();
        }

        public async Task<Convidado?> GetConvidadoById(int id)
        {
            return await _dbContext.TbConvidado.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Convidado> CriarConvidado(Convidado convidado)
        {
            _dbContext.TbConvidado.Add(convidado);
            await _dbContext.SaveChangesAsync();

            return convidado;
        }

        public async Task<Convidado> AtualizarConvidado(Convidado existingConvidado, Convidado convidado)
        {
            existingConvidado.Nome = convidado.Nome;
            existingConvidado.Aceitou_convite = convidado.Aceitou_convite;
            existingConvidado.Ativo = convidado.Ativo;
            existingConvidado.Email = convidado.Email;
            existingConvidado.Telefone = convidado.Telefone;
            existingConvidado.Ativo = convidado.Ativo;
            existingConvidado.Data_modificacao = DateTime.Now;

            _dbContext.TbConvidado.Update(existingConvidado);
            await _dbContext.SaveChangesAsync();

            return existingConvidado;
        }

        public async Task DeletarConvidado(Convidado convidado)
        {
            _dbContext.TbConvidado.Remove(convidado);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Convidado> ResponderConvite(Convidado convidado, bool resposta)
        {
            convidado.Aceitou_convite = resposta;

            _dbContext.TbConvidado.Update(convidado);
            await _dbContext.SaveChangesAsync();

            return convidado;
        }
    }
}
