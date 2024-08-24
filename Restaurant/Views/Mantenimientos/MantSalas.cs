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
    public partial class MantSalas : Form, ISalaView
    {
        
        public MantSalas()
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

        public int IdSala { get; set; }
        public string Nombre {
            get { return txtnom.Text; }
            set {  txtnom.Text = value; }
        }
        public int? IdSucursal {
            get { return cmbsucursal.SelectedValue != null ? Convert.ToInt32(cmbsucursal.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbsucursal.SelectedValue = selected ?? -1; }

        }
        public string Message { get; set; }
        public bool isEdit { get; set; }

        public event EventHandler GuardarEvent;
        public event EventHandler EditarEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler LimpiarEvent;

        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                cmbsucursal.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void cmbsucursal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                btnguardar.PerformClick();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
                txtnom.Focus();
            }
        }

        public void SetSalaListBindingSource(BindingSource salaList)
        {
            table.DataSource = salaList;
        }

        void ISalaView.SetSucursalesComboBox(IEnumerable<SucursalModel> sucursalList)
        {
            cmbsucursal.DataSource = sucursalList.ToList();

            cmbsucursal.DisplayMember = "Nombre";
            cmbsucursal.ValueMember = "IdSucursal";

            cmbsucursal.SelectedValue= -1;
        }
    }
}
