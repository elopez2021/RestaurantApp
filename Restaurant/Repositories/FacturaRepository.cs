using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class FacturaRepository : BaseRepository, IFacturaRepository
    {
        public FacturaRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public int Add(FacturaModel model)
        {
            int id = 0;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                INSERT INTO facturas
                (idpedido, total, subtotal, impuesto)
                VALUES 
                (@IdPedido, @Total, @SubTotal, @Impuesto)
                SELECT SCOPE_IDENTITY();";

                command.Parameters.Add("@IdPedido", SqlDbType.Int).Value = model.IdPedido;
                command.Parameters.Add("@Total", SqlDbType.Decimal).Value = model.Total;
                command.Parameters.Add("@Impuesto", SqlDbType.Decimal).Value = model.Impuesto;
                command.Parameters.Add("@SubTotal", SqlDbType.Decimal).Value = model.SubTotal;

                id = Convert.ToInt32(command.ExecuteScalar());
             }

            return id;
        }

        public FacturaModel GetFacturaById(int id)
        {
            FacturaModel factura = null;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT f.idfactura, f.idpedido, f.total, f.subtotal, f.impuesto, f.estado, f.fecha,
                       p.cliente AS NombreCliente, u.nombre AS NombreUsuario
                FROM facturas f
                INNER JOIN pedidos p ON f.idpedido = p.idpedido
                INNER JOIN usuarios u ON p.idusuario = u.idusuario
                WHERE f.idfactura = @IdFactura";

                command.Parameters.Add("@IdFactura", SqlDbType.Int).Value = id;

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        factura = new FacturaModel
                        {
                            IdFactura = (int)reader["idfactura"],
                            IdPedido = (int)reader["idpedido"],
                            Total = (decimal)reader["total"],
                            SubTotal = (decimal)reader["subtotal"],
                            Impuesto = (decimal)reader["impuesto"],
                            Estado = (bool)reader["estado"],
                            Fecha = (DateTime)reader["fecha"],
                            NombreCliente = reader["NombreCliente"].ToString(),
                            NombreUsuario = reader["NombreUsuario"].ToString()
                        };
                    }
                }
            }

            return factura;
        }


        public void ChangeStatusToPaid(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                UPDATE facturas SET estado = 1 WHERE idfactura = @IdFactura;";

                command.Parameters.Add("@IdFactura", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<FacturaModel> GetAll()
        {
            var facturasList = new List<FacturaModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT f.*,
                       p.cliente AS NombreCliente,
                       u.nombre AS NombreUsuario
                FROM facturas f
                INNER JOIN pedidos p ON f.idpedido = p.idpedido
                INNER JOIN usuarios u ON p.idusuario = u.idusuario";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var factura = new FacturaModel
                        {
                            IdFactura = (int)reader["idfactura"],
                            IdPedido = (int)reader["idpedido"],
                            Total = (decimal)reader["total"],
                            SubTotal = (decimal)reader["subtotal"],
                            Impuesto = (decimal)reader["impuesto"],
                            Estado = (bool)reader["estado"],
                            Fecha = (DateTime)reader["fecha"],
                            NombreCliente = reader["NombreCliente"].ToString(),
                            NombreUsuario = reader["NombreUsuario"].ToString()
                        };

                        facturasList.Add(factura);
                    }
                }
            }

            return facturasList;
        }
        
    }
}
