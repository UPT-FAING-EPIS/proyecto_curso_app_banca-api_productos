using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCORE6.Models;

namespace NETCORE6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoClienteController : ControllerBase
    {
        public readonly BancoProductosContext _dbcontext;

        public ProductoClienteController(BancoProductosContext _context)
        {
            _dbcontext = _context;
        }

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista()
        {
            List<ClientesProducto> lista = new List<ClientesProducto>();

            try
            {
                lista = _dbcontext.ClientesProductos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "nel", response = lista });

            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] ClientesProducto objeto)
        {
            try
            {
                _dbcontext.ClientesProductos.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }
    }
}
