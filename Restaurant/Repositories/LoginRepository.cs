using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal class LoginRepository : BaseRepository, ILoginRepository
    {
        public LoginRepository(string connectionString) { 
            this.connectionString = connectionString;
        
        }
        public (int?, bool, string, int, int?) Autheticate(string username, string password)
        {
            
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT idusuario, idtipo, estatus, nombre, idsucursal FROM usuarios WHERE usuario = @Username and contrasena = @Password", connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                using (var reader = command.ExecuteReader())
                {

                    bool estado = false;
                    int? tipo = null;
                    int? idusuario = null;
                    string nombre = "";
                    int idsucursal = 0;
                    if (reader.Read())
                    {
                        estado = (bool)reader["estatus"];
                        tipo = (int)reader["idtipo"];
                        nombre = (string)reader["nombre"];
                        idsucursal = (int)reader["idsucursal"];
                        idusuario = (int)reader["idusuario"];
                    }
                    return (tipo, estado, nombre, idsucursal, idusuario);
                }
            }
           
        }

    }
}
