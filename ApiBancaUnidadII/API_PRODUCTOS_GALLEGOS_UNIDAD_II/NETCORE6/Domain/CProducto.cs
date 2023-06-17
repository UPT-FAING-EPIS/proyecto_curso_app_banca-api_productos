using NETCORE6.Models;

namespace NETCORE6.Domain
{
    public class CProducto : IProductoFactory
    {
        private readonly BancoProductosContext _dbContext;

        public CProducto(BancoProductosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Producto> ListaProductos()
        {
            List<Producto> lista = _dbContext.Productos.ToList();
            return lista;
        }

        Producto IProductoFactory.ObtenerProductos(int id)
        {
            return _dbContext.Productos.FirstOrDefault(p => p.Id == id);
        }

        public Producto CrearProducto(Producto producto)
        {
            _dbContext.Productos.Add(producto);
            _dbContext.SaveChanges();
            return producto;
        }
    }
}
