using Restaurant.Models;
using Restaurant.Repositories.Interfaces;
using Restaurant.Views.Interfaces.Movimientos;
using Restaurant.Views.Movimientos.controlesReportes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Presenters
{
    internal class ReportePresenter
    {
        private readonly IReporteVentasView view;
        private readonly IVentasReportRepository salesrepo;
        private BindingSource ventasBindingSource;
        private readonly String usuario;
        IEnumerable<VentaReportModel> list;

        public ReportePresenter(IReporteVentasView view, IVentasReportRepository salesrepo, string nombre)
        {
            this.view = view;
            this.salesrepo = salesrepo;
            ventasBindingSource = new BindingSource();
            this.usuario = nombre;
            this.view.SetVentasBindingSource(ventasBindingSource);

            this.view.GenerateReport += GenerateReport;
            this.view.PrintReport += PrintReportWrapper;
        }

        private async void PrintReportWrapper(object sender, EventArgs e)
        {
            await PrintReportAsync(sender, e);
        }

        private async Task PrintReportAsync(object sender, EventArgs e)
        {
            var tipo = view.Tipo;
            var mes = view.Mes;
            var año = view.Año;
            var total = view.Total;
            var subtotal = view.Subtotal;
            var impuesto = view.Impuesto;

            if (tipo == null || mes == null || año == null || list.Count() == 0)
            {
                return;
            }

            view.ShowWaitingMessage();

            await Task.Run(() =>
            {
                view.InvokeForm((Action)(() =>
                {
                    var reportForm = new ReportePrint(list, usuario, tipo, (byte)mes, (int)año, total, subtotal, impuesto);
                    view.HideWaitingMessage();
                    reportForm.Show();
                }));
            });
        }

        private void GenerateReport(object sender, EventArgs e)
        {
            if(view.Tipo == null || view.Mes == null || view.Año == null)
            {
                return;
            }
            int selectedMonth = (int)view.Mes;
            int selectedYear = (int)view.Año;
                      

            switch (view.Tipo)
            {
                case "Usuario":
                    list = salesrepo.GetVentasPorUsuario(selectedMonth, selectedYear);
                    break;
                case "Producto":
                    list = salesrepo.GetVentasPorProducto(selectedMonth, selectedYear);
                    break;
                case "Categoria":
                    list = salesrepo.GetVentasPorCategoria(selectedMonth, selectedYear);
                    break;
            }

            ventasBindingSource.DataSource = list;
            
            view.Total = Math.Round((decimal)list.Sum(venta => venta.Total),2);
            view.Subtotal = Math.Round((decimal)list.Sum(venta => venta.Subtotal),2);
            view.Impuesto = Math.Round(list.Sum(venta => venta.Impuesto),2);
        }
    }
}
