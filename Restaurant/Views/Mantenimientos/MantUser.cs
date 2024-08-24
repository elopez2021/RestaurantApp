using Restaurant.Models;
using Restaurant.Views.Interfaces;
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

namespace Restaurant.Views
{
    public partial class MantUser : Form, IUsuarioView
    {
        public MantUser()
        {
            InitializeComponent();
            AssociateRaiseEvents();


        }


        private void AssociateRaiseEvents()
        {
            btnguardar.Click += delegate { 
                GuardarEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            btnlimpiar.Click += delegate { LimpiarEvent?.Invoke(this, EventArgs.Empty); };

            table.CellClick += delegate { EditEvent?.Invoke(this, EventArgs.Empty); };
        }

        public int IdUsuario { get; set; }
        public string NoDocumento
        {
            get {
                if (txtdoc.Text == "")
                    return null;
                return txtdoc.Text; }
            set { txtdoc.Text = value.ToString(); }
        }
        public string Usuario { 
            get { return txtuser.Text; }
            set { txtuser.Text = value; }
        }
        public string Contrasena { 
            get { return txtpass.Text; }
            set { txtpass.Text = value; }
        }
        public int? IdTipoUsuario
        {
            get { return cmbacceso.SelectedValue != null ? Convert.ToInt32(cmbacceso.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbacceso.SelectedValue = selected ?? -1; }
        }
        public string Nombre {
            get { return txtnom.Text; }
            set { txtnom.Text = value; }
        }
        public string Correo {
            get { return txtcorreo.Text; }
            set { txtcorreo.Text = value; }
        }
        public int? IdSexo {
            get {
                if (cmbsexo.SelectedItem?.ToString() == null)
                    return null;
                
                return cmbsexo.SelectedIndex == 0 ? 1 : 2;
                
            }
            set { int? selected = value; cmbsexo.SelectedIndex = selected - 1 ?? -1; }
        }
        public string Direccion {
            get { return txtdirec.Text; }
            set { txtdirec.Text = value; }
        }
        public string Telefono {
            get { return txttelef.Text; }
            set { txttelef.Text = value; }
        }
        public int? IdSucursal {
            get { return cmbsucursal.SelectedValue != null ? Convert.ToInt32(cmbsucursal.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbsucursal.SelectedValue = selected ?? -1; }
        }
        public decimal? Comision { 
            get {
                if (txtcomision.Text.Replace(" ", "") == "")
                    return 0.0m;

                if (decimal.TryParse(txtcomision.Text, out decimal result))
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value == null || value == -1.0m)
                {
                    txtcomision.Text = "";
                }
                else
                {
                    txtcomision.Text = value.ToString();
                }
            }
        }
        public bool? Estatus
        {
            get
            {
                if (cmbestado.SelectedIndex == -1)
                    return null;

                return cmbestado.SelectedIndex == 0;
            }
            set
            {
                if (value == null)
                {
                    cmbestado.SelectedIndex = -1; 
                }
                else
                {
                    cmbestado.SelectedIndex = (bool)value ? 0 : 1;
                }
            }
        }


        public string Message { get; set; }
        public bool isEdit { get; set; }
        
        public void SetUsuarioListBindingSource(BindingSource usuarioList)
        {
            table.DataSource = usuarioList;

        }


        void IUsuarioView.SetSucursalesComboBox(IEnumerable<SucursalModel> sucursalList)
        {
            cmbsucursal.DataSource = sucursalList.ToList();
            
            cmbsucursal.DisplayMember = "Nombre";
            cmbsucursal.ValueMember = "IdSucursal";

            cmbsucursal.SelectedValue = -1;
        }

        void IUsuarioView.SetTipoUsuariosComboBox(IEnumerable<TipoUsuarioModel> tipoList)
        {
            cmbacceso.DataSource = tipoList.ToList();

            cmbacceso.DisplayMember = "Descripcion";
            cmbacceso.ValueMember = "IdTipo";

            cmbacceso.SelectedValue = -1;
        }

        //Events
        public event EventHandler LimpiarEvent;
        public event EventHandler GuardarEvent;
        public event EventHandler EditEvent;

        private void MantUser_Load(object sender, EventArgs e)
        {
            txtdoc.Focus();
        }

        private void txtdoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtnom.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbsexo.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void cmbsexo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtdirec.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtdirec_KeyPress(object sender, KeyPressEventArgs e)
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
                txtuser.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtuser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtpass.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtpass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbacceso.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void cmbacceso_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbestado.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void cmbestado_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtcomision.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtcomision_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbsucursal.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void cmbsucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnguardar.PerformClick();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
                txtdoc.Focus();
            }
        }
    }
}
