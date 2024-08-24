using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Restaurant.Models;
using Restaurant.Views.Interfaces;

namespace Restaurant.Views
{
    public partial class MantClientes : Form, IClienteView
    {
        public MantClientes()
        {
            InitializeComponent();

            btnguardar.Click += delegate { 
                GuardarEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btneliminar.Enabled = false;
            };
            btnlimpiar.Click += delegate { LimpiarEvent?.Invoke(this, EventArgs.Empty); btneliminar.Enabled = false; };
            btneliminar.Click += delegate {

                DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de que deseas desactivar este registro?",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    btneliminar.Enabled = false;
                }
                
            };
            table.CellClick += delegate { EditarEvent?.Invoke(this, EventArgs.Empty); btneliminar.Enabled = true; };

            this.Load += (sender, e) => cmbtipocliente.Focus(); // Establece el foco en txtnom al cargar el formulario

        }

        public int IdCliente { get; set; }
        public int? IdTipoCliente {
            get { return cmbtipocliente.SelectedValue != null ? Convert.ToInt32(cmbtipocliente.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbtipocliente.SelectedValue = selected ?? -1; }
        }
        public int? IdTipoDocumento {
            get { return cmbtipodocumento.SelectedValue != null ? Convert.ToInt32(cmbtipodocumento.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbtipodocumento.SelectedValue = selected ?? -1; }
        }
        public string NoDocumento { 
            get { return txtdoc.Text; }
            set { txtdoc.Text = value; }
        }
        public string Nombre { 
            get { return txtnomb.Text; }
            set { txtnomb.Text = value; }
        }
        public string RazonSocial { 
            get { return txtrazon.Text; }
            set { txtrazon.Text = value; }
        }
        public string GiroCliente { 
            get { return txtgiro.Text; }
            set { txtgiro.Text = value; }
        }
        public string Telefono {
            get { return txttelef.Text; }
            set { txttelef.Text = value; }
        }
        public string Correo { 
            get { return txtcorreo.Text; }
            set { txtcorreo.Text = value; }
        }
        public int? IdProvincia {
            get { return cmbprovincia.SelectedValue != null ? Convert.ToInt32(cmbprovincia.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbprovincia.SelectedValue = selected ?? -1; }
        }
        public string Direccion { 
            get { return txtdirecc.Text; }
            set { txtdirecc.Text = value; }
        }
        public decimal? LimiteCredito {
            get {

                if (decimal.TryParse(txtcred.Text, out decimal result))
                {
                    return result;
                }
                else
                {
                    return 0.0m;
                }

            }
            set {
                if (value == -1)
                    txtcred.Text = "";
                else 
                    txtcred.Text = value.ToString();
            }
        }

        public bool isEdit { get; set; }
        public string Message { get; set; }
        

        public event EventHandler LimpiarEvent;
        public event EventHandler GuardarEvent;
        public event EventHandler EditarEvent;
        public event EventHandler DeleteEvent;

        public void SetClienteListBindingSource(BindingSource clienteList)
        {
            table.DataSource = clienteList;
        }

        void IClienteView.SetProvinciaComboBox(IEnumerable<ProvinciaModel> provinciaList)
        {
            cmbprovincia.DataSource = provinciaList.ToList();

            cmbprovincia.DisplayMember = "Nombre";
            cmbprovincia.ValueMember = "IdProvincia";

            cmbprovincia.SelectedValue = -1;
        }

        void IClienteView.SetTipoClienteComboBox(IEnumerable<TipoClienteModel> tipoclienteList)
        {
            cmbtipocliente.DataSource = tipoclienteList.ToList();

            cmbtipocliente.DisplayMember = "Nombre";
            cmbtipocliente.ValueMember = "IdTipoCliente";

            cmbtipocliente.SelectedValue = -1;
        }

        void IClienteView.SetTipoDocumentoComboBox(IEnumerable<TipoDocumentoModel> tipodocumentoList)
        {
            cmbtipodocumento.DataSource = tipodocumentoList.ToList();

            cmbtipodocumento.DisplayMember = "Nombre";
            cmbtipodocumento.ValueMember = "IdTipoDocumento";

            cmbtipodocumento.SelectedValue = -1;
        }

        private void cmbtipocliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbtipodocumento.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void cmbtipodocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtdoc.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtnomb.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void txtnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtrazon.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
        private void txrazon_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtgiro.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }
        private void txtgiro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txttelef.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }
        private void txttelef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtcorreo.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void txtcorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbprovincia.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }
        private void cmbprovincia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtdirecc.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }
        private void txtdirecc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtcred.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }
        private void txtcred_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                btnguardar.PerformClick();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
                cmbtipocliente.Focus();
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }

        }
    }
}
