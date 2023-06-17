using System;
using System.Collections.Generic;

namespace NETCORE6.Models;

public partial class ClientesProducto
{
    public int Id { get; }

    public int? IdCliente { get; set; }

    public int? IdProducto { get; set; }

    public DateTime FechaInicio { get; set; }

    public DateTime? FechaVencimiento { get; set; }

    public decimal? Saldo { get; set; }

    public decimal? LimiteCredito { get; set; }

    public decimal? TasaInteres { get; set; }

    public decimal? Prima { get; set; }

    public virtual Cliente? IdClienteNavigation { get;  }

    public virtual Producto? IdProductoNavigation { get; }

    public virtual ICollection<Transaccione> TransaccioneIdClienteProductoDestinoNavigations { get; } = new List<Transaccione>();

    public virtual ICollection<Transaccione> TransaccioneIdClienteProductoOrigenNavigations { get; } = new List<Transaccione>();
}
