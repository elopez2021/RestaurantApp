using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces.Movimientos
{
    internal interface IClienteControl
    {
        event EventHandler GetSelectedClienteEvent;

        void SetClienteBindingSource(BindingSource clienteList);

        void DisposeWindow();
        void ShowWindow();
    }
}
