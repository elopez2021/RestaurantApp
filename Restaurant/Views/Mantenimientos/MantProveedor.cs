using Restaurant.Models;
using Restaurant.Views.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views
{
    public partial class MantProveedor : Form, IProveedorView
    {
        public MantProveedor()
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
        }

        public int IdProveedor { get; set; }
        public string NombreProveedor { 
            get { return txtnombreproveedor.Text; }
            set { txtnombreproveedor.Text = value; }
        }
        public string Telefono { 
            get { return txttelef.Text; }
            set { txttelef.Text = value; }
        }
        public string NoDocumento { 
            get { return txtdoc.Text; }
            set { txtdoc.Text = value; }            
        }
        public int? IdTipoDocumento {
            get { return cmbtipodocumento.SelectedValue != null ? Convert.ToInt32(cmbtipodocumento.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbtipodocumento.SelectedValue = selected ?? -1; }
        }
        public int? IdProvincia {
            get { return cmbprovincia.SelectedValue != null ? Convert.ToInt32(cmbprovincia.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbprovincia.SelectedValue = selected ?? -1; }
        }
        public int? IdDepartamento {
            get { return cmbdepartamento.SelectedValue != null ? Convert.ToInt32(cmbdepartamento.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbdepartamento.SelectedValue = selected ?? -1; }
        }
        public string Direccion { 
            get { return txtdirecc.Text; }
            set { txtdirecc.Text = value; }
        }
        public string Correo {
            get { return txtcorreo.Text; }
            set { txtcorreo.Text = value; }
        }
        public string NombreVendedor
        {
            get { return txtnombrevendedor.Text; }
            set { txtnombrevendedor.Text = value; }
        }
        public string Message { get; set; }
        public bool isEdit { get; set; }

        public event EventHandler GuardarEvent;
        public event EventHandler EditarEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler LimpiarEvent;

        private void combotipo_KeyPress(object sender, KeyPressEventArgs e)
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
                txtnombreproveedor.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txttelef.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txttelef_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbprovincia.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboprovin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbdepartamento.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void combodepart_KeyPress(object sender, KeyPressEventArgs e)
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
                txtcorreo.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtcorreo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtnombrevendedor.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtvendedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                btnguardar.PerformClick();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
                cmbtipodocumento.Focus();
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        public void SetProveedorListBindingSource(BindingSource proveedorList)
        {
            table.DataSource = proveedorList;
        }

        void IProveedorView.SetTipoDocumentoComboBox(IEnumerable<TipoDocumentoModel> tipodocumentoList)
        {
            cmbtipodocumento.DataSource = tipodocumentoList.ToList();

            cmbtipodocumento.DisplayMember = "Nombre";
            cmbtipodocumento.ValueMember = "IdTipoDocumento";

            cmbtipodocumento.SelectedValue = -1;
        }

        void IProveedorView.SetProvinciaComboBox(IEnumerable<ProvinciaModel> provinciaList)
        {
            cmbprovincia.DataSource = provinciaList.ToList();

            cmbprovincia.DisplayMember = "Nombre";
            cmbprovincia.ValueMember = "IdProvincia";

            cmbprovincia.SelectedValue = -1;
        }

        void IProveedorView.SetDepartamentoComboBox(IEnumerable<DepartamentoModel> departamentoList)
        {
            var saladict = departamentoList.ToDictionary(s => s.IdDepartamento, s => s.Nombre);
            cmbdepartamento.DataSource = new BindingSource(saladict, null);
            cmbdepartamento.DisplayMember = "Value";
            cmbdepartamento.ValueMember = "Key";
            cmbdepartamento.SelectedValue = -1;
        }
    }
}
