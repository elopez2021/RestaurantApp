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
    internal class SucursalRepository : BaseRepository, ISucursalRepository
    {
        public SucursalRepository(string connectionString) {
            this.connectionString = connectionString;
        }

        public void Add(SucursalModel sucursalModel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SucursalModel> GetAll()
        {
            var sucursalList = new List<SucursalModel>();

            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM sucursal";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var sucursal = new SucursalModel();

                        sucursal.IdSucursal = (int)reader["idsucursal"];
                        sucursal.Nombre = reader["nombre"].ToString();
                        sucursal.Direccion = reader["direccion"].ToString();
                        sucursal.Telefono = reader["telefono"].ToString();
                        sucursal.Ciudad = reader["ciudad"].ToString();
                        sucursal.Estado = reader["estado"].ToString();
                        sucursal.CodigoPostal = reader["codigo_postal"].ToString();
                        sucursal.FechaApertura = DateTime.Parse(reader["fecha_apertura"].ToString());
                        sucursal.Gerente = reader["gerente"].ToString();
                        sucursal.FechaCreacion = DateTime.Parse(reader["fecha_creacion"].ToString());

                        sucursalList.Add(sucursal);
                    }
                }
            }

            return sucursalList;
        }

        public IEnumerable<SucursalModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(SucursalModel sucursalModel)
        {
            throw new NotImplementedException();
        }
    }
}
