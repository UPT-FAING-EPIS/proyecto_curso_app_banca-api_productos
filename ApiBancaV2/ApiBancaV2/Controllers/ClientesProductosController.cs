using ApiBancaV2.Data;
using ApiBancaV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiBancaV2.Controllers
{
    public class ClientesProductosController : ApiController
    {
        // GET api/<controller>
        public List<ClientesProductos> Get()
        {
            return ClientesProductosData.Listar();
        }

        // GET api/<controller>/5
        public ClientesProductos Get(int id)
        {
            return ClientesProductosData.Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] ClientesProductos oClientesProductos)
        {
            return ClientesProductosData.Registrar(oClientesProductos);
        }

        // PUT api/<controller>/5
        //public bool Put([FromBody] ClientesProductos oClientesProductos)
        //{
        //   return ClientesProductosData.Modificar(oClientesProductos);
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}