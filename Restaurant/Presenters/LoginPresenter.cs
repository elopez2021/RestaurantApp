using Restaurant.Repositories;
using Restaurant.Views;
using Restaurant.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Presenters
{
    internal class LoginPresenter
    {
        private ILoginView view;
        private ILoginRepository repository;
        private string connectionString;


        public LoginPresenter(ILoginView view, ILoginRepository repository, string connectionString)
        {
            this.view = view;
            this.repository = repository;
            this.connectionString = connectionString;
            this.view.LoginEvent += Login;
        }

        private void Login(object sender, EventArgs e)
        {
            (int? tipousuario, bool estado, string nombre, int idsucursal, int? idusuario) = repository.Autheticate(this.view.Username, this.view.Password);
            if (tipousuario != null && estado)
            {
                    this.view.HideWindow();
                    Menu menuview = new Menu(this.view.Username);
                    new MainPresenter(menuview, this.connectionString, tipousuario, nombre, idsucursal, (int)idusuario);

                }
                else
                {
                    this.view.ShowError("Usuario y/o contraseña incorrecta");
                }
        }
        
    }
}
