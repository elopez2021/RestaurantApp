using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class PedidoRepository : BaseRepository, IPedidoRepository
    {
        public PedidoRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public int Add(PedidoModel pedido, List<PedidoProductoModel> pedidoProductos)
        {
            int idPedido = 0;
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        idPedido = InsertPedido(connection, transaction, pedido);

                        foreach (var producto in pedidoProductos)
                        {
                            InsertPedidoProducto(connection, transaction, idPedido, producto);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new ApplicationException(pedido.IdUsuario + " " +"Ocurrió un error al guardar el pedido: " + ex.Message, ex);
                    }
                }
            }
            return idPedido;
        }

        private int InsertPedido(SqlConnection connection, SqlTransaction transaction, PedidoModel pedido)
        {
            var query = @"
            INSERT INTO pedidos (idusuario, idcliente, cliente, idmesa, total, subtotal, impuesto, estado)
            VALUES (@IdUsuario, @IdCliente, @Cliente, @IdMesa, @Total, @SubTotal, @Impuesto, @Estado);
            SELECT SCOPE_IDENTITY();
            UPDATE mesas SET disponible = 0 WHERE idmesa = @IdMesa;
            ";
            

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdUsuario", pedido.IdUsuario);
                command.Parameters.AddWithValue("@IdCliente", (object)pedido.IdCliente ?? DBNull.Value);
                command.Parameters.AddWithValue("@Cliente", (object)pedido.Cliente ?? DBNull.Value);
                command.Parameters.AddWithValue("@IdMesa", pedido.IdMesa);
                command.Parameters.AddWithValue("@Total", pedido.Total);
                command.Parameters.AddWithValue("@SubTotal", pedido.SubTotal);
                command.Parameters.AddWithValue("@Impuesto", pedido.Impuesto);
                command.Parameters.AddWithValue("@Estado", pedido.Estado);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void InsertPedidoProducto(SqlConnection connection, SqlTransaction transaction, int idPedido, PedidoProductoModel producto)
        {
            var query = @"
            INSERT INTO pedidoproducto (idpedido, idproducto, cantidad, preciounitario, preciototal)
            VALUES (@IdPedido, @IdProducto, @Cantidad, @PrecioUnitario, @PrecioTotal);";

            using (var command = new SqlCommand(query, connection, transaction))
            {
                command.Parameters.AddWithValue("@IdPedido", idPedido);
                command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                command.Parameters.AddWithValue("@Cantidad", producto.Cantidad);
                command.Parameters.AddWithValue("@PrecioUnitario", producto.PrecioUnitario);
                command.Parameters.AddWithValue("@PrecioTotal", producto.PrecioTotal);

                command.ExecuteNonQuery();
            }
        }
        
        public IEnumerable<PedidoProductoModel> GetPedidoProductos(int idPedido)
        {
            var pedidoProductoList = new List<PedidoProductoModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT pp.idpedido, 
                       pp.idproducto, 
                       pp.cantidad, 
                       pp.preciounitario, 
                       pp.preciototal, 
                       pp.preciounitario * cantidad * (i.porcentaje / 100) AS Impuesto, 
                       pr.codigoproducto AS Codigo,
                       pr.nombre AS NombreProducto
                FROM pedidoproducto pp
                INNER JOIN productos pr ON pp.idproducto = pr.idproducto
                INNER JOIN impuestos i ON pr.idimpuesto = i.idimpuesto
                WHERE pp.idpedido = @idPedido";

                command.Parameters.AddWithValue("@idPedido", idPedido);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pedidoProducto = new PedidoProductoModel
                        {
                            IdPedido = (int)reader["idpedido"],
                            IdProducto = (int)reader["idproducto"],
                            NombreProducto = reader["NombreProducto"].ToString(),
                            Cantidad = (int)reader["cantidad"],
                            Impuesto = Math.Round((decimal)reader["Impuesto"],2),
                            CodigoProducto = reader["Codigo"].ToString(),
                            PrecioUnitario = (decimal)reader["preciounitario"],
                            PrecioTotal = (decimal)reader["preciototal"]
                        };

                        pedidoProductoList.Add(pedidoProducto);
                    }
                }
            }

            return pedidoProductoList;
        }

        public IEnumerable<PedidoModel> GetAllPendientes()
        {
            var list = new List<PedidoModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT p.idpedido, p.idusuario, p.idcliente, p.cliente, p.idmesa, p.total, p.fecha, p.estado, p.subtotal, p.impuesto,
                       u.nombre AS NombreUsuario, 
                       m.nombre AS NombreMesa
                FROM pedidos p
                INNER JOIN usuarios u ON p.idusuario = u.idusuario
                INNER JOIN mesas m ON p.idmesa = m.idmesa
                WHERE p.estado = 0";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pedido = new PedidoModel
                        {
                            IdPedido = (int)reader["idpedido"],
                            IdUsuario = (int)reader["idusuario"],
                            NombreUsuario = reader["NombreUsuario"].ToString(),
                            IdCliente = reader["idcliente"] as int?,
                            Cliente = reader["cliente"].ToString(),
                            IdMesa = (int)reader["idmesa"],
                            NombreMesa = reader["NombreMesa"].ToString(),
                            Impuesto = (decimal)reader["impuesto"],
                            SubTotal = (decimal)reader["subtotal"],
                            Total = (decimal)reader["total"],
                            Fecha = (DateTime)reader["fecha"],
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(pedido);
                    }
                }
            }

            return list;
        }

        public void SetPedidoEntregado(int idPedido, int idMesa)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                UPDATE pedidos 
                SET estado = 1 
                WHERE idpedido = @IdPedido;
                
                UPDATE mesas SET disponible = 1 WHERE idmesa = @IdMesa;
                ";

                command.Parameters.AddWithValue("@IdPedido", idPedido);
                command.Parameters.AddWithValue("@IdMesa", idMesa);

                command.ExecuteNonQuery();
            }
        }
    }
}
