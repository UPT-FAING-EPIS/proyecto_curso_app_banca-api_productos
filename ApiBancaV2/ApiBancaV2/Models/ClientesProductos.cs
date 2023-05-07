using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiBancaV2.Models
{
    public class ClientesProductos
    {
        public int id { get; set; }
        public string id_cliente { get; set; }
        public string id_producto { get; set; }
        public string fecha_inicio { get; set; }
        public string fecha_vencimiento { get; set; }
        public string saldo { get; set; }
        public string limite_credito { get; set; }
        public string tasa_interes { get; set; }
        public string prima { get; set; }

    }
}