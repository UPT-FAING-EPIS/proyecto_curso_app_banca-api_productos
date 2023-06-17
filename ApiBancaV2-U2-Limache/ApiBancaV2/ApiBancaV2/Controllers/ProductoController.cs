﻿using ApiBanca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiBanca.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/<controller>
        public List<Productos> Get()
        {
            return new Productos().Listar();
        }

        //GET api/<controller>/5
        public Productos Get(int id)
        {
            return new Productos().Obtener(id);
        }

        // POST api/<controller>
        public bool Post([FromBody] Productos oUsuario)
        {
            return new Productos().Registrar(oUsuario);
        }

        // PUT api/<controller>/5
        //public bool Put([FromBody] Productos oUsuario)
        //{
        //    return ProductoDate.Modificar(oUsuario);
        //}

        // DELETE api/<controller>/5
        //public bool Delete(int id)
        //{
        //    return Productos.Eliminar(id);
        //}
    }
}