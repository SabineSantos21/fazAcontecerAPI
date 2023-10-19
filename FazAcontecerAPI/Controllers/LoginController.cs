using FazAcontecerAPI;
using FazAcontecerAPI.Models;
using FazAcontecerAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace FazAcontecerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ConnectionDB _dbContext;

        public LoginController(ConnectionDB dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            LoginService loginService = new LoginService(_dbContext);
            
            Usuario? usuario = loginService.ValidarCredenciais(login.Email, login.Senha);


            if (usuario != null)
            {
                usuario.Token = loginService.GerarTokenJWT(login.Email);
                
                return Ok(usuario);
            } 
            else
            {
                return Unauthorized();
            }
        }
    }
}