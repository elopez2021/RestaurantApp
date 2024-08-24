using Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Restaurant.Views.Interfaces
{
    internal interface IMesaView
    {
        int IdMesa { get; set; }
        string Nombre { get; set; }
        int? IdSala { get; set; }
        int CantidadPersona { get; set; }

        string Message { get; set; }
        bool isEdit { get; set; }


        event EventHandler GuardarEvent;
        event EventHandler EditarEvent;
        event EventHandler DeleteEvent;
        event EventHandler LimpiarEvent;

        void SetMesaListBindingSource(BindingSource mesaList);
        void SetSalaComboBox(IEnumerable<SalaModel> salaList);
    }
}
