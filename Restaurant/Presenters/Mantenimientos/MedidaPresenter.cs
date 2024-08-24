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
    internal class MedidaPresenter
    {
        private IMedidaView view;
        private IMedidaRepository repo;
        private BindingSource medidaBindingSource;

        public MedidaPresenter(IMedidaView view, IMedidaRepository repo)
        {
            this.view = view;
            this.repo = repo;

            medidaBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedCategoria;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;

            this.view.SetMedidaListBindingSource(medidaBindingSource);

            LoadAllMedidaList();
        }

        private void LoadAllMedidaList()
        {
            IEnumerable<MedidaModel> medidaList = repo.GetAll();

            DataTable datatable = DataTableConverter.ConvertToDataTable(medidaList.ToList());

            medidaBindingSource.DataSource = datatable;
        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new MedidaModel();
            model.IdMedida = view.IdMedida;
            model.Nombre = view.Nombre;
            model.Sigla = view.Sigla;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    repo.Update(model);
                    view.Message = "Medida Editada Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    repo.Add(model);
                    view.Message = "Medida Añadida Satisfactoriamente";
                }
                LoadAllMedidaList();
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
            view.Nombre = view.Sigla = "";
        }

        private void Eliminar(object sender, EventArgs e)
        {
            try
            {
                this.repo.Delete(this.view.IdMedida);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllMedidaList();
            CleanviewFields();
        }

        private void LoadSelectedCategoria(object sender, EventArgs e)
        {
            var currentRow = medidaBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdMedida = Convert.ToInt32(currentRow["IdMedida"]);
                view.Nombre = currentRow["Nombre"].ToString();
                view.Sigla = currentRow["Sigla"].ToString();

                view.isEdit = true;
            }
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }
    }
}
