using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces.Movimientos
{
    internal interface IReporteVentasView
    {
        byte? Mes { get; set; }
        int? Año { get; set; }

        decimal Total { get; set; }
        decimal Subtotal { get; set; }
        decimal Impuesto { get; set; }

        string Tipo { get; set; }

        void SetVentasBindingSource(BindingSource source);
        void ShowWaitingMessage();
        void HideWaitingMessage();

        void InvokeForm(Action action);


        event EventHandler GenerateReport;
        event EventHandler PrintReport;
    }
}
