using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCORE6.Domain;
using NETCORE6.Models;

namespace NETCORE6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        //public readonly BancoProductosContext _dbcontext;

        //public ProductoController(BancoProductosContext _context)
        //{
        //    _dbcontext = _context;
        //}

        //[HttpGet]
        //[Route("Lista")]
        //public IActionResult Lista()
        //{
        //    List<Producto> lista = new List<Producto>();

        //    try
        //    {
        //        lista = _dbcontext.Productos.ToList();
        //        return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
        //    }
        //    catch (Exception ex)
        //    {

        //        return StatusCode(StatusCodes.Status200OK, new { mensaje = "nel", response = lista });

        //    }
        //}
        private readonly IProductoFactory _productoFactory;

        public ProductoController(IProductoFactory serviceFactory)
        {
            _productoFactory = serviceFactory;
        }


        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista2()
        {

            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = _productoFactory.ListaProductos() });
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult ObtenerProducto(int id)
        {
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = _productoFactory.ObtenerProductos(id) });
        }

        [HttpPost]
        //[Route("Crear")]
        public IActionResult CrearProducto(Producto producto)
        {
            return StatusCode(StatusCodes.Status201Created, new { mensaje = "Producto creado exitosamente", response = _productoFactory.CrearProducto(producto) });

        }
    }
}
