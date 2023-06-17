using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCORE6.Models;

namespace NETCORE6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        public readonly BancoProductosContext _dbcontext;

        public ClienteController(BancoProductosContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<Cliente> lista = new List<Cliente>();

            try
            {
                lista = _dbcontext.Clientes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "nel", response = lista });

            }
        }
    }
}
