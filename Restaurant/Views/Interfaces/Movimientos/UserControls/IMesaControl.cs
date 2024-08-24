using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Views.Interfaces.Movimientos.UserControls
{
    internal interface IMesaControl
    {

        int IdMesa { get; set; }
        int IdSala { get;set ; }
        string Nombre { get;set; }
        
        int Cantidad { get;set; }
        bool Disponible { get;set; }

        bool Selected { get;set; }

        event EventHandler onSelectMesa;
    }
}
