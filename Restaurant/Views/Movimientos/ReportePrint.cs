using Microsoft.Reporting.WinForms;
using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Restaurant.Views.Movimientos.controlesReportes
{
    public partial class ReportePrint : Form
    {
        private readonly IEnumerable<VentaReportModel> _datasource;
        private readonly string tipoReporte;
        private readonly byte mes;
        private readonly int año;
        private readonly decimal total, subtotal, impuesto;
        private readonly string usuario;

        public ReportePrint(IEnumerable<VentaReportModel> list, string usuario, string tipo, byte mes, int año, decimal total, decimal subtotal, decimal impuesto)
        {
            InitializeComponent();

            // Asignar valores a las variables de instancia
            this._datasource = list;  
            this.usuario = usuario;
            this.tipoReporte = tipo;
            this.mes = mes;
            this.año = año;
            this.subtotal = subtotal;
            this.total = total;
            this.impuesto = impuesto;

        
            // Cargar el reporte
            LoadReport();
        }

        private void LoadReport()
        {
            // Configura la ruta del archivo .rdlc (si está embebido en el proyecto)
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Restaurant.Views.Movimientos.controlesReportes.ReportVentas.rdlc";

            // Asigna el DataSource al ReportViewer
            ReportDataSource rds = new ReportDataSource("DataSet2", _datasource);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rds);

            // Parámetros del reporte (opcional, si tu reporte requiere parámetros)
            ReportParameter[] parameters = new ReportParameter[]
            {
                new ReportParameter("rUsuario", this.usuario),
                new ReportParameter("rMes", this.mes.ToString()),
                new ReportParameter("rAno", this.año.ToString()),
                new ReportParameter("rTipo", this.tipoReporte.ToString()),
                new ReportParameter("rTotal", this.total.ToString("N2")),
                new ReportParameter("rSubtotal", this.subtotal.ToString("N2")),
                new ReportParameter("rImpuesto", this.impuesto.ToString("N2"))
            };
            this.reportViewer1.LocalReport.SetParameters(parameters);

            // Refresca el ReportViewer para mostrar el reporte
            this.reportViewer1.RefreshReport();
        }

        private void ReporteView_Load(object sender, EventArgs e)
        {
            // Refresca el ReportViewer cuando se cargue el formulario
            this.reportViewer1.RefreshReport();
        }
    }
}