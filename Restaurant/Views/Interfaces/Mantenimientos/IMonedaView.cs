using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces
{
    internal interface IMonedaView
    {
        int IdMoneda { get; set; }
        string Nombre { get; set; }
        string Sigla { get; set; }
        string Simbolo { get; set; }

        string Message { get; set; }
        bool isEdit { get; set; }


        event EventHandler GuardarEvent;
        event EventHandler EditarEvent;
        event EventHandler DeleteEvent;
        event EventHandler LimpiarEvent;

        void SetMonedaListBindingSource(BindingSource monedaList);
    }
}
