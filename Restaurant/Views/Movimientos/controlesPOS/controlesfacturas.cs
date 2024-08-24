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
    public partial class controlesfacturas : Form, IFacturaView
    {

        private static controlesfacturas _instance;
        private Form waitingForm;

        public static controlesfacturas GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
                _instance = new controlesfacturas();
            else
            {
                if (_instance.WindowState == FormWindowState.Minimized)
                    _instance.WindowState = FormWindowState.Normal;
                _instance.BringToFront();
            }
            return _instance;
        }
        public controlesfacturas()
        {
            InitializeComponent();
            this.Show();

            btnimprimir.Click += delegate { PrintFactura?.Invoke(this, EventArgs.Empty); };
        }

        public event EventHandler PrintFactura;

        public void SetFacturaBindingSource(BindingSource source)
        {
            table.DataSource = source;
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

            // Add a label to display the message
            Label messageLabel = new Label
            {
                Text = "Espere por favor, cargando la factura...",
                AutoSize = true,
                Location = new Point(50, 30),
            };
            waitingForm.Controls.Add(messageLabel);

            // Show the form on a new thread
            Task.Run(() => waitingForm.ShowDialog());
        }

        public void HideWaitingMessage()
        {
            // Close the waiting form
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
