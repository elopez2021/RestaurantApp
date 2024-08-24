using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class ProveedorRepository : BaseRepository, IProveedorRepository
    {
        public ProveedorRepository(string connectionString) {
            this.connectionString = connectionString;
        }
        public void Add(ProveedorModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    INSERT INTO proveedor
                    (nodocumento, idtipodocumento, nombre, telefono, idprovincia, iddepartamento, direccion, correo, nombre_vendedor)
                    VALUES 
                    (@NoDocumento, @IdTipoDocumento, @Nombre, @Telefono, @IdProvincia, @IdDepartamento, @Direccion, @Correo, @NombreVendedor)";

                    command.Parameters.Add("@NoDocumento", SqlDbType.VarChar).Value = model.NoDocumento;
                    command.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = model.IdTipoDocumento;
                    command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = model.NombreProveedor;
                    command.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = model.Telefono;
                    command.Parameters.Add("@IdProvincia", SqlDbType.Int).Value = model.IdProvincia;
                    command.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = model.IdDepartamento;
                    command.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = model.Direccion;
                    command.Parameters.Add("@Correo", SqlDbType.VarChar).Value = model.Correo;
                    command.Parameters.Add("@NombreVendedor", SqlDbType.VarChar).Value = model.NombreVendedor;

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint violation
                {
                    if (ex.Message.Contains("unique_no_documento_proveedor"))
                    {
                        throw new Exception("El número de documento ya existe.");
                    }
                    else
                    {
                        throw new Exception("Se produjo una violación de restricción de clave única. Por favor, verifica tus datos e intenta de nuevo.");
                    }
                }
                else
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE proveedor SET estado = 0 WHERE idproveedor = @IdProveedor";
                command.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ProveedorModel> GetAll()
        {
            var proveedores = new List<ProveedorModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT 
                    p.*,
                    td.descripcion AS TipoDocumentoNombre,
                    prov.nombre AS ProvinciaNombre,
                    dep.nombre AS DepartamentoNombre
                FROM 
                    proveedor p
                INNER JOIN 
                    tipo_documento td ON p.idtipodocumento = td.idtipo
                INNER JOIN 
                    provincia prov ON p.idprovincia = prov.idprovincia
                INNER JOIN 
                    departamentos dep ON p.iddepartamento = dep.iddepartamento";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedores.Add(new ProveedorModel
                        {
                            IdProveedor = reader.GetInt32(reader.GetOrdinal("idproveedor")),
                            NoDocumento = reader.GetString(reader.GetOrdinal("nodocumento")),
                            IdTipoDocumento = reader.GetInt32(reader.GetOrdinal("idtipodocumento")),
                            NombreProveedor = reader.GetString(reader.GetOrdinal("nombre")),
                            Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                            IdProvincia = reader.GetInt32(reader.GetOrdinal("idprovincia")),
                            IdDepartamento = reader.GetInt32(reader.GetOrdinal("iddepartamento")),
                            Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                            Correo = reader.GetString(reader.GetOrdinal("correo")),
                            NombreVendedor = reader.GetString(reader.GetOrdinal("nombre_vendedor")),
                            Estado = (bool)reader["estado"],
                            TipoDocumento = reader.GetString(reader.GetOrdinal("TipoDocumentoNombre")),
                            Provincia = reader.GetString(reader.GetOrdinal("ProvinciaNombre")),
                            Departamento = reader.GetString(reader.GetOrdinal("DepartamentoNombre"))
                        });
                    }
                }
            }
            return proveedores;
        }

        public void Update(ProveedorModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    UPDATE proveedor
                    SET nodocumento = @NoDocumento,
                        idtipodocumento = @IdTipoDocumento,
                        nombre = @Nombre,
                        telefono = @Telefono,
                        idprovincia = @IdProvincia,
                        iddepartamento = @IdDepartamento,
                        direccion = @Direccion,
                        correo = @Correo,
                        nombre_vendedor = @NombreVendedor
                    WHERE idproveedor = @IdProveedor";

                    command.Parameters.Add("@NoDocumento", SqlDbType.VarChar).Value = model.NoDocumento;
                    command.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = model.IdTipoDocumento;
                    command.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = model.NombreProveedor;
                    command.Parameters.Add("@Telefono", SqlDbType.VarChar).Value = model.Telefono;
                    command.Parameters.Add("@IdProvincia", SqlDbType.Int).Value = model.IdProvincia;
                    command.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = model.IdDepartamento;
                    command.Parameters.Add("@Direccion", SqlDbType.VarChar).Value = model.Direccion;
                    command.Parameters.Add("@Correo", SqlDbType.VarChar).Value = model.Correo;
                    command.Parameters.Add("@NombreVendedor", SqlDbType.VarChar).Value = model.NombreVendedor;
                    command.Parameters.Add("@IdProveedor", SqlDbType.Int).Value = model.IdProveedor;

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint violation
                {
                    if (ex.Message.Contains("unique_no_documento_proveedor"))
                    {
                        throw new Exception("El número de documento ya existe.");
                    }
                    else
                    {
                        throw new Exception("Se produjo una violación de restricción de clave única. Por favor, verifica tus datos e intenta de nuevo.");
                    }
                }
                else
                {
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
