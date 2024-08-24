using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class TipoUsuarioRepository : BaseRepository, ITipoUsuarioRepository
    {
        public TipoUsuarioRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void Add(TipoUsuarioModel tipousuarioModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoUsuarioModel> GetAll()
        {
            var tipoList = new List<TipoUsuarioModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM tipo_usuario";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tipo = new TipoUsuarioModel();
                        tipo.IdTipo = (int)reader["idtipo"];
                        tipo.Descripcion = reader["descripcion"].ToString();

                        tipoList.Add(tipo);
                    }
                }
            }
            return tipoList;
        }

        public IEnumerable<TipoUsuarioModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoUsuarioModel tipousuarioModel)
        {
            throw new NotImplementedException();
        }
    }
}
