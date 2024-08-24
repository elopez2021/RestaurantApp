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
    internal class MonedaPresenter
    {
        private IMonedaView view;
        private IMonedaRepository repo;
        private BindingSource monedaBindingSource;

        public MonedaPresenter(IMonedaView view, IMonedaRepository repo)
        {
            this.view = view;
            this.repo = repo;
            monedaBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedMoneda;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;

            this.view.SetMonedaListBindingSource(monedaBindingSource);

            LoadAllMonedaList();
        }

        private void LoadAllMonedaList()
        {
            IEnumerable<MonedaModel> monedaList = repo.GetAll();

            DataTable datatable = DataTableConverter.ConvertToDataTable(monedaList.ToList());

            monedaBindingSource.DataSource = datatable;
        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new MonedaModel();
            model.Nombre = view.Nombre;
            model.Simbolo = view.Simbolo;
            model.Sigla = view.Sigla;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    repo.Update(model);
                    view.Message = "Moneda Editada Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    repo.Add(model);
                    view.Message = "Moneda Añadida Satisfactoriamente";
                }
                LoadAllMonedaList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.isEdit = false;
            view.Nombre = view.Sigla = view.Simbolo = "";
        }

        private void Eliminar(object sender, EventArgs e)
        {
            try
            {
                this.repo.Delete(this.view.IdMoneda);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllMonedaList();
            CleanviewFields();
        }

        private void LoadSelectedMoneda(object sender, EventArgs e)
        {
            var currentRow = monedaBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdMoneda = Convert.ToInt32(currentRow["IdMoneda"]);
                view.Nombre = currentRow["Nombre"].ToString();
                view.Sigla = currentRow["Sigla"].ToString();
                view.Simbolo = currentRow["Simbolo"].ToString();

                view.isEdit = true;
            }
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }
    }
}
