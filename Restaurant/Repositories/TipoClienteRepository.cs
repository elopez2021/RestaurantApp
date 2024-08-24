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
    internal class TipoClienteRepository : BaseRepository, ITipoClienteRepository
    {
        public TipoClienteRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IEnumerable<TipoClienteModel> GetAll()
        {
            var tipoList = new List<TipoClienteModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT * FROM tipo_cliente";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tipo = new TipoClienteModel();
                        tipo.IdTipoCliente = (int)reader["idtipo"];
                        tipo.Nombre = reader["nombre"].ToString();

                        tipoList.Add(tipo);
                    }
                }
            }
            return tipoList;
        }

    }
}
