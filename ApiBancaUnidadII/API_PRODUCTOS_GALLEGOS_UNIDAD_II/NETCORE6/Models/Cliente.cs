using System;
using System.Collections.Generic;

namespace NETCORE6.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<ClientesProducto> ClientesProductos { get; set; } = new List<ClientesProducto>();
}
