using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using Restaurant.Repositories;
using Restaurant.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using Restaurant.Presenters.Common;

namespace Restaurant.Presenters
{
    internal class ClientePresenter
    {
        private IClienteView view;
        private BindingSource clienteBindingSource;
        private IEnumerable<ClienteModel> clienteList;

        private IClienteRepository clienterepo;
        private ITipoClienteRepository tipoclienterepo;
        private IProvinciaRepository provinciarepo;
        private ITipoDocumentoRepository tipodocumentorepo;

        public ClientePresenter(IClienteView clienteview, IClienteRepository clienterepo, ITipoDocumentoRepository tipodocrepo, ITipoClienteRepository tipoclienterepo, IProvinciaRepository provinciarepo)
        {
            this.view = clienteview;
            this.clienterepo = clienterepo;
            this.tipoclienterepo = tipoclienterepo;
            this.provinciarepo = provinciarepo;
            this.tipodocumentorepo = tipodocrepo;

            this.clienteBindingSource = new BindingSource();

            this.view.GuardarEvent += GuardarCliente;
            this.view.LimpiarEvent += Limpiar;
            this.view.EditarEvent += LoadSelectedClienteToEdit;
            this.view.DeleteEvent += EliminarCliente;

            this.view.SetClienteListBindingSource(clienteBindingSource);

            LoadAllClienteList();
            LoadAllTipoDocumentoList();
            LoadAllTipoClienteList();
            LoadAllProvinciaList();


        }

        private void EliminarCliente(object sender, EventArgs e)
        {
            try
            {
                this.clienterepo.Delete(this.view.IdCliente);
            }
            catch(Exception ex)
            {
                view.Message = ex.Message;
            }
            
            view.isEdit = false;
            LoadAllClienteList();
            CleanviewFields();
        }

        private void LoadAllProvinciaList()
        {
            IEnumerable<ProvinciaModel> provinciaList = provinciarepo.GetAll();
            view.SetProvinciaComboBox(provinciaList);
        }

        private void LoadAllTipoClienteList()
        {
            IEnumerable<TipoClienteModel> tipoclienteList = tipoclienterepo.GetAll();
            view.SetTipoClienteComboBox(tipoclienteList);
        }

        private void LoadAllTipoDocumentoList()
        {
            IEnumerable<TipoDocumentoModel> tipodocumentoList = tipodocumentorepo.GetAll();
            view.SetTipoDocumentoComboBox(tipodocumentoList);
        }

        private void LoadAllClienteList()
        {
            clienteList = clienterepo.GetAll();
            
            DataTable usuarioDataTable = DataTableConverter.ConvertToDataTable(clienteList.ToList());

            clienteBindingSource.DataSource = usuarioDataTable;
        }

        private void LoadSelectedClienteToEdit(object sender, EventArgs e)
        {
            
            var currentRow = clienteBindingSource.Current as DataRowView;
            if (currentRow != null)
            {
                view.IdCliente = Convert.ToInt32(currentRow["IdCliente"]);
                view.IdTipoCliente = Convert.ToInt32(currentRow["IdTipoCliente"]);
                view.IdTipoDocumento = Convert.ToInt32(currentRow["IdTipoDocumento"]);
                view.NoDocumento = currentRow["NoDocumento"].ToString();
                view.Nombre = currentRow["Nombre"].ToString();
                view.RazonSocial = currentRow["RazonSocial"].ToString();
                view.GiroCliente = currentRow["GiroCliente"].ToString();
                view.Telefono = currentRow["Telefono"].ToString();
                view.Correo = currentRow["Correo"].ToString();
                view.IdProvincia = (int)currentRow["IdProvincia"];
                view.Direccion = currentRow["Direccion"].ToString();
                view.LimiteCredito = currentRow["LimiteCredito"] != DBNull.Value ? Convert.ToDecimal(currentRow["LimiteCredito"]) : (decimal?)null;
                

                view.isEdit = true;
            }
            
            
        }

        private void Limpiar(object sender, EventArgs e)
        {
            CleanviewFields();
        }

        private void GuardarCliente(object sender, EventArgs e)
        {
            var model = new ClienteModel();
            model.IdProvincia = view.IdProvincia;
            model.IdTipoCliente = view.IdTipoCliente;
            model.RazonSocial = view.RazonSocial;
            model.Correo = view.Correo;
            model.Direccion = view.Direccion;
            model.NoDocumento = view.NoDocumento;
            model.IdTipoDocumento = view.IdTipoDocumento;
            model.Nombre = view.Nombre;
            model.GiroCliente = view.GiroCliente;
            model.Telefono = view.Telefono;
            model.LimiteCredito = view.LimiteCredito;
          
            model.IdCliente = view.IdCliente; 



            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.isEdit)
                {
                    clienterepo.Update(model);
                    view.Message = "Cliente Editado Satisfactoriamente";
                    view.isEdit = false;
                }
                else
                {
                    clienterepo.Add(model);
                    view.Message = "Cliente Añadido Satisfactoriamente";
                }
                LoadAllClienteList();
                CleanviewFields();
            }
            catch (Exception ex)
            {
                view.Message = ex.Message;
            }
        }

        private void CleanviewFields()
        {
            view.RazonSocial = "";
            view.IdTipoCliente = 0;
            view.IdTipoDocumento = 0;
            view.IdProvincia = 0;
            view.Direccion = "";
            view.NoDocumento = "";
            view.Correo = "";
            view.Nombre = "";
            view.GiroCliente = "";
            view.Telefono = "";
            view.LimiteCredito = -1;

            view.isEdit = false;

            
        }
    }
}
