using FazAcontecerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FazAcontecerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DecoracaoController : ControllerBase
    {
        private readonly ConnectionDB _dbContext;

        public DecoracaoController(ConnectionDB dbContext)
        {
            _dbContext = dbContext;
        }

    }
}