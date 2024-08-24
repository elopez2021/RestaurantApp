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
    internal class ProductoRepository : BaseRepository, IProductoRepository
    {
        public ProductoRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public void Add(ProductoModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = "INSERT INTO Productos (CodigoProducto, Nombre, IdCategoria, PrecioVenta, IdImpuesto, IdProveedor, PrecioCompra, Descuento, Existencia, NoLote, StockMinimo, StockMaximo, FechaElaboracion, FechaExpiracion, CodigoDeBarra, RutaFoto, Estado, EsProductoFinal) " +
                            "VALUES (@CodigoProducto, @Nombre, @IdCategoria, @PrecioVenta, @IdImpuesto, @IdProveedor, @PrecioCompra, @Descuento, @Existencia, @NoLote, @StockMinimo, @StockMaximo, @FechaElaboracion, @FechaExpiracion, @CodigoDeBarra, @RutaFoto, @Estado, @EsProductoFinal);";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodigoProducto", model.CodigoProducto);
                    command.Parameters.AddWithValue("@Nombre", model.Nombre);
                    command.Parameters.AddWithValue("@IdCategoria", model.IdCategoria);
                    command.Parameters.AddWithValue("@PrecioVenta", model.PrecioVenta);
                    command.Parameters.AddWithValue("@IdImpuesto", model.IdImpuesto);
                    command.Parameters.AddWithValue("@IdProveedor", (object)model.IdProveedor ?? DBNull.Value);
                    command.Parameters.AddWithValue("@PrecioCompra", (object)model.PrecioCompra ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Descuento", (object)model.Descuento ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Existencia", (object)model.Existencia ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NoLote", (object)model.NoLote ?? DBNull.Value);
                    command.Parameters.AddWithValue("@StockMinimo", (object)model.StockMinimo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@StockMaximo", (object)model.StockMaximo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaElaboracion", (object)model.FechaElaboracion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FechaExpiracion", (object)model.FechaExpiracion ?? DBNull.Value);
                    command.Parameters.AddWithValue("@CodigoDeBarra", (object)model.CodigoDeBarra ?? DBNull.Value);
                    command.Parameters.AddWithValue("@RutaFoto", model.RutaFoto);
                    command.Parameters.AddWithValue("@Estado", model.Estado);
                    command.Parameters.AddWithValue("@EsProductoFinal", model.EsProductoFinal);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                    UPDATE productos SET estado = 0 WHERE idproducto = @IdProducto";
                command.Parameters.Add("@IdProducto", SqlDbType.NVarChar).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProductoModel> GetAll()
        {
            var list = new List<ProductoModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT 
                    p.*,
                    c.Nombre AS CategoriaNombre,
                    i.Nombre AS ImpuestoNombre,
                    i.porcentaje AS ImpuestoPorcentaje,
                    pr.Nombre AS ProveedorNombre
                FROM 
                    Productos p
                INNER JOIN 
                    Categorias c ON p.IdCategoria = c.IdCategoria
                INNER JOIN 
                    Impuestos i ON p.IdImpuesto = i.IdImpuesto
                LEFT JOIN 
                    Proveedor pr ON p.IdProveedor = pr.IdProveedor
                WHERE p.estado = 1
                ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new ProductoModel
                        {
                            IdProducto = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : default,
                            CodigoProducto = reader["CodigoProducto"] != DBNull.Value ? reader["CodigoProducto"].ToString() : string.Empty,
                            Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty,
                            IdCategoria = (int)reader["IdCategoria"],
                            IdImpuesto = (int)reader["Idimpuesto"],
                            PorcentajeImpuesto = (decimal)reader["ImpuestoPorcentaje"],
                            IdProveedor = reader["IdProveedor"] != DBNull.Value ? (int)reader["IdProveedor"] : (int?)null,
                            PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioVenta"]) : default,
                            PrecioCompra = reader["PrecioCompra"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioCompra"]) : default,
                            Descuento = reader["Descuento"] != DBNull.Value ? Convert.ToDecimal(reader["Descuento"]) : default,
                            Existencia = reader["Existencia"] != DBNull.Value ? Convert.ToInt32(reader["Existencia"]) : default,
                            NoLote = reader["NoLote"] != DBNull.Value ? reader["NoLote"].ToString() : string.Empty,
                            StockMinimo = reader["StockMinimo"] != DBNull.Value ? Convert.ToInt32(reader["StockMinimo"]) : default,
                            StockMaximo = reader["StockMaximo"] != DBNull.Value ? Convert.ToInt32(reader["StockMaximo"]) : default,
                            FechaElaboracion = reader["FechaElaboracion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaElaboracion"]) : (DateTime?)null,
                            FechaExpiracion = reader["FechaExpiracion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaExpiracion"]) : (DateTime?)null,
                            CodigoDeBarra = reader["CodigoDeBarra"] != DBNull.Value ? reader["CodigoDeBarra"].ToString() : string.Empty,
                            RutaFoto = reader["RutaFoto"] != DBNull.Value ? reader["RutaFoto"].ToString() : string.Empty,
                            Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : default,
                            EsProductoFinal = reader["EsProductoFinal"] != DBNull.Value ? Convert.ToBoolean(reader["EsProductoFinal"]) : default,
                            Categoria = reader["CategoriaNombre"] != DBNull.Value ? reader["CategoriaNombre"].ToString() : string.Empty,
                            Impuesto = reader["ImpuestoNombre"] != DBNull.Value ? reader["ImpuestoNombre"].ToString() : string.Empty,
                            Proveedor = reader["ProveedorNombre"] != DBNull.Value ? reader["ProveedorNombre"].ToString() : string.Empty
                        };

                        list.Add(producto);
                    }
                }
            }

            return list;

        }

        public IEnumerable<ProductoModel> GetAllNotExpired()
        {
            var list = new List<ProductoModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT 
                    p.*,
                    c.Nombre AS CategoriaNombre,
                    i.Nombre AS ImpuestoNombre,
                    i.porcentaje AS ImpuestoPorcentaje,
                    pr.Nombre AS ProveedorNombre
                FROM 
                    Productos p
                INNER JOIN 
                    Categorias c ON p.IdCategoria = c.IdCategoria
                INNER JOIN 
                    Impuestos i ON p.IdImpuesto = i.IdImpuesto
                LEFT JOIN 
                    Proveedor pr ON p.IdProveedor = pr.IdProveedor
                WHERE p.estado = 1 AND (p.fechaexpiracion > GETDATE() OR esproductofinal = 1)
                ";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new ProductoModel
                        {
                            IdProducto = reader["IdProducto"] != DBNull.Value ? Convert.ToInt32(reader["IdProducto"]) : default,
                            CodigoProducto = reader["CodigoProducto"] != DBNull.Value ? reader["CodigoProducto"].ToString() : string.Empty,
                            Nombre = reader["Nombre"] != DBNull.Value ? reader["Nombre"].ToString() : string.Empty,
                            IdCategoria = (int)reader["IdCategoria"],
                            IdImpuesto = (int)reader["Idimpuesto"],
                            PorcentajeImpuesto = (decimal)reader["ImpuestoPorcentaje"],
                            IdProveedor = reader["IdProveedor"] != DBNull.Value ? (int)reader["IdProveedor"] : (int?)null,
                            PrecioVenta = reader["PrecioVenta"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioVenta"]) : default,
                            PrecioCompra = reader["PrecioCompra"] != DBNull.Value ? Convert.ToDecimal(reader["PrecioCompra"]) : default,
                            Descuento = reader["Descuento"] != DBNull.Value ? Convert.ToDecimal(reader["Descuento"]) : default,
                            Existencia = reader["Existencia"] != DBNull.Value ? Convert.ToInt32(reader["Existencia"]) : default,
                            NoLote = reader["NoLote"] != DBNull.Value ? reader["NoLote"].ToString() : string.Empty,
                            StockMinimo = reader["StockMinimo"] != DBNull.Value ? Convert.ToInt32(reader["StockMinimo"]) : default,
                            StockMaximo = reader["StockMaximo"] != DBNull.Value ? Convert.ToInt32(reader["StockMaximo"]) : default,
                            FechaElaboracion = reader["FechaElaboracion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaElaboracion"]) : (DateTime?)null,
                            FechaExpiracion = reader["FechaExpiracion"] != DBNull.Value ? Convert.ToDateTime(reader["FechaExpiracion"]) : (DateTime?)null,
                            CodigoDeBarra = reader["CodigoDeBarra"] != DBNull.Value ? reader["CodigoDeBarra"].ToString() : string.Empty,
                            RutaFoto = reader["RutaFoto"] != DBNull.Value ? reader["RutaFoto"].ToString() : string.Empty,
                            Estado = reader["Estado"] != DBNull.Value ? Convert.ToBoolean(reader["Estado"]) : default,
                            EsProductoFinal = reader["EsProductoFinal"] != DBNull.Value ? Convert.ToBoolean(reader["EsProductoFinal"]) : default,
                            Categoria = reader["CategoriaNombre"] != DBNull.Value ? reader["CategoriaNombre"].ToString() : string.Empty,
                            Impuesto = reader["ImpuestoNombre"] != DBNull.Value ? reader["ImpuestoNombre"].ToString() : string.Empty,
                            Proveedor = reader["ProveedorNombre"] != DBNull.Value ? reader["ProveedorNombre"].ToString() : string.Empty
                        };

                        list.Add(producto);
                    }
                }
            }

            return list;
        }

        public void Update(ProductoModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var query = "UPDATE Productos SET " +
                            "CodigoProducto = @CodigoProducto, " +
                            "Nombre = @Nombre, " +
                            "IdCategoria = @IdCategoria, " +
                            "PrecioVenta = @PrecioVenta, " +
                            "IdImpuesto = @IdImpuesto, " +
                            "IdProveedor = @IdProveedor, " +
                            "PrecioCompra = @PrecioCompra, " +
                            "Descuento = @Descuento, " +
                            "Existencia = @Existencia, " +
                            "NoLote = @NoLote, " +
                            "StockMinimo = @StockMinimo, " +
                            "StockMaximo = @StockMaximo, " +
                            "FechaElaboracion = @FechaElaboracion, " +
                            "FechaExpiracion = @FechaExpiracion, " +
                            "CodigoDeBarra = @CodigoDeBarra, " +
                            "RutaFoto = @RutaFoto, " +
                            "Estado = @Estado, " +
                            "EsProductoFinal = @EsProductoFinal " +
                            "WHERE IdProducto = @IdProducto;";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CodigoProducto", model.CodigoProducto);
                    command.Parameters.AddWithValue("@Nombre", model.Nombre);
                    command.Parameters.AddWithValue("@IdCategoria", model.IdCategoria);
                    command.Parameters.AddWithValue("@PrecioVenta", model.PrecioVenta);
                    command.Parameters.AddWithValue("@IdImpuesto", model.IdImpuesto);
                    command.Parameters.AddWithValue("@IdProveedor", model.EsProductoFinal ? (object)model.IdProveedor ?? DBNull.Value : (object)model.IdProveedor);
                    command.Parameters.AddWithValue("@PrecioCompra", model.EsProductoFinal ? (object)model.PrecioCompra ?? DBNull.Value : (object)model.PrecioCompra);
                    command.Parameters.AddWithValue("@Descuento", model.EsProductoFinal ? (object)model.Descuento ?? DBNull.Value : (object)model.Descuento);
                    command.Parameters.AddWithValue("@Existencia", model.EsProductoFinal ? (object)model.Existencia ?? DBNull.Value : (object)model.Existencia);
                    command.Parameters.AddWithValue("@NoLote", model.EsProductoFinal ? (object)model.NoLote ?? DBNull.Value : (object)model.NoLote);
                    command.Parameters.AddWithValue("@StockMinimo", model.EsProductoFinal ? (object)model.StockMinimo ?? DBNull.Value : (object)model.StockMinimo);
                    command.Parameters.AddWithValue("@StockMaximo", model.EsProductoFinal ? (object)model.StockMaximo ?? DBNull.Value : (object)model.StockMaximo);
                    command.Parameters.AddWithValue("@FechaElaboracion", model.EsProductoFinal ? (object)model.FechaElaboracion ?? DBNull.Value : (object)model.FechaElaboracion);
                    command.Parameters.AddWithValue("@FechaExpiracion", model.EsProductoFinal ? (object)model.FechaExpiracion ?? DBNull.Value : (object)model.FechaExpiracion);
                    command.Parameters.AddWithValue("@CodigoDeBarra", model.EsProductoFinal ? (object)model.CodigoDeBarra ?? DBNull.Value : (object)model.CodigoDeBarra);
                    command.Parameters.AddWithValue("@RutaFoto", model.RutaFoto);
                    command.Parameters.AddWithValue("@Estado", model.Estado);
                    command.Parameters.AddWithValue("@EsProductoFinal", model.EsProductoFinal);
                    command.Parameters.AddWithValue("@IdProducto", model.IdProducto);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
