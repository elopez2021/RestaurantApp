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
    public partial class MantMesas : Form, IMesaView
    {
        
        public MantMesas()
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


        public int IdMesa { get; set; }
        public string Nombre { 
            get { return txtnomb.Text; }
            set { txtnomb.Text = value; }
        }
        public int? IdSala {
            get { return cmbsala.SelectedValue != null ? Convert.ToInt32(cmbsala.SelectedValue) : (int?)null; }
            set { int? selected = value; cmbsala.SelectedValue = selected ?? -1; }
        }
        public int CantidadPersona { 
            get { return (int)boxcant.Value; }
            set {  boxcant.Value = value; }
        }
        public string Message { get; set; }
        public bool isEdit { get; set; }

        public event EventHandler GuardarEvent;
        public event EventHandler EditarEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler LimpiarEvent;

        private void combosala_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                txtnomb.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void txtnomb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                boxcant.Focus();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
            }
        }

        private void boxcant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)//Al presionar enter pasa al siguiente cuadro
            {
                btnguardar.PerformClick();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
                txtnomb.Focus();
            }
        }

        public void SetMesaListBindingSource(BindingSource mesaList)
        {
            table.DataSource = mesaList;
        }

        void IMesaView.SetSalaComboBox(IEnumerable<SalaModel> salaList)
        {
            //convert salalist to dictionary because IdSala is not browsable
            var saladict = salaList.ToDictionary(s => s.IdSala, s => s.Nombre);
            cmbsala.DataSource = new BindingSource(saladict, null);
            cmbsala.DisplayMember = "Value";
            cmbsala.ValueMember = "Key";


            cmbsala.SelectedValue = -1;
        }
    }
}
