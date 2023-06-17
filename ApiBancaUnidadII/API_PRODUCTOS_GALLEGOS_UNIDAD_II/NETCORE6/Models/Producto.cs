using System;
using System.Collections.Generic;

namespace NETCORE6.Models;

public partial class Producto
{
    public int Id { get;  }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<ClientesProducto> ClientesProductos { get; } = new List<ClientesProducto>();
}
