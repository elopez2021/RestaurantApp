using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories.Interfaces
{
    internal interface IVentasReportRepository
    {
        IEnumerable<VentaReportModel> GetVentasPorCategoria(int month, int year);
        IEnumerable<VentaReportModel> GetVentasPorProducto(int month, int year);
        IEnumerable<VentaReportModel> GetVentasPorUsuario(int month, int year);
        (decimal Total, decimal Subtotal, decimal Impuesto) GetVentasTotals(int month, int year);
    }
}
