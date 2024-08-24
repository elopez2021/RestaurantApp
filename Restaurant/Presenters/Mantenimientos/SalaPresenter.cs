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
    internal class SalaPresenter
    {
        private ISalaView view;
        private ISalaRepository salarepo;
        private ISucursalRepository sucursalrepo;
        private BindingSource salaBindingSource;

        public SalaPresenter(ISalaView view, ISalaRepository salarepo, ISucursalRepository sucursalrepo)
        {
            this.view = view;
            this.salarepo = salarepo;
            this.sucursalrepo = sucursalrepo;

            salaBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedSala;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;

            this.view.SetSalaListBindingSource(salaBindingSource);

            LoadAllSalaList();
            LoadAllSucursalList();
        }

        private void LoadAllSucursalList()
        {
            IEnumerable<SucursalModel> sucursalist = sucursalrepo.GetAll();

            view.SetSucursalesComboBox(sucursalist);
        }

        private void LoadAllSalaList()
        {
            IEnumerable<SalaModel> salaList = salarepo.GetAll();

            DataTable datatable = DataTableConverter.ConvertToDataTable(salaList.ToList());

            salaBindingSource.DataSource = datatable;
            
        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new SalaModel();
            model.IdSala = view.IdSala;
            model.Nombre = view.Nombre;
            model.IdSucursal = view.IdSucursal;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    salarepo.Update(model);
                    view.Message = "Sala Editada Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    salarepo.Add(model);
                    view.Message = "Sala Añadida Satisfactoriamente";
                }
                LoadAllSalaList();
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
                this.salarepo.Delete(this.view.IdSala);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllSalaList();
            CleanviewFields();
        }

        private void LoadSelectedSala(object sender, EventArgs e)
        {
            var currentRow = salaBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdSala = Convert.ToInt32(currentRow["IdSala"]);
                view.Nombre = currentRow["Nombre"].ToString();
                view.IdSucursal = Convert.ToInt32(currentRow["IdSucursal"]);

                view.isEdit = true;
            }
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void CleanviewFields()
        {
            view.IdSucursal = null;
            view.Nombre = "";
            view.IdSala = -1;
        }
    }
}
