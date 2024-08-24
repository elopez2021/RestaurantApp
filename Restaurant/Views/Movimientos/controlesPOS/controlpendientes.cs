using Restaurant.Views.Interfaces.Movimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Movimientos.POS_controles
{
    public partial class controlpendientes : Form, IPedidosPendientesView
    {

        private static controlpendientes _instance;
        private Form waitingForm;

        public string Message { get; set; }

        public static controlpendientes GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new controlpendientes();
            else
            {
                if (_instance.WindowState == FormWindowState.Minimized)
                    _instance.WindowState = FormWindowState.Normal;
                _instance.BringToFront();
            }
            return _instance;
        }
        public controlpendientes()
        {
            InitializeComponent();
            this.Show();

            btnentregado.Click += delegate { 
                SetPedidoEntregado?.Invoke(this, EventArgs.Empty);
                if(!string.IsNullOrEmpty(Message))
                    MessageBox.Show(Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        public event EventHandler SetPedidoEntregado;

        public void SetPedidosBindingSource(BindingSource source)
        {
            table.DataSource = source;
        }

        private void btnexitpedidos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowWaitingMessage()
        {
            waitingForm = new Form
            {
                Text = "Cargando",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                ControlBox = false,
                StartPosition = FormStartPosition.CenterParent,
                Size = new Size(300, 100),
                TopMost = true,
            };

            Label messageLabel = new Label
            {
                Text = "Espere por favor, cargando la factura...",
                AutoSize = true,
                Location = new Point(50, 30),
            };
            waitingForm.Controls.Add(messageLabel);

            Task.Run(() => waitingForm.ShowDialog());
        }

        public void HideWaitingMessage()
        {
            if (waitingForm != null && waitingForm.InvokeRequired)
            {
                waitingForm.Invoke((Action)(() => waitingForm.Close()));
            }
            else
            {
                waitingForm?.Close();
            }
        }
        
        public void InvokeForm(Action action)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(action);
            }
            else
            {
                action();
            }
        }
    }
}
