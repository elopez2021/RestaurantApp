using Restaurant.Presenters;
using Restaurant.Repositories;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Restaurant
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionStringFilePath = "dbconfig.txt";
            string sqlConnectionString;

            if (File.Exists(connectionStringFilePath))
            {
                sqlConnectionString = File.ReadAllText(connectionStringFilePath).Trim();
            }
            else
            {
                MessageBox.Show(
                    "No se encontró el archivo de cadena de conexión. Por favor, cree un archivo llamado 'dbconfig.txt' en el directorio de la aplicación que demuestre la estructura de una cadena de conexión en SQL SERVER:\n\n" +
                    "Ejemplo de estructura:\n" +
                    "Server=localhost\\SQLEXPRESS; " +
                    "Database=Restaurante; " +
                    "Integrated Security=True; " +
                    "Trusted_Connection=True;",
                    "Archivo de Cadena de Conexión No Encontrado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }



            try
            {
                ILoginRepository loginrepo = new LoginRepository(sqlConnectionString);
                ILoginView loginview = new Login();
                new LoginPresenter(loginview, loginrepo, sqlConnectionString);
                Application.Run((Form)loginview);
            }
            catch (SqlException sqlEx)
            {
                string errorMessage;

                if (sqlEx.Number == -1)
                {
                    errorMessage = "No se pudo conectar con el servidor. Verifique la configuración de la conexión y la disponibilidad del servidor.";
                }
                else
                {
                    errorMessage = $"Número de error SQL: {sqlEx.Number}\nMensaje: {sqlEx.Message}";
                }

                MessageBox.Show(
                    errorMessage,
                    "Detalles del Error SQL",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Se produjo un error: {ex.Message}",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
