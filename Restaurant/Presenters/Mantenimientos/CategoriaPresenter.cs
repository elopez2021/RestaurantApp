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
    internal class CategoriaPresenter
    {

        private ICategoriaView view;
        private ICategoriaRepository repository;
        private BindingSource categoriaBindingSource;
        private IEnumerable<CategoriaModel> categoriaList;

        public CategoriaPresenter(ICategoriaView view, ICategoriaRepository repository)
        {
            this.view = view;
            this.repository = repository;

            categoriaBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedCategoria;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;

            this.view.SetCategoriaListBindingSource(categoriaBindingSource);

            LoadAllCategoriaList();
        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new CategoriaModel();
            model.IdCategoria = view.IdCategoria;
            model.Nombre = view.Nombre;

            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    repository.Update(model);
                    view.Message = "Categoria Editada Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    repository.Add(model);
                    view.Message = "Categoria Añadida Satisfactoriamente";
                }
                LoadAllCategoriaList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void LoadSelectedCategoria(object sender, EventArgs e)
        {
            var currentRow = categoriaBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdCategoria = Convert.ToInt32(currentRow["IdCategoria"]);
                view.Nombre = currentRow["Nombre"].ToString();
                
                view.isEdit = true;
            }
        }

        private void Eliminar(object sender, EventArgs e)
        {

            try
            {
                this.repository.Delete(this.view.IdCategoria);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllCategoriaList();
            CleanviewFields();
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void CleanviewFields()
        {
            this.view.Nombre = "";
            view.isEdit = false;
        }

        private void LoadAllCategoriaList()
        {
            categoriaList = repository.GetAll();

            DataTable datatable = DataTableConverter.ConvertToDataTable(categoriaList.ToList());

            categoriaBindingSource.DataSource = datatable;
        }
    }
}
