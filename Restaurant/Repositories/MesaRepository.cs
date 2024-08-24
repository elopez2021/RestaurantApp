using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class MesaRepository : BaseRepository, IMesaRepository
    {
        public MesaRepository(string connectionString) {
            this.connectionString = connectionString;
        }
        public void Add(MesaModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    INSERT INTO mesas
                    (idsala, nombre, cantpersonas)
                    VALUES 
                    (@IdSala, @Nombre, @CantPersonas)"
                    ;

                    command.Parameters.Add("@IdSala", SqlDbType.Int).Value = model.IdSala;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.Parameters.Add("@CantPersonas", SqlDbType.Int).Value = model.CantidadPersona;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_sala_mesa"))
                    {
                        throw new Exception("El nombre de la mesa ya existe en esta sala.");
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
                    DELETE FROM mesas WHERE idmesa = @IdMesa";

                command.Parameters.Add("@IdMesa", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<MesaModel> GetAll()
        {
            var list = new List<MesaModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                	SELECT m.*, s.nombre AS nombre_sala
                    FROM mesas m
                    INNER JOIN salas s ON m.idsala = s.idsala WHERE m.estado = 1";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sala = new MesaModel
                        {
                            IdMesa = (int)reader["idmesa"],
                            IdSala = (int)reader["idsala"],
                            Nombre = reader["nombre"].ToString(),
                            Sala = reader["nombre_sala"].ToString(),
                            CantidadPersona = (int)reader["cantpersonas"],
                            Disponible = (bool)reader["disponible"],
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(sala);
                    }
                }
            }
            return list;
        }

        public IEnumerable<MesaModel> GetMesaBySala(int idsala)
        {
            var list = new List<MesaModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                	SELECT m.*, s.nombre AS nombre_sala
                    FROM mesas m
                    INNER JOIN salas s ON m.idsala = s.idsala WHERE m.estado = 1 AND m.idsala = @IdSala";
                
                command.Parameters.Add("@IdSala", SqlDbType.Int).Value = idsala;

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sala = new MesaModel
                        {
                            IdMesa = (int)reader["idmesa"],
                            IdSala = (int)reader["idsala"],
                            Nombre = reader["nombre"].ToString(),
                            Sala = reader["nombre_sala"].ToString(),
                            CantidadPersona = (int)reader["cantpersonas"],
                            Disponible = (bool)reader["disponible"],
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(sala);
                    }
                }
            }
            return list;
        }

        public void Update(MesaModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    UPDATE mesas SET idsala = @IdSala, nombre = @Nombre, cantpersonas = @CantPersonas WHERE idmesa = @IdMesa";

                    command.Parameters.Add("@IdSala", SqlDbType.Int).Value = model.IdSala;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.Parameters.Add("@CantPersonas", SqlDbType.Int).Value = model.CantidadPersona;
                    command.Parameters.Add("@IdMesa", SqlDbType.Int).Value = model.IdMesa;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_sala_mesa"))
                    {
                        throw new Exception("El nombre de la mesa ya existe en esta sala.");
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
