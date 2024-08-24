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
    internal class MonedaRepository : BaseRepository, IMonedaRepository
    {
        public MonedaRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public void Add(MonedaModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    INSERT INTO monedas
                    (nombre, sigla, simbolo)
                    VALUES 
                    (@Nombre, @Sigla, @Simbolo)"
                    ;

                    command.Parameters.Add("@Sigla", SqlDbType.NVarChar).Value = model.Sigla;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.Parameters.Add("@Simbolo", SqlDbType.NVarChar).Value = model.Simbolo;
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

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                    UPDATE monedas SET estado = 0 WHERE idmoneda = @IdMoneda";

                command.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<MonedaModel> GetAll()
        {
            var list = new List<MonedaModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                	SELECT * FROM monedas WHERE estado = 1";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var moneda = new MonedaModel
                        {
                            IdMoneda = (int)reader["idmoneda"],                            
                            Nombre = reader["nombre"].ToString(),
                            Sigla = reader["sigla"].ToString(),
                            Simbolo = reader["simbolo"].ToString(),                            
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(moneda);
                    }
                }
            }
            return list;
        }

        public void Update(MonedaModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    UPDATE monedas SET nombre = @Nombre, sigla = @Sigla, simbolo = @Simbolo WHERE idmoneda = @IdMoneda";

                    command.Parameters.Add("@Sigla", SqlDbType.NVarChar).Value = model.Sigla;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.Parameters.Add("@Simbolo", SqlDbType.NVarChar).Value = model.Simbolo;
                    command.Parameters.Add("@IdMoneda", SqlDbType.Int).Value = model.IdMoneda;
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
