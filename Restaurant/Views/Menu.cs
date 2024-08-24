using Restaurant.Presenters;
using Restaurant.Repositories;
using Restaurant.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant
{
    public partial class Menu : Form, IMenuView
    {

        private string _user;
        private int tipouser;

        //Events
        public event EventHandler ShowUsuarioView;
        public event EventHandler ShowClienteView;
        public event EventHandler ShowCategoriaView;
        public event EventHandler ShowSalaView;
        public event EventHandler ShowMesaView;
        public event EventHandler ShowDepartamentoView;
        public event EventHandler ShowMonedaView;
        public event EventHandler ShowImpuestoView;
        public event EventHandler ShowMedidaView;
        public event EventHandler ShowProveedorView;
        public event EventHandler ShowProductoView;
        public event EventHandler ShowPOSView;
        public event EventHandler ShowReporteView;

        public string nombre { 
            get { return _user; }
            set { _user = value; }
        }

        public int IdTipoUsuario
        {
            get { return tipouser; }
            set { tipouser = value; }
        }

        public Menu(string userName)
        {
            InitializeComponent();
            nombre = userName;
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            if (tipouser == 0)
            {
                btnusuarios.Click += delegate { ShowUsuarioView?.Invoke(this, EventArgs.Empty); };
                btnclientes.Click += delegate { ShowClienteView?.Invoke(this, EventArgs.Empty); };
                btncategorias.Click += delegate { ShowCategoriaView?.Invoke(this, EventArgs.Empty); };
                btnsalas.Click += delegate { ShowSalaView?.Invoke(this, EventArgs.Empty); };
                btnmesas.Click += delegate { ShowMesaView?.Invoke(this, EventArgs.Empty); };
                btndepartamentos.Click += delegate { ShowDepartamentoView?.Invoke(this, EventArgs.Empty); };
                btnmoneda.Click += delegate { ShowMonedaView?.Invoke(this, EventArgs.Empty); };
                btnimpuestos.Click += delegate { ShowImpuestoView?.Invoke(this, EventArgs.Empty); };
                btnmedidas.Click += delegate { ShowMedidaView?.Invoke(this, EventArgs.Empty); };
                btnproveedor.Click += delegate { ShowProveedorView?.Invoke(this, EventArgs.Empty); };
                btnproducto.Click += delegate { ShowProductoView?.Invoke(this, EventArgs.Empty); };
                btnrepventas.Click += delegate { ShowReporteView?.Invoke(this, EventArgs.Empty); };
            }

            btninicio.Click += new System.EventHandler(this.btninicio_Click);
            btninicio.PerformClick();

            btnpos.Click += delegate { ShowPOSView?.Invoke(this, EventArgs.Empty); };

        }

        public void AddControls(Form f)
        {

            if (CenterPanel.Controls.OfType<Form>().Any())
            {
                // Dispose of all existing forms in the panel
                foreach (Control control in CenterPanel.Controls)
                {
                    if (control is Form form)
                    {
                        form.Dispose();
                    }
                }
            }

            // Configure the new form
            f.Dock = DockStyle.Fill;
            f.TopLevel = false;

            // Add the new form to the panel
            CenterPanel.Controls.Add(f);

            GC.Collect();

            // Show the new form
            f.Show();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            username.Text = nombre;
            if(IdTipoUsuario != 1)
            {
                empleadomenu();
            }
        }

        private void btninicio_Click(object sender, EventArgs e)
        {
            AddControls(new Inicio());
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                    "¿Estás seguro de que deseas cerrar sesión?",
                    "Confirmar Salida",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

            if (resultado == DialogResult.Yes)
            {
                // Cierra el formulario actual
                this.Dispose();

                // Crea una nueva instancia del formulario principal
                // (Si se pone con el Show, por alguna razón, no funciona)
                Application.Restart();
            }
        }

        private void empleadomenu()
        {
            labelmant.Dispose();
            btnclientes.Dispose();
            btncategorias.Dispose();
            btnsalas.Dispose();
            btnusuarios.Dispose();
            btndepartamentos.Dispose();
            btnimpuestos.Dispose();
            btnproveedor.Dispose();
            btnmoneda.Dispose();
            btnmedidas.Dispose();
            btnmesas.Dispose();
            btnproducto.Dispose();
            labelrepo.Dispose();
            btnrepventas.Dispose();
            this.labelmovi.Location = new System.Drawing.Point(18, 200);
            this.btnpos.Location = new System.Drawing.Point(19, 223);

        }

    }
}


