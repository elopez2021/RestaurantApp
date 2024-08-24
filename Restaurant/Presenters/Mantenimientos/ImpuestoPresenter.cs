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
    internal class ImpuestoPresenter
    {
        private IImpuestoView view;
        private IImpuestoRepository repo;
        private BindingSource impuestoBindingSource;

        public ImpuestoPresenter(IImpuestoView view, IImpuestoRepository repo)
        {
            this.view = view;
            this.repo = repo;

            impuestoBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedImpuesto;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;

            this.view.SetImpuestoListBindingSource(impuestoBindingSource);

            LoadAllImpuestoList();
        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new ImpuestoModel();
            model.IdImpuesto = view.IdImpuesto;
            model.Nombre = view.Nombre;
            model.Porcentaje = view.Porcentaje;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    repo.Update(model);
                    view.Message = "Impuesto Editado Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    repo.Add(model);
                    view.Message = "Impuesto Añadido Satisfactoriamente";
                }
                LoadAllImpuestoList();
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
            view.Nombre = "";
            view.Porcentaje = null;
        }

        private void Eliminar(object sender, EventArgs e)
        {
            try
            {
                this.repo.Delete(this.view.IdImpuesto);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllImpuestoList();
            CleanviewFields();
        }

        private void LoadSelectedImpuesto(object sender, EventArgs e)
        {
            var currentRow = impuestoBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdImpuesto = Convert.ToInt32(currentRow["IdImpuesto"]);
                view.Nombre = currentRow["Nombre"].ToString();
                view.Porcentaje = (decimal)currentRow["Porcentaje"];

                view.isEdit = true;
            }
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void LoadAllImpuestoList()
        {
            IEnumerable<ImpuestoModel> impuestoList = repo.GetAll();

            DataTable datatable = DataTableConverter.ConvertToDataTable(impuestoList.ToList());

            impuestoBindingSource.DataSource = datatable;
        }
    }
}
