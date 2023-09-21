using FazAcontecerAPI;
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
        public IActionResult Login()
        {
            LoginService loginService = new LoginService(_dbContext);

            //if (loginService.ValidarCredenciais(login.Email, login.Senha) != null)
            //{
            //    var token = loginService.GerarTokenJWT(login.Email);
            //    return Ok(new { token });
            //}

            //return Unauthorized();
            return Ok();
        }
    }
}