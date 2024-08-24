using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Repositories
{
    internal class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        public UsuarioRepository(string connectionString) {
            this.connectionString = connectionString;
        }
        public void Add(UsuarioModel usuarioModel)
        {
            //Debug.WriteLine(usuarioModel.ToString());
            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                INSERT INTO usuarios
                (no_documento, usuario, contrasena, telefono, nombre, correo, idsexo, idtipo, direccion, idsucursal, estatus, comision)
                VALUES 
                (@NoDocumento, @Usuario, @Contrasena, @Telefono, @Nombre, @Correo, @IdSexo, @IdTipo, @Direccion, @IdSucursal, @Estatus, @Comision)";

                    command.Parameters.Add("@NoDocumento", SqlDbType.NVarChar).Value = usuarioModel.NoDocumento;
                    command.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = usuarioModel.Usuario;
                    command.Parameters.Add("@Contrasena", SqlDbType.NVarChar).Value = usuarioModel.Contrasena;
                    command.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = usuarioModel.Telefono;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = usuarioModel.Nombre;
                    command.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = usuarioModel.Correo;
                    command.Parameters.Add("@IdSexo", SqlDbType.Int).Value = usuarioModel.IdSexo;
                    command.Parameters.Add("@IdTipo", SqlDbType.Int).Value = usuarioModel.IdTipo;
                    command.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = usuarioModel.Direccion;
                    command.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = usuarioModel.IdSucursal;
                    command.Parameters.Add("@Estatus", SqlDbType.Bit).Value = usuarioModel.Estatus;
                    command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = usuarioModel.Comision;

                    command.ExecuteNonQuery();
                }
            }            
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {

                    if (ex.Message.Contains("no_documento_usuarios"))
                    {
                        throw new Exception("El valor de no_documento que proporcionaste ya existe.");
                    }
                    else if (ex.Message.Contains("unique_usuario_usuarios"))
                    {
                        throw new Exception("El nombre de usuario que proporcionaste ya existe.");
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

        public IEnumerable<UsuarioModel> GetAll()
        {
            var usuarioList = new List<UsuarioModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"
                SELECT u.*, s.nombre AS NombreSucursal, tu.descripcion AS TipoUsuario, sx.descripcion AS Sexo
                FROM usuarios u
                INNER JOIN sucursal s ON u.idsucursal = s.idsucursal
                INNER JOIN tipo_usuario tu ON u.idtipo = tu.idtipo
                INNER JOIN sexo sx ON u.idsexo = sx.idsexo";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var usuario = new UsuarioModel();
                        usuario.IdUsuario = (int)reader["idusuario"];
                        usuario.NoDocumento = reader["no_documento"].ToString();
                        usuario.Usuario = reader["usuario"].ToString();
                        usuario.Contrasena = reader["contrasena"].ToString();
                        usuario.Telefono = reader["telefono"].ToString();
                        usuario.IdTipo = (int)reader["idtipo"];
                        usuario.Nombre = reader["nombre"].ToString();
                        usuario.Correo = reader["correo"].ToString();
                        usuario.IdSexo = (int)reader["idsexo"];
                        usuario.Direccion = reader["direccion"].ToString();
                        usuario.IdSucursal = (int)reader["idsucursal"];
                        usuario.Comision = reader["comision"] != DBNull.Value ? (decimal)reader["comision"] : 0;
                        usuario.Estatus = (bool)reader["estatus"];
                        usuario.FechaCreacion = (DateTime)reader["fecha_creacion"];

                        // Asignar las descripciones correspondientes
                        usuario.Sucursal = reader["NombreSucursal"].ToString();
                        usuario.TipoUsuario = reader["TipoUsuario"].ToString();
                        usuario.Sexo = reader["Sexo"].ToString();

                        usuarioList.Add(usuario);
                    }
                }
            }
            return usuarioList;
        }



        public IEnumerable<UsuarioModel> GetByValue(string value)
        {
            throw new NotImplementedException();
        }

        public void Update(UsuarioModel usuarioModel)
        {
            Debug.WriteLine(usuarioModel.ToString());

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"
                UPDATE usuarios
                SET no_documento = @NoDocumento, 
                    usuario = @Usuario,
                    contrasena = @Contrasena,
                    telefono = @Telefono,
                    nombre = @Nombre,
                    correo = @Correo, 
                    idsexo = @IdSexo,
                    idtipo = @IdTipo,
                    direccion = @Direccion,
                    idsucursal = @IdSucursal,
                    estatus = @Estatus,
                    comision = @Comision
                WHERE idusuario = @IdUsuario";

                    command.Parameters.Add("@NoDocumento", SqlDbType.NVarChar).Value = usuarioModel.NoDocumento;
                    command.Parameters.Add("@Usuario", SqlDbType.NVarChar).Value = usuarioModel.Usuario;
                    command.Parameters.Add("@Contrasena", SqlDbType.NVarChar).Value = usuarioModel.Contrasena;
                    command.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = usuarioModel.Telefono;
                    command.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = usuarioModel.Nombre;
                    command.Parameters.Add("@Correo", SqlDbType.NVarChar).Value = usuarioModel.Correo;
                    command.Parameters.Add("@IdSexo", SqlDbType.Int).Value = usuarioModel.IdSexo;
                    command.Parameters.Add("@IdTipo", SqlDbType.Int).Value = usuarioModel.IdTipo;
                    command.Parameters.Add("@Direccion", SqlDbType.NVarChar).Value = usuarioModel.Direccion;
                    command.Parameters.Add("@IdSucursal", SqlDbType.Int).Value = usuarioModel.IdSucursal;
                    command.Parameters.Add("@Estatus", SqlDbType.Bit).Value = usuarioModel.Estatus;
                    command.Parameters.Add("@Comision", SqlDbType.Decimal).Value = usuarioModel.Comision;
                    command.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = usuarioModel.IdUsuario;

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Violación de restricción de clave única
                {
                    
                    if (ex.Message.Contains("UQ_usuarios_nodocumento"))
                    {
                        throw new Exception("El valor de no_documento que proporcionaste ya existe.");
                    }
                    else if (ex.Message.Contains("9AFF8FC6448BBA5B"))
                    {
                        throw new Exception("El nombre de usuario que proporcionaste ya existe.");
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
