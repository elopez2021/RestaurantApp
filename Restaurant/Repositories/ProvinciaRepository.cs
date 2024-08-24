using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class ProvinciaRepository : BaseRepository, IProvinciaRepository
    {

        public ProvinciaRepository(string connectionString) {
            this.connectionString = connectionString;
        }
        public void Add(ProvinciaModel provinciaModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProvinciaModel> GetAll()
        {
            var provinciaList = new List<ProvinciaModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT * FROM provincia;";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var provincia = new ProvinciaModel();
                        provincia.IdProvincia = (int)reader["idprovincia"];
                        provincia.Nombre = reader["nombre"].ToString();
                        provincia.Codigo = reader["codigo"].ToString();
                        provincia.FechaCreacion = (DateTime)reader["fecha_creacion"];

                        provinciaList.Add(provincia);
                    }
                }
            }
            Debug.WriteLine(provinciaList.First().Nombre);
            return provinciaList;
        }

        public IEnumerable<ProvinciaModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(ProvinciaModel provinciaModel)
        {
            throw new NotImplementedException();
        }
    }
}
