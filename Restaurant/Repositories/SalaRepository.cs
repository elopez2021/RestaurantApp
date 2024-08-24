using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Restaurant.Repositories
{
    internal class SalaRepository : BaseRepository, ISalaRepository
    {
        public SalaRepository(string connectionString) { 
            this.connectionString = connectionString;
        }

        public void Add(SalaModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    INSERT INTO salas
                    (nombre, idsucursal)
                    VALUES 
                    (@Nombre, @IdSucursal)"
                    ;

                    command.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = model.IdSucursal;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_nombre_idsucursal"))
                    {
                        throw new Exception("El nombre de la sala ya existe en esta sucursal.");
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
                    DELETE FROM salas WHERE idsala = @IdSala";

                command.Parameters.Add("@IdSala", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<SalaModel> GetAll()
        {
            var list = new List<SalaModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT s.*, sc.nombre AS nombre_sucursal
                FROM salas s
                INNER JOIN sucursal sc ON s.idsucursal = sc.idsucursal WHERE s.estado = 1";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sala = new SalaModel
                        {
                            IdSala = (int)reader["idsala"],
                            Nombre = reader["nombre"].ToString(),
                            IdSucursal = (int)reader["idsucursal"],
                            Sucursal = reader["nombre_sucursal"].ToString(),
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(sala);
                    }
                }
            }
            return list;
        }

        public IEnumerable<SalaModel> GetAllBySucursal(int idsucursal)
        {
            var list = new List<SalaModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT s.*, sc.nombre AS nombre_sucursal
                FROM salas s
                INNER JOIN sucursal sc ON s.idsucursal = sc.idsucursal WHERE s.estado = 1 AND s.idsucursal = @IdSucursal";

                command.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = idsucursal;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sala = new SalaModel
                        {
                            IdSala = (int)reader["idsala"],
                            Nombre = reader["nombre"].ToString(),
                            IdSucursal = (int)reader["idsucursal"],
                            Sucursal = reader["nombre_sucursal"].ToString(),
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(sala);
                    }
                }
            }
            return list;
        }

        public void Update(SalaModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    UPDATE salas SET nombre = @Nombre, idsucursal = @IdSucursal WHERE idsala = @IdSala";

                    command.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = model.IdSucursal;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.Parameters.Add("@IdSala", SqlDbType.Int).Value = model.IdSala;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_nombre_idsucursal"))
                    {
                        throw new Exception("El nombre de la sala ya existe en esta sucursal.");
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
