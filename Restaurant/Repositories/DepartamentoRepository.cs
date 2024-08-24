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
    internal class DepartamentoRepository : BaseRepository, IDepartamentoRepository
    {
        public DepartamentoRepository(string connectionString) {
            this.connectionString = connectionString;
        }
        public void Add(DepartamentoModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    INSERT INTO departamentos
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
                    if (ex.Message.Contains("unique_departamento_sucursal"))
                    {
                        throw new Exception("El departamento ya existe en esta sala.");
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
                    UPDATE departamentos SET estado = 0 WHERE iddepartamento = @IdDepartamento";

                command.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<DepartamentoModel> GetAll()
        {
            var list = new List<DepartamentoModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                	SELECT d.*, s.nombre AS nombre_sucursal
                    FROM departamentos d
                    INNER JOIN sucursal s ON d.idsucursal = s.idsucursal WHERE d.estado = 1";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var departamento = new DepartamentoModel
                        {
                            IdDepartamento = (int)reader["iddepartamento"],
                            Nombre = reader["nombre"].ToString(),
                            IdSucursal = (int)reader["idsucursal"],
                            Sucursal = reader["nombre_sucursal"].ToString(),
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(departamento);
                    }
                }
            }
            return list;
        }

        public void Update(DepartamentoModel model)
        {
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                    UPDATE departamentos
                    SET nombre = @Nombre, idsucursal = @IdSucursal
                    WHERE iddepartamento = @IdDepartamento";
                    
                    command.Parameters.Add("@IdDepartamento", SqlDbType.Int).Value = model.IdDepartamento;
                    command.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = model.IdSucursal;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    if (ex.Message.Contains("unique_departamento_sucursal"))
                    {
                        throw new Exception("El departamento ya existe en esta sala.");
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
