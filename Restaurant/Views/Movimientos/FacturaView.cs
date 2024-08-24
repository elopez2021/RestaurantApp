using Microsoft.Reporting.WinForms;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Restaurant.Views.Movimientos
{
    public partial class FacturaView : Form
    {
        private IEnumerable<PedidoProductoModel> _dataSource;
        private FacturaModel _factura;

        public FacturaView(IEnumerable<PedidoProductoModel> dataSource, FacturaModel factura)
        {
            InitializeComponent();
            _dataSource = dataSource;
            _factura = factura;

            LoadReport();
        }

        private void LoadReport()
        {
            if (this.report == null)
            {
                throw new ArgumentNullException(nameof(this.report), "ReportViewer control is null");
            }

            // Crea los parámetros del reporte
            ReportParameter[] para = new ReportParameter[]
            {
                new ReportParameter("rDate", _factura.Fecha.ToString("dd/MM/yyyy")),
                new ReportParameter("rCliente", _factura.NombreCliente),
                new ReportParameter("rUsuario", _factura.NombreUsuario),
                new ReportParameter("rSubtotal", _factura.SubTotal.ToString("N2")),
                new ReportParameter("rNCF", "001-001-0000001234"),
                new ReportParameter("rTotal", _factura.Total.ToString("N2")),
                new ReportParameter("rImpuesto", _factura.Impuesto.ToString("N2")),
                new ReportParameter("rHora", _factura.Fecha.ToString("hh:mm tt")),
            };

            // Asigna la lista directamente como la fuente de datos del reporte
            ReportDataSource reportDataSource = new ReportDataSource("DataSet1", _dataSource);

            // Configura el ReportViewer
            this.report.LocalReport.DataSources.Clear();
            this.report.LocalReport.DataSources.Add(reportDataSource);
            this.report.LocalReport.SetParameters(para);

            this.report.RefreshReport();
        }

        private void ReportView_Load(object sender, EventArgs e)
        {
            this.report.RefreshReport();
        }
    }
}
