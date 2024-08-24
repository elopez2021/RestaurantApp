using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces.Movimientos
{
    internal interface IFacturaView
    {
        event EventHandler PrintFactura;
        void SetFacturaBindingSource(BindingSource source);

        void ShowWaitingMessage();
        void HideWaitingMessage();

        void InvokeForm(Action action);
    }
}
