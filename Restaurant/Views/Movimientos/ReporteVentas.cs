using Restaurant.Views.Interfaces.Movimientos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Movimientos
{
    public partial class ReporteVentas : Form, IReporteVentasView
    {

        private Form waitingForm;
        public ReporteVentas()
        {
            InitializeComponent();
            LlenarComboBoxAno(cmbano);
            cmbtiporeporte.SelectedIndex = 0;
            cmbano.SelectedIndexChanged += CmbAno_SelectedIndexChanged;
            cmbano.SelectedIndex = cmbano.Items.Count - 1; // Seleccionar el año actual por defecto

            btngenerar.Click += delegate { GenerateReport?.Invoke(this, EventArgs.Empty); };
            btnimprimir.Click += delegate {
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("No hay nada que imprimir. Primero genere un reporte que tenga datos.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    PrintReport?.Invoke(this, EventArgs.Empty);
                }                
            };
        }

        public byte? Mes {
            get
            {
                string selectedMonth = cmbmes.SelectedItem?.ToString();
                return selectedMonth != null ? (byte)(DateTime.ParseExact(selectedMonth, "MMMM", null).Month) : (byte?)null;
            }
            set
            {
                cmbmes.SelectedItem = new DateTime(1, (int)value, 1).ToString("MMMM");
            }
        }
        public int? Año
        {
            get
            {
                if (cmbano.SelectedItem != null)
                {
                    return Convert.ToInt32(cmbano.SelectedItem.ToString());
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue && value > 0)
                {
                    cmbano.SelectedItem = value.ToString();
                }
                else
                {
                    cmbano.SelectedIndex = -1;
                }
            }
        }
        public decimal Total
        {
            get => decimal.TryParse(lbltotal.Text, out var total) ? total : 0m;
            set => lbltotal.Text = value.ToString("N2");
        }

        public decimal Subtotal
        {
            get => decimal.TryParse(lblsubtotal.Text, out var subtotal) ? subtotal : 0m;
            set => lblsubtotal.Text = value.ToString("N2");
        }

        public decimal Impuesto
        {
            get => decimal.TryParse(lblimpuesto.Text, out var impuesto) ? impuesto : 0m;
            set => lblimpuesto.Text = value.ToString("N2");
        }
        public string Tipo { 
            get { return cmbtiporeporte.SelectedItem?.ToString(); }
            set { cmbtiporeporte.SelectedItem = value.ToString(); }
        }

        public event EventHandler GenerateReport;
        public event EventHandler PrintReport;

        private void LlenarComboBoxAno(ComboBox comboBox)
        {
            comboBox.Items.Clear();

            int anioInicial = 2023;
            int anioActual = DateTime.Now.Year;

            for (int anio = anioInicial; anio <= anioActual; anio++)
            {
                comboBox.Items.Add(anio.ToString());
            }
        }

        private void LlenarComboBoxMes(ComboBox comboBox, int anioSeleccionado)
        {
            comboBox.Items.Clear();

            int mesInicial = 1;
            int mesFinal = 12;

            if (anioSeleccionado == DateTime.Now.Year)
            {
                // Si el año seleccionado es el actual, solo mostrar hasta el mes actual
                mesFinal = DateTime.Now.Month;
            }

            for (int mes = mesInicial; mes <= mesFinal; mes++)
            {
                string nombreMes = new DateTime(anioSeleccionado, mes, 1).ToString("MMMM", CultureInfo.CurrentCulture);
                comboBox.Items.Add(nombreMes);
            }

            // Seleccionar el primer mes (enero) por defecto
            comboBox.SelectedIndex = 0;
        }

        private void CmbAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            int anioSeleccionado = int.Parse(cmbano.SelectedItem.ToString());
            LlenarComboBoxMes(cmbmes, anioSeleccionado);
        }

        public void SetVentasBindingSource(BindingSource source)
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

            Label messageLabel = new Label
            {
                Text = "Espere por favor, cargando el reporte...",
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