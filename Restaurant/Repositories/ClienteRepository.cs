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
    internal class ClienteRepository : BaseRepository, IClienteRepository
    {

        public ClienteRepository(string connectionString) { 
            this.connectionString = connectionString;
        }
        public void Add(ClienteModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    INSERT INTO clientes
                    (idtipocliente, idtipodocumento, nodocumento, nombre, razonsocial, girocliente, telefono, correo, idprovincia, direccion, limitecredito)
                    VALUES 
                    (@IdTipoCliente, @IdTipoDocumento, @NoDocumento, @Nombre, @RazonSocial, @GiroCliente, @Telefono, @Correo, @IdProvincia, @Direccion, @LimiteCredito)";

                    command.Parameters.Add("@IdTipoCliente", SqlDbType.Int).Value = model.IdTipoCliente;
                    command.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = model.IdTipoDocumento;
                    command.Parameters.Add("@NoDocumento", SqlDbType.NVarChar).Value = model.NoDocumento;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = model.RazonSocial;
                    command.Parameters.Add("@GiroCliente", SqlDbType.NVarChar).Value = model.GiroCliente;
                    command.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = model.Telefono;
                    command.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = model.Correo;
                    command.Parameters.Add("@IdProvincia", SqlDbType.Int).Value = model.IdProvincia;
                    command.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = model.Direccion;
                    command.Parameters.Add("@LimiteCredito", SqlDbType.Decimal).Value = (object)model.LimiteCredito ?? DBNull.Value;

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_no_documento_clientes"))
                    {
                        throw new Exception("El número de documento que proporcionaste ya existe.");
                    }
                    else if (ex.Message.Contains("unique_email_clientes"))
                    {
                        throw new Exception("El correo electrónico que proporcionaste ya existe.");
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
                command.CommandText = @"
                UPDATE clientes
                SET estado = 0
                WHERE idcliente = @IdCliente";

                command.Parameters.Add("@IdCliente", SqlDbType.Int).Value = id;

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ClienteModel> GetAll()
        {
            var clientes = new List<ClienteModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = @"
                	SELECT c.idcliente AS IdCliente, 
                       c.idtipocliente AS IdTipoCliente, 
                       c.idtipodocumento AS IdTipoDocumento, 
                       c.nodocumento AS NoDocumento, 
                       c.nombre AS Nombre,
                       c.estado as Estado,
                       c.razonsocial AS RazonSocial, 
                       c.girocliente AS GiroCliente, 
                       c.telefono AS Telefono, 
                       c.correo AS Correo, 
                       c.idprovincia AS IdProvincia,
                       c.direccion AS Direccion, 
                       c.limitecredito AS LimiteCredito,
                       c.fecha_creacion AS FechaCreacion,
                       tc.nombre AS TipoClienteNombre,
                       td.descripcion AS TipoDocumentoNombre,
                       p.nombre AS ProvinciaNombre
                FROM clientes c
                INNER JOIN tipo_cliente tc ON c.idtipocliente = tc.idtipo
                INNER JOIN tipo_documento td ON c.idtipodocumento = td.idtipo
                INNER JOIN provincia p ON c.idprovincia = p.idprovincia
                WHERE c.estado = 1";

                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var cliente = new ClienteModel
                        {
                            IdCliente = Convert.ToInt32(reader["IdCliente"]),
                            IdTipoCliente = Convert.ToInt32(reader["IdTipoCliente"]),
                            IdTipoDocumento = Convert.ToInt32(reader["IdTipoDocumento"]),
                            NoDocumento = reader["NoDocumento"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            RazonSocial = reader["RazonSocial"].ToString(),
                            GiroCliente = reader["GiroCliente"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Correo = reader["Correo"].ToString(),
                            IdProvincia = Convert.ToInt32(reader["IdProvincia"]),
                            Direccion = reader["Direccion"].ToString(),
                            LimiteCredito = Convert.ToDecimal(reader["LimiteCredito"]),
                            FechaCreacion = (DateTime)reader["FechaCreacion"],
                            Estatus = (bool)reader["Estado"],

                            //the id names
                            TipoCliente = reader["TipoClienteNombre"].ToString(),
                            TipoDocumento = reader["TipoDocumentoNombre"].ToString(),
                            Provincia = reader["ProvinciaNombre"].ToString()
                        };

                        clientes.Add(cliente);
                    }
                }
            }

            return clientes;

        }

        public IEnumerable<ClienteModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(ClienteModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    UPDATE clientes
                    SET 
                        idtipocliente = @IdTipoCliente,
                        idtipodocumento = @IdTipoDocumento,
                        nodocumento = @NoDocumento,
                        nombre = @Nombre,
                        razonsocial = @RazonSocial,
                        girocliente = @GiroCliente,
                        telefono = @Telefono,
                        correo = @Correo,
                        idprovincia = @IdProvincia,
                        direccion = @Direccion,
                        limitecredito = @LimiteCredito
                    WHERE idcliente = @IdCliente";

                    command.Parameters.Add("@IdTipoCliente", SqlDbType.Int).Value = model.IdTipoCliente;
                    command.Parameters.Add("@IdTipoDocumento", SqlDbType.Int).Value = model.IdTipoDocumento;
                    command.Parameters.Add("@NoDocumento", SqlDbType.NVarChar).Value = model.NoDocumento;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.Parameters.Add("@RazonSocial", SqlDbType.NVarChar).Value = model.RazonSocial;
                    command.Parameters.Add("@GiroCliente", SqlDbType.NVarChar).Value = model.GiroCliente;
                    command.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = model.Telefono;
                    command.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = model.Correo;
                    command.Parameters.Add("@IdProvincia", SqlDbType.Int).Value = model.IdProvincia;
                    command.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = model.Direccion;
                    command.Parameters.Add("@LimiteCredito", SqlDbType.Decimal).Value = (object)model.LimiteCredito ?? DBNull.Value;
                    command.Parameters.Add("@IdCliente", SqlDbType.Int).Value = model.IdCliente;

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_no_documento_clientes"))
                    {
                        throw new Exception("El número de documento que proporcionaste ya existe.");
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
