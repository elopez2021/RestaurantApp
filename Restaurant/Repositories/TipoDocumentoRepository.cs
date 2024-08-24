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
    internal class TipoDocumentoRepository : BaseRepository, ITipoDocumentoRepository
    {
        public TipoDocumentoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public void Add(TipoDocumentoModel tipoModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoDocumentoModel> GetAll()
        {
            var tipoList = new List<TipoDocumentoModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT * FROM tipo_documento";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tipo = new TipoDocumentoModel();
                        tipo.IdTipoDocumento = (int)reader["idtipo"];
                        tipo.Nombre = reader["descripcion"].ToString();

                        tipoList.Add(tipo);
                    }
                }
            }
            return tipoList;
        }

        public IEnumerable<TipoDocumentoModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoDocumentoModel tipoModel)
        {
            throw new NotImplementedException();
        }
    }
}
