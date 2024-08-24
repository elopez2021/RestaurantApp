using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class MainClass
    {
        public static readonly string dbname = "Server=localhost\\SQLEXPRESS;Database=Restaurante;Trusted_Connection=True;";
        public static SqlConnection connection = new SqlConnection(dbname);

        public static bool IsValidUser (string user, string pass)
        {
            bool isValid = false;

            string qry = @"Select * from usuario where username = '" + user + "' and  contrasena = '" + pass + "'";
            SqlCommand cmd = new SqlCommand(qry, connection);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                isValid = true;
                USER = dt.Rows[0]["nombre"].ToString();
            }

            return isValid;
        }

        public static string user;

        public static string USER
        {
            get { return user; }
            private set { user = value; }
        }

    }
}
