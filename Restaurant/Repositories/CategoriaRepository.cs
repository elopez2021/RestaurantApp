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
    internal class CategoriaRepository : BaseRepository, ICategoriaRepository
    {

        public CategoriaRepository(string connectionString) {
            this.connectionString = connectionString;
        }
        public void Add(CategoriaModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                    INSERT INTO categorias
                    (nombre)
                    VALUES 
                    (@Nombre)";
                command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
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
                    UPDATE categorias SET estado = 0 WHERE idcategoria = @IdCategoria";
                command.Parameters.Add("@IdCategoria", SqlDbType.NVarChar).Value = id;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<CategoriaModel> GetAll()
        {
            var list = new List<CategoriaModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT * FROM categorias WHERE estado = 1";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var categoria = new CategoriaModel
                        {
                            IdCategoria = (int)reader["idcategoria"],
                            Nombre = reader["nombre"].ToString(),
                            Estado = (bool)reader["estado"]
                        };

                        list.Add(categoria);
                    }
                }
            }
            return list;
        }

        public void Update(CategoriaModel model)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                    UPDATE categorias SET nombre = @Nombre WHERE idcategoria = @IdCategoria";
                command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = model.Nombre;
                command.Parameters.Add("@IdCategoria", SqlDbType.Int).Value = model.IdCategoria;
                command.ExecuteNonQuery();
            }
        }
    }
}
