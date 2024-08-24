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
    internal class MesaPresenter
    {
        private IMesaView view;
        private IMesaRepository mesarepo;
        private ISalaRepository salarepo;
        private BindingSource mesaBindingSource;

        public MesaPresenter(IMesaView view, IMesaRepository mesarepo, ISalaRepository salarepo)
        {
            this.view = view;
            this.mesarepo = mesarepo;
            this.salarepo = salarepo;

            mesaBindingSource = new BindingSource();

            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedMesa;
            this.view.DeleteEvent += Eliminar;
            this.view.GuardarEvent += Guardar;

            this.view.SetMesaListBindingSource(mesaBindingSource);

            LoadAllMesaList();
            LoadSalaList();
        }

        private void Guardar(object sender, EventArgs e)
        {
            var model = new MesaModel();
            model.IdSala = view.IdSala;
            model.Nombre = view.Nombre;
            model.CantidadPersona = view.CantidadPersona;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    mesarepo.Update(model);
                    view.Message = "Mesa Editada Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    mesarepo.Add(model);
                    view.Message = "Mesa Añadida Satisfactoriamente";
                }
                LoadAllMesaList();
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

            view.IdSala = null;
            view.CantidadPersona = 1;
            view.Nombre = "";
        }

        private void Eliminar(object sender, EventArgs e)
        {
            try
            {
                this.mesarepo.Delete(this.view.IdMesa);
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }

            view.isEdit = false;
            LoadAllMesaList();
            CleanviewFields();
        }

        private void LoadSelectedMesa(object sender, EventArgs e)
        {
            var currentRow = mesaBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdMesa = Convert.ToInt32(currentRow["IdMesa"]);
                view.IdSala = Convert.ToInt32(currentRow["IdSala"]);
                view.Nombre = currentRow["Nombre"].ToString();
                view.CantidadPersona = Convert.ToInt32(currentRow["CantidadPersona"]);

                view.isEdit = true;
            }
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void LoadSalaList()
        {
            IEnumerable<SalaModel> salalist = salarepo.GetAll();
            this.view.SetSalaComboBox(salalist);
        }

        private void LoadAllMesaList()
        {
            IEnumerable<MesaModel> mesalist = mesarepo.GetAll();

            DataTable datatable = DataTableConverter.ConvertToDataTable(mesalist.ToList());

            mesaBindingSource.DataSource = datatable;
        }
    }
}
