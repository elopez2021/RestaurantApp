using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Models;

namespace Restaurant.Repositories
{
    internal class VentasRepository : BaseRepository, IVentasReportRepository
    {
        public VentasRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public (decimal Total, decimal Subtotal, decimal Impuesto) GetVentasTotals(int month, int year)
        {
            decimal total = 0m;
            decimal subtotal = 0m;
            decimal impuesto = 0m;

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT 
                    SUM(total) AS Total, 
                    SUM(subtotal) AS SubTotal, 
                    SUM(impuesto) AS Impuesto 
                FROM facturas
                WHERE 
                    MONTH(fecha) = @Month AND YEAR(fecha) = @Year";

                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        // Check if fields are not null
                        total = reader["Total"] != DBNull.Value ? (decimal)reader["Total"] : 0m;
                        subtotal = reader["Subtotal"] != DBNull.Value ? (decimal)reader["Subtotal"] : 0m;
                        impuesto = reader["Impuesto"] != DBNull.Value ? (decimal)reader["Impuesto"] : 0m;
                    }
                }
            }

            return (total, subtotal, impuesto);
        }


        public IEnumerable<VentaReportModel> GetVentasPorCategoria(int month, int year)
        {
            var ventasList = new List<VentaReportModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("GetVentasPorCategoria", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var venta = new VentaReportModel
                        {
                            Nombre = reader["Categoria"].ToString(),
                            Cantidad = (int)reader["Cantidad"], 
                            Subtotal = Math.Round((decimal)reader["Subtotal"], 2),
                            Impuesto = Math.Round((decimal)reader["Impuesto"], 2),
                            Total = Math.Round((decimal)reader["Total"], 2)
                        };

                        ventasList.Add(venta);
                    }
                }
            }

            return ventasList;

        }

        public IEnumerable<VentaReportModel> GetVentasPorProducto(int month, int year)
        {
            var ventasList = new List<VentaReportModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("GetVentasPorProducto", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var venta = new VentaReportModel
                        {
                            Nombre = reader["Producto"].ToString(),
                            Cantidad = (int)reader["Cantidad"],
                            Subtotal = Math.Round((decimal)reader["Subtotal"], 2),
                            Impuesto = Math.Round((decimal)reader["Impuesto"], 2),
                            Total = Math.Round((decimal)reader["Total"], 2)
                        };

                        ventasList.Add(venta);
                    }
                }
            }

            return ventasList;

        }

        public IEnumerable<VentaReportModel> GetVentasPorUsuario(int month, int year)
        {
            var ventasList = new List<VentaReportModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand("GetVentasPorUsuario", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Month", month);
                command.Parameters.AddWithValue("@Year", year);

                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var venta = new VentaReportModel
                        {
                            Nombre = reader["Usuario"].ToString(),
                            Cantidad = (int)reader["Cantidad"], 
                            Subtotal = Math.Round((decimal)reader["Subtotal"], 2),
                            Impuesto = Math.Round((decimal)reader["Impuesto"], 2),
                            Total = Math.Round((decimal)reader["Total"], 2)
                        };

                        ventasList.Add(venta);
                    }
                }
            }

            return ventasList;

        }

    }
}
