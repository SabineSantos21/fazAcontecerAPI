using FazAcontecerAPI.Email;
using FazAcontecerAPI.Models;
using FazAcontecerAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Net.Mail;

namespace FazAcontecerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConvidadoController : ControllerBase
    {
        private readonly ConnectionDB _dbContext;
        private readonly IOptions<EmailSettings> _emailSettings;

        public ConvidadoController(ConnectionDB dbContext, IOptions<EmailSettings> emailSettings)
        {
            _dbContext = dbContext;
            _emailSettings = emailSettings;
        }

        [HttpGet("idEvento")]
        public async Task<ActionResult<IEnumerable<Convidado>>> GetConvidados(int idEvento)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            IEnumerable<Convidado> convidados = await convidadoService.GetConvidados(idEvento);

            return Ok(convidados);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Convidado>> GetConvidado(int id)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            Convidado? convidado = await convidadoService.GetConvidadoById(id);

            if (convidado == null)
            {
                return NotFound();
            }

            return convidado;
        }

        [HttpPost]
        public async Task<ActionResult> CriarConvidado(NovoConvidado novoConvidado)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            Convidado convidado = new Convidado();
            convidado.Nome = novoConvidado.Nome;
            convidado.Telefone = novoConvidado.Telefone;
            convidado.Email = novoConvidado.Email;
            convidado.IdEvento = novoConvidado.IdEvento;
            convidado.Data_criacao = DateTime.Now;
            convidado.Data_modificacao = DateTime.Now;
            convidado.Ativo = true;
            convidado.Aceitou_convite = null;

            EventoService eventoService = new EventoService(_dbContext);
            Evento? evento = await eventoService.GetEventoById(convidado.IdEvento); 

            Convidado convidadoResponse = await convidadoService.CriarConvidado(convidado);
            var link = "http://127.0.0.1:5501/index.html?token=";

            string mailMessage =
                    "<center><table style='margin-left: auto; margin-right: auto; width: 50%; text-align: center; background-color: #fdfdfd;'>"
                    + "<thead><tr><td style='height: 25px;'></td></tr>"
                    + "<tr><td style='height: 25px;'><h1>FAZ ACONTECER</h1></tr>"
                    + "<tr><td style='height: 25px;'></td></tr></thead>"

                    + "<tbody><tr><td><div style='width: 80%; height: 1px; background-color: #777676; margin-left: auto; margin-right: auto;'></div></td></tr></tbody>"

                    + "<tbody><tr><td><h3>Você recebeu um convite do evento " + evento?.Nome + "</h3></td></tr></tbody>"

                    + "<tbody>"
                    + "<tr id='button' style='margin-left:auto; margin-right:auto'><td style='padding: 20px 45px; text-align: left;'>" 
                    + "<a href=\"" + link + convidado.Id + "\" target=\"_blank\"" 
                    + "style='text-decoration:none; color:#fff; text-transform:uppercase; font-weight:600; background-color:rgba(107, 108, 196, 1);" 
                    + "border-radius:7px; padding: 10px 25px;' data-linkindex='1'>ACESSAR MEU CONVITE" 
                    + "</a>"
                    + "</td></tr></tbody>"

                    + "</table></center>";

            AuthMessageSender emailSender = new AuthMessageSender(_emailSettings);
            await emailSender.SendEmailAsync(convidado.Email, "FazAcontecer - Convite", mailMessage);

            return Ok(convidadoResponse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutConvidado(int id, AtualizarConvidado atualizarConvidado)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            Convidado convidado = new Convidado();
            convidado.Nome = atualizarConvidado.Nome;
            convidado.Telefone = atualizarConvidado.Telefone;
            convidado.Email = atualizarConvidado.Email;
            convidado.Ativo = atualizarConvidado.Ativo;
            convidado.Aceitou_convite = atualizarConvidado.Aceitou_convite;

            var existingConvidado = await convidadoService.GetConvidadoById(id);

            if (existingConvidado == null)
            {
                return NotFound();
            }

            Convidado convidadoAtualizado = await convidadoService.AtualizarConvidado(existingConvidado, convidado);

            return Ok(convidadoAtualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConvidado(int id)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);

            var convidado = await convidadoService.GetConvidadoById(id);

            if (convidado == null)
            {
                return NotFound();
            }

            await convidadoService.DeletarConvidado(convidado);

            return NoContent();
        }

        [HttpPut("ResponderConvite")]
        public async Task<IActionResult> PutResponderConvite(int convidadoId, bool resposta)
        {
            ConvidadoService convidadoService = new ConvidadoService(_dbContext);
            
            var existingConvidado = await convidadoService.GetConvidadoById(convidadoId);

            if (existingConvidado == null)
            {
                return NotFound();
            }

            Convidado convidadoAtualizado = await convidadoService.ResponderConvite(existingConvidado, resposta);

            return Ok(convidadoAtualizado);
        }

    }
}