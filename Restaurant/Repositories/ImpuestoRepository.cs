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
    internal class ImpuestoRepository : BaseRepository, IImpuestoRepository
    {
        public ImpuestoRepository(string connectionString) {
            this.connectionString = connectionString;
        }
        public void Add(ImpuestoModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                    INSERT INTO impuestos
                    (nombre, porcentaje)
                    VALUES 
                    (@Nombre, @Porcentaje)";
                command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                command.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = model.Porcentaje;
                command.ExecuteNonQuery();
            }
        }

        public void Update(ImpuestoModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                    UPDATE impuestos SET nombre = @Nombre, porcentaje = @Porcentaje
                    WHERE idimpuesto = @IdImpuesto;";
                command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                command.Parameters.Add("@Porcentaje", SqlDbType.Decimal).Value = model.Porcentaje;
                command.Parameters.Add("@IdImpuesto", SqlDbType.Int).Value = model.IdImpuesto;
                command.ExecuteNonQuery();
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
                    UPDATE impuestos SET estado = 0 WHERE idimpuesto = @IdImpuesto";
                command.Parameters.Add("@IdImpuesto", SqlDbType.NVarChar).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<ImpuestoModel> GetAll()
        {
            var list = new List<ImpuestoModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT * FROM impuestos WHERE estado = 1";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var impuesto = new ImpuestoModel
                        {
                            IdImpuesto = (int)reader["idimpuesto"],
                            Nombre = reader["nombre"].ToString(),
                            Porcentaje = (decimal)reader["porcentaje"],
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(impuesto);
                    }
                }
            }
            return list;
        }
    }
}
