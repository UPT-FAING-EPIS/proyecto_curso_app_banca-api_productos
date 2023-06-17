using Microsoft.AspNetCore.Mvc;
using NETCORE6.Models;

namespace NETCORE6.Domain
{
    public interface IProductoFactory
    {
        List<Producto> ListaProductos();
        Producto ObtenerProductos(int id);

        Producto CrearProducto(Producto producto);

    }
   
}
