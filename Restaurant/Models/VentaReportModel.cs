using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Models
{
    public class VentaReportModel
    {
        public string Nombre { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Impuesto { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
