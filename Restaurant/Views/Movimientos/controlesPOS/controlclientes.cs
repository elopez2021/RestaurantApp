using Restaurant.Views.Interfaces.Movimientos;
using System;
using System.Windows.Forms;

namespace Restaurant.Views.Movimientos.POS_controles
{
    public partial class controlclientes : Form, IClienteControl
    {
        private static controlclientes _instance;

        public static controlclientes GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new controlclientes();
            else
            {
                if (_instance.WindowState == FormWindowState.Minimized)
                    _instance.WindowState = FormWindowState.Normal;
                _instance.BringToFront();
            }
            return _instance;
        }

        public controlclientes()
        {
            InitializeComponent();
            this.Deactivate += new EventHandler(controlclientes_Deactivate);

            table.CellDoubleClick += delegate { GetSelectedClienteEvent?.Invoke(this, EventArgs.Empty); };
        }

        private void controlclientes_Deactivate(object sender, EventArgs e)
        {
            // Cierra la ventana emergente cuando pierda el foco.
            this.Close();
        }

        public event EventHandler GetSelectedClienteEvent;

        public void SetClienteBindingSource(BindingSource clienteList)
        {
            table.DataSource = clienteList;
        }

        public void DisposeWindow()
        {
            this.Dispose();
        }

        public void ShowWindow()
        {
            this.Show();
        }
    }
}
