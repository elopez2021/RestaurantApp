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
    public partial class MantCategorias : Form, ICategoriaView
    {
        public MantCategorias()
        {
            InitializeComponent();

            btnguardar.Click += delegate
            {
                GuardarEvent?.Invoke(this, EventArgs.Empty);
                MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btneliminar.Enabled = false;
            };

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

            btnlimpiar.Click += delegate { LimpiarEvent?.Invoke(this, EventArgs.Empty); btneliminar.Enabled = false; };

            table.CellClick += delegate { EditarEvent?.Invoke(this, EventArgs.Empty); btneliminar.Enabled = true; };

            this.Load += (sender, e) => txtnom.Focus(); // Establece el foco en txtnom al cargar el formulario

        }

        public int IdCategoria { get; set; }
        public string Nombre {
            get { return txtnom.Text; }
            set { txtnom.Text = value; }
        }

        public string Message { get; set; }
        public bool isEdit { get; set; }

        public event EventHandler GuardarEvent;
        public event EventHandler EditarEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler LimpiarEvent;

        public void SetCategoriaListBindingSource(BindingSource categoriaList)
        {
            table.DataSource = categoriaList;
        }

        private void txtnom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnguardar.PerformClick();
                e.Handled = true; // Esto evita que se genere un 'beep' al presionar Enter
                txtnom.Focus();
            }
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
