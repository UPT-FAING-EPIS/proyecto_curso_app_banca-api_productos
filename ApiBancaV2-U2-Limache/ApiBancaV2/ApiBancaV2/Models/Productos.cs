using ApiBanca.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiBanca.Models
{
    public class Productos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public string tipo { get; set; }



        public bool Registrar(Productos oProducto)
        {
			using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
			{
				SqlCommand cmd = new SqlCommand("usp_registrar", oConexion);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@nombre", oProducto.nombre);
				cmd.Parameters.AddWithValue("@descripcion", oProducto.descripcion);
				cmd.Parameters.AddWithValue("@tipo", oProducto.tipo);

				try
				{
					oConexion.Open();
					cmd.ExecuteNonQuery();
					return true;
				}
				catch (Exception ex)
				{
					return false;
				}
			}
		}

		public Productos Obtener(int idproducto)
		{
			Productos oProducto = new Productos();
			using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
			{
				SqlCommand cmd = new SqlCommand("usp_obtener", oConexion);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", idproducto);

				try
				{
					oConexion.Open();
					cmd.ExecuteNonQuery();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{

						while (dr.Read())
						{
							oProducto = new Productos()
							{
								id = Convert.ToInt32(dr["id"]),
								nombre = dr["nombre"].ToString(),
								descripcion = dr["descripcion"].ToString(),
								tipo = dr["tipo"].ToString(),
							};
						}

					}



					return oProducto;
				}
				catch (Exception ex)
				{
					return oProducto;
				}
			}

		}
		public List<Productos> Listar()
		{
			List<Productos> oListaProducto = new List<Productos>();
			using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
			{
				SqlCommand cmd = new SqlCommand("usp_listar", oConexion);
				cmd.CommandType = CommandType.StoredProcedure;

				try
				{
					oConexion.Open();
					cmd.ExecuteNonQuery();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{

						while (dr.Read())
						{
							oListaProducto.Add(new Productos()
							{
								id = Convert.ToInt32(dr["id"]),
								nombre = dr["nombre"].ToString(),
								descripcion = dr["descripcion"].ToString(),
								tipo = dr["tipo"].ToString(),
							});
						}

					}



					return oListaProducto;
				}
				catch (Exception ex)
				{
					return oListaProducto;
				}
			}
		}

	}
}