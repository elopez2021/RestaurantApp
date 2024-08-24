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
    internal class MedidaRepository : BaseRepository, IMedidaRepository
    {
        public MedidaRepository(string connectionString) { 
            this.connectionString = connectionString;
        }
        public void Add(MedidaModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    INSERT INTO medidas
                    (nombre, sigla)
                    VALUES 
                    (@Nombre, @Sigla)"
                    ;

                    command.Parameters.Add("@Sigla", SqlDbType.NVarChar).Value = model.Sigla;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_nombre_sigla_medidas"))
                    {
                        throw new Exception("La combinación de nombre y sigla ya existe");
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
                    UPDATE medidas SET estado = 0 WHERE idmedida = @IdMedida";

                command.Parameters.Add("@IdMedida", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<MedidaModel> GetAll()
        {
            var list = new List<MedidaModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                	SELECT * FROM medidas WHERE estado = 1";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var moneda = new MedidaModel
                        {
                            IdMedida = (int)reader["idmedida"],
                            Nombre = reader["nombre"].ToString(),
                            Sigla = reader["sigla"].ToString(),
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(moneda);
                    }
                }
            }
            return list;
        }

        public void Update(MedidaModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    UPDATE medidas SET nombre = @Nombre, sigla = @Sigla WHERE idmedida = @IdMedida";

                    command.Parameters.Add("@Sigla", SqlDbType.NVarChar).Value = model.Sigla;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.Parameters.Add("@IdMedida", SqlDbType.Int).Value = model.IdMedida;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_nombre_sigla_monedas"))
                    {
                        throw new Exception("La combinación de nombre y sigla ya existe");
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
