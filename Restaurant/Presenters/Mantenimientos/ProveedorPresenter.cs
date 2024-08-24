using Restaurant.Models;
using Restaurant.Presenters.Common;
using Restaurant.Repositories.Interfaces;
using Restaurant.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Presenters
{
    internal class ProveedorPresenter
    {
        private IProveedorRepository proveedorrepo;
        private IProvinciaRepository provinciarepo;
        private ITipoDocumentoRepository tipodocrepo;
        private IDepartamentoRepository departamentorepo;
        private IProveedorView view;
        private BindingSource proveedorBindingSource;

        public ProveedorPresenter(IProveedorRepository proveedorrepo, IProvinciaRepository provinciarepo, ITipoDocumentoRepository tipodocrepo, IDepartamentoRepository departamentorepo, IProveedorView view)
        {
            this.proveedorrepo = proveedorrepo;
            this.provinciarepo = provinciarepo;
            this.tipodocrepo = tipodocrepo;
            this.departamentorepo = departamentorepo;
            this.view = view;

            proveedorBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedProveedor;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;

            this.view.SetProveedorListBindingSource(proveedorBindingSource);

            LoadAllProveedor();
            LoadAllProvincia();
            LoadAllTipoDocumento();
            LoadAllDepartamento();
        }

        private void LoadAllDepartamento()
        {
            IEnumerable<DepartamentoModel> list = departamentorepo.GetAll();
            view.SetDepartamentoComboBox(list);
        }

        private void LoadAllTipoDocumento()
        {
            IEnumerable<TipoDocumentoModel> list = tipodocrepo.GetAll();
            view.SetTipoDocumentoComboBox(list);
        }

        private void LoadAllProvincia()
        {
            IEnumerable<ProvinciaModel> list = provinciarepo.GetAll();
            view.SetProvinciaComboBox(list);
        }

        private void LoadAllProveedor()
        {
            IEnumerable<ProveedorModel> list = proveedorrepo.GetAll();

            DataTable datatable = DataTableConverter.ConvertToDataTable(list.ToList());

            proveedorBindingSource.DataSource = datatable;
        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new ProveedorModel
            {
                IdProveedor = view.IdProveedor,
                NoDocumento = view.NoDocumento,
                IdTipoDocumento = view.IdTipoDocumento,
                NombreProveedor = view.NombreProveedor,
                Telefono = view.Telefono,
                IdProvincia = view.IdProvincia,
                IdDepartamento = view.IdDepartamento,
                Direccion = view.Direccion,
                Correo = view.Correo,
                NombreVendedor = view.NombreVendedor
            };

            try
            {
                new Common.ModelDataValidation().Validate(model);

                if (view.isEdit)
                {
                    proveedorrepo.Update(model);
                    view.Message = "Proveedor Editado Satisfactoriamente.";
                    view.isEdit = false;
                }
                else
                {
                    proveedorrepo.Add(model);
                    view.Message = "Proveedor Añadido Satisfactoriamente.";
                }
                
                LoadAllProveedor();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

        }

        private void Eliminar(object sender, EventArgs e)
        {
            try
            {
                this.proveedorrepo.Delete(this.view.IdProveedor);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllProveedor();
            CleanviewFields();
        }
        private void CleanviewFields()
        {
            view.NoDocumento = "";
            view.IdTipoDocumento = null;
            view.NombreProveedor = "";
            view.Telefono = "";
            view.IdProvincia = null;
            view.IdDepartamento = null;
            view.Direccion = "";
            view.Correo = "";
            view.NombreVendedor = "";
        }
        private void LoadSelectedProveedor(object sender, EventArgs e)
        {
            var currentRow = proveedorBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdProveedor = Convert.ToInt32(currentRow["idproveedor"]);
                view.NoDocumento = currentRow["nodocumento"].ToString();
                view.IdTipoDocumento = Convert.ToInt32(currentRow["idtipodocumento"]);
                view.NombreProveedor = currentRow["nombreproveedor"].ToString();
                view.Telefono = currentRow["telefono"].ToString();
                view.IdProvincia = Convert.ToInt32(currentRow["idprovincia"]);
                view.IdDepartamento = Convert.ToInt32(currentRow["iddepartamento"]);
                view.Direccion = currentRow["direccion"].ToString();
                view.Correo = currentRow["correo"].ToString();
                view.NombreVendedor = currentRow["nombrevendedor"].ToString();

                view.isEdit = true;
            }
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }
    }
}
