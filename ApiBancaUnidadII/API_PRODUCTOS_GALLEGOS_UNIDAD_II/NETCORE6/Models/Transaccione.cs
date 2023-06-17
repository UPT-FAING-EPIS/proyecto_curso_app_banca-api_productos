using System;
using System.Collections.Generic;

namespace NETCORE6.Models;

public partial class Transaccione
{
    public int Id { get; set; }

    public string TipoTransaccion { get; set; } = null!;

    public decimal Monto { get; set; }

    public DateTime FechaTransaccion { get; set; }

    public int? IdClienteProductoOrigen { get; set; }

    public int? IdClienteProductoDestino { get; set; }

    public virtual ClientesProducto? IdClienteProductoDestinoNavigation { get; set; }

    public virtual ClientesProducto? IdClienteProductoOrigenNavigation { get; set; }
}
