using Restaurant.Models;
using Restaurant.Repositories;
using Restaurant.Repositories.Interfaces;
using Restaurant.Views;
using Restaurant.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using Restaurant.Presenters.Common;
using System.Data;

namespace Restaurant.Presenters
{
    internal class UsuarioPresenter
    {
        private IUsuarioView view;
        private IUsuarioRepository usuarioRepository;
        private ISucursalRepository sucursalRepository;
        private ITipoUsuarioRepository tipoRepository;
        private BindingSource usuarioBindingSource;
        private IEnumerable<UsuarioModel> usuarioList;
        private IEnumerable<SucursalModel> sucursalList;
        private IEnumerable<TipoUsuarioModel> tipoList;

        public UsuarioPresenter(IUsuarioView view, IUsuarioRepository usuarioRepository, ISucursalRepository sucursalRepository, ITipoUsuarioRepository tipoRepository)
        {
            this.view = view;
            this.usuarioRepository = usuarioRepository;
            this.sucursalRepository = sucursalRepository;
            this.tipoRepository = tipoRepository;
            this.usuarioBindingSource = new BindingSource();

            this.view.GuardarEvent += GuardarUsuario;
            this.view.LimpiarEvent += Limpiar;
            this.view.EditEvent += LoadSelectedUsuarioToEdit;

            this.view.SetUsuarioListBindingSource(usuarioBindingSource);

            LoadAllUsuarioList();
            LoadAllSucursalList();
            LoadAllTipoList();
            this.tipoRepository = tipoRepository;
        }

        private void LoadSelectedUsuarioToEdit(object sender, EventArgs e)
        {
            var currentRow = usuarioBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdUsuario = Convert.ToInt32(currentRow["IdUsuario"]);
                view.Usuario = currentRow["Usuario"].ToString();
                view.Contrasena = currentRow["Contrasena"].ToString();
                view.Nombre = currentRow["Nombre"].ToString();

                view.Correo = currentRow["Correo"].ToString();
                view.Direccion = currentRow["Direccion"].ToString();

                view.IdSexo = (int?)currentRow["IdSexo"];
                view.NoDocumento = currentRow["NoDocumento"].ToString();
                view.Telefono = currentRow["Telefono"].ToString();
                view.IdSucursal = Convert.ToInt32(currentRow["IdSucursal"]);
                view.IdTipoUsuario = Convert.ToInt32(currentRow["IdTipo"]);
                view.Estatus = currentRow["Estatus"] != DBNull.Value ? (bool?)currentRow["Estatus"] : null;
                view.Comision = currentRow["Comision"] != DBNull.Value ? Convert.ToDecimal(currentRow["Comision"]) : (decimal?)null;

                view.isEdit = true;
            }
        }

        private void LoadAllTipoList()
        {
            tipoList = tipoRepository.GetAll();
            this.view.SetTipoUsuariosComboBox(tipoList);
        }

        private void LoadAllSucursalList()
        {
            sucursalList = sucursalRepository.GetAll();
            this.view.SetSucursalesComboBox(sucursalList);
        }

        private void LoadAllUsuarioList()
        {
            usuarioList = usuarioRepository.GetAll();

            DataTable usuarioDataTable = DataTableConverter.ConvertToDataTable(usuarioList.ToList());

            usuarioBindingSource.DataSource = usuarioDataTable;
        }

        private void GuardarUsuario(object sender, EventArgs e)
        {
            var model = new UsuarioModel();
            model.IdUsuario = view.IdUsuario;
            model.NoDocumento = view.NoDocumento;
            model.Nombre = view.Nombre;
            model.IdTipo = view.IdTipoUsuario;
            model.IdSexo = view.IdSexo;
            model.Direccion = view.Direccion;
            model.Telefono = view.Telefono;
            model.Correo = view.Correo;
            model.Usuario = view.Usuario;
            model.Contrasena = view.Contrasena;
            model.Estatus = view.Estatus;
            model.Comision = view.Comision;
            model.IdSucursal = view.IdSucursal;
            
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    usuarioRepository.Update(model);
                    view.Message = "Usuario Editado Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    usuarioRepository.Add(model);
                    view.Message = "Usuario Añadido Satisfactoriamente";
                }
                LoadAllUsuarioList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            this.view.Usuario = "";
            this.view.Contrasena = "";
            this.view.Nombre = "";
            
            this.view.Correo = "";
            this.view.Direccion = "";

            this.view.IdSexo = null;
            this.view.NoDocumento = "";
            this.view.Telefono = "";
            this.view.IdSucursal = null;
            this.view.IdTipoUsuario = null;
            this.view.Estatus = null;
            this.view.Comision = null;

            view.isEdit = false;
            
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }
    }
}
