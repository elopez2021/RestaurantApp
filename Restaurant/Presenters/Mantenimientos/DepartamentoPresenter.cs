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
    internal class DepartamentoPresenter
    {
        private IDepartamentoView view;
        private IDepartamentoRepository departamentorepo;
        private ISucursalRepository sucursalrepo;
        private BindingSource departamentoBindingSource;

        public DepartamentoPresenter(IDepartamentoView view, IDepartamentoRepository departamentorepo, ISucursalRepository sucursalrepo)
        {
            this.view = view;
            this.departamentorepo = departamentorepo;
            this.sucursalrepo = sucursalrepo;

            departamentoBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedDepartamento;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;

            this.view.SetDepartamentoListBindingSource(departamentoBindingSource);

            LoadAllDepartamentoList();
            LoadAllSucursalList();
        }

        private void LoadAllSucursalList()
        {
            IEnumerable<SucursalModel> sucursalist = sucursalrepo.GetAll();

            view.SetSucursalComboBox(sucursalist);
        }

        private void LoadAllDepartamentoList()
        {
            IEnumerable<DepartamentoModel> departamentoList = departamentorepo.GetAll();
            
            DataTable datatable = DataTableConverter.ConvertToDataTable(departamentoList.ToList());

            departamentoBindingSource.DataSource = datatable;

        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new DepartamentoModel();
            model.IdSucursal = view.IdSucursal;
            model.IdDepartamento = view.IdDepartamento;
            model.Nombre = view.Nombre;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    departamentorepo.Update(model);
                    view.Message = "Departamento Editado Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    departamentorepo.Add(model);
                    view.Message = "Departamento Añadido Satisfactoriamente";
                }
                LoadAllDepartamentoList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            this.view.isEdit = false;
            view.IdSucursal = null;
            view.Nombre = "";
            
        }

        private void Eliminar(object sender, EventArgs e)
        {
            try
            {
                this.departamentorepo.Delete(this.view.IdDepartamento);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllDepartamentoList();
            CleanviewFields();
        }

        private void LoadSelectedDepartamento(object sender, EventArgs e)
        {
            var currentRow = departamentoBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdDepartamento = Convert.ToInt32(currentRow["IdDepartamento"]);
                view.IdSucursal = Convert.ToInt32(currentRow["IdSucursal"]);
                view.Nombre = currentRow["Nombre"].ToString();

                view.isEdit = true;
            }
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }
    }
}
