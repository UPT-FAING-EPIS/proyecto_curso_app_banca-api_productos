using ApiBanca.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
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


		public bool Registrar(ClientesProductos oClientesProd)
		{
			using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
			{
				SqlCommand cmd = new SqlCommand("ups_registrar_ClienteProducto", oConexion);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id_cliente", oClientesProd.id_cliente);
				cmd.Parameters.AddWithValue("@id_producto", oClientesProd.id_producto);
				cmd.Parameters.AddWithValue("@fecha_inicio", oClientesProd.fecha_inicio);
				cmd.Parameters.AddWithValue("@fecha_vencimiento", oClientesProd.fecha_vencimiento);
				cmd.Parameters.AddWithValue("@saldo", oClientesProd.saldo);
				cmd.Parameters.AddWithValue("@limite_credito", oClientesProd.limite_credito);
				cmd.Parameters.AddWithValue("@tasa_interes", oClientesProd.tasa_interes);
				cmd.Parameters.AddWithValue("@prima", oClientesProd.prima);

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

		public ClientesProductos Obtener(int id)
		{
			ClientesProductos oCliProducto = new ClientesProductos();
			using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
			{
				SqlCommand cmd = new SqlCommand("ups_obtener_ClienteProducto", oConexion);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.AddWithValue("@id", id);

				try
				{
					oConexion.Open();
					cmd.ExecuteNonQuery();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{

						while (dr.Read())
						{
							oCliProducto = new ClientesProductos()
							{
								id = Convert.ToInt32(dr["id"]),
								id_cliente = dr["id_cliente"].ToString(),
								id_producto = dr["id_producto"].ToString(),
								fecha_inicio = dr["fecha_inicio"].ToString(),
								fecha_vencimiento = dr["fecha_vencimiento"].ToString(),
								saldo = dr["saldo"].ToString(),
								limite_credito = dr["limite_credito"].ToString(),
								tasa_interes = dr["tasa_interes"].ToString(),
								prima = dr["prima"].ToString(),
							};
						}

					}



					return oCliProducto;
				}
				catch (Exception ex)
				{
					return oCliProducto;
				}
			}
		}

		public List<ClientesProductos> Listar()
		{
			List<ClientesProductos> oListaCliProducto = new List<ClientesProductos>();
			using (SqlConnection oConexion = new SqlConnection(Conexion.rutaConexion))
			{
				SqlCommand cmd = new SqlCommand("ups_listar_ClienteProducto", oConexion);
				cmd.CommandType = CommandType.StoredProcedure;

				try
				{
					oConexion.Open();
					cmd.ExecuteNonQuery();

					using (SqlDataReader dr = cmd.ExecuteReader())
					{

						while (dr.Read())
						{
							oListaCliProducto.Add(new ClientesProductos()
							{
								id = Convert.ToInt32(dr["id"]),
								id_cliente = dr["id_cliente"].ToString(),
								id_producto = dr["id_producto"].ToString(),
								fecha_inicio = dr["fecha_inicio"].ToString(),
								fecha_vencimiento = dr["fecha_vencimiento"].ToString(),
								saldo = dr["saldo"].ToString(),
								limite_credito = dr["limite_credito"].ToString(),
								tasa_interes = dr["tasa_interes"].ToString(),
								prima = dr["prima"].ToString(),
							});
						}

					}



					return oListaCliProducto;
				}
				catch (Exception ex)
				{
					return oListaCliProducto;
				}
			}
		}

	}
}